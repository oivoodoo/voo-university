using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.IO;

namespace Voo.University.Sharepoint
{
    /// <summary>
    /// Class implements receiver for fields lookup creation.
    /// </summary>
    public class LookupFieldsFeatureReciever : SPFeatureReceiver
    {
        private const String FileWithFields = "FieldsPath";

        protected virtual SPWeb GetWebForLookup(SPFeatureReceiverProperties properties)
        {
            if (properties.Feature.Parent is SPSite)
            {
                return ((SPSite)properties.Feature.Parent).RootWeb;
            }

            if (properties.Feature.Parent is SPWeb)
            {
                return (SPWeb)properties.Feature.Parent;
            }

            throw new NotSupportedException("Feature reciever supports only Site and Web scopes");
        }

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            // nothing to do
        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
            // nothing to do
        }

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            String filePath = Path.Combine(properties.Definition.RootDirectory, properties.Feature.Properties[FileWithFields].Value);
            (new LookupReciever()).CreateLookup(properties, GetWebForLookup(properties), filePath);
        }



        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            // nothing to do
        }
    }

}
