using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Administration;
using System.Reflection;
using System.IO;
using System.Xml.XPath;
using System.Globalization;

namespace Voo.University.Sharepoint
{
    /// <summary>
    /// Class implements basic list mapping for lookup fields.
    /// </summary>
    public class LookupReciever
    {
        private const String LookupsListMapping = "LookupsListMapping";
        private readonly Dictionary<String, String> lookupsListMapping = new Dictionary<String, String>();
        private const String SPXmlDocCacheAssembly = "Microsoft.SharePoint.SPXmlDocCache, Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c";

        private void CreateListMapping(SPFeatureReceiverProperties properties)
        {
            lookupsListMapping.Clear();
            String mappingString = properties.Feature.Properties[LookupsListMapping].Value;
            String[] mappings = mappingString.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string mapping in mappings)
            {
                String[] segments = mapping.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                lookupsListMapping.Add(segments[0].Trim(), segments[1].Trim());
            }
        }

        private static string RemoveXmlnsAttribute(String xml)
        {
            return Regex.Replace(xml, @"xmlns=""[^""]+""", "");
        }

        private static void AddWebIdAttribute(SPWeb web, XmlDocument doc)
        {
            XmlAttribute webIdAttr = doc.CreateAttribute("WebId");
            webIdAttr.Value = web.ID.ToString();
            doc.DocumentElement.SetAttributeNode(webIdAttr);
        }

        public void CreateLookup(SPFeatureReceiverProperties properties, SPWeb web, String filePath)
        {
            string fieldId;
            bool isReading = true;
            XmlDocument document = GetXmlDocument(properties.Definition, filePath, web.Locale);

            using (XmlTextReader reader = new XmlTextReader(new StringReader(document.OuterXml)))
            {
                CreateListMapping(properties);
                while (true)
                {
                    if (reader.LocalName != "Field" || isReading)
                    {
                        if (!reader.Read())
                        {
                            break;
                        }
                    }
                    if (reader.LocalName == "Field")
                    {
                        if (reader.MoveToAttribute("Type") && 
                            reader.Value == "Lookup" && 
                            reader.MoveToAttribute("ID"))
                        {
                            fieldId = reader.Value;
                            if (lookupsListMapping.ContainsKey(fieldId))
                            {
                                String listName = lookupsListMapping[fieldId];
                                SPList list = GetListForLookup(listName, web);
                                reader.MoveToContent();
                                XmlDocument doc = new XmlDocument();
                                String fieldElement = reader.ReadOuterXml();
                                doc.LoadXml(fieldElement);
                                XPathNavigator navigator = doc.DocumentElement.CreateNavigator();
                                navigator.CreateAttribute("", "List", "", list.ID.ToString());

                                SPFieldLookup field = (SPFieldLookup)web.Fields[new Guid(fieldId)];

                                AddWebIdAttribute(web, doc);
                                field.SchemaXml = RemoveXmlnsAttribute(doc.OuterXml);

                                field.Update(true);
                                isReading = false;
                                continue;
                            }
                        }
                    }
                    isReading = true;
                }
            }
        }

        public static SPList GetListForLookup(string listName, SPWeb web)
        {
            SPList list;
            try
            {
                list = web.Lists[listName];
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(
                    String.Format("List with name {0} does not exist", listName), ex);
            }
            return list;
        }

        private static XmlDocument GetXmlDocument(SPFeatureDefinition definition, String path, CultureInfo info)
        {
            return (XmlDocument)(Type.GetType(SPXmlDocCacheAssembly).InvokeMember("GetLocalizedXmlDocument",
                BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Static,
                null, null, new object[] { definition, GetRelativePath(path, definition.RootDirectory), info }));
        }

        private static String GetRelativePath(String path, String rootFolder)
        {
            // If we already have relative path we doesn't cut it
            if (path.IndexOf("..") == 0)
            {
                return path;
            }
            String fileName = Path.GetFileName(path);//??
            String[] folders = path.Replace(rootFolder, "").Split(new char[] { '\\' });
            String relativeFilePath = fileName;
            if (!String.IsNullOrEmpty(folders[folders.Length - 2]))
            {
                relativeFilePath = String.Format("{0}\\{1}", folders[folders.Length - 2], fileName);
            }
            return relativeFilePath;
        }
    }
}
