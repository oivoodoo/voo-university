using System;
using System.Collections.Specialized;
using System.Configuration;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace Voo.Migration
{
    /// <summary>
    /// Class contains general settings for sharepoint site.
    /// </summary>
    public class Site
    {
        private SPSite _application;

        public Site(string siteUrl)
        {
            SiteUrl = siteUrl;
            CurrentVersion = GetVersion();
        }

        public string SiteUrl { get; set; }
        public Version CurrentVersion { get; internal set; }

        public SPSite Application
        {
            get
            {
                if (_application == null)
                {
                    if (!String.IsNullOrEmpty(SiteUrl))
                    {
                        _application = new SPSite(SiteUrl);
                    }
                }
                return _application;
            }
        }

        public void Update()
        {
            SaveVersionProperty(CurrentVersion);
            Application.RootWeb.Properties.Update();
        }

        private Version GetVersion()
        {
            String major = GetOrCreateProperty(Application.RootWeb.Properties, ConfigurationSettings.AppSettings[Constants.ApplicationVersionMajorConfigurationKey]);
            String minor = GetOrCreateProperty(Application.RootWeb.Properties, ConfigurationSettings.AppSettings[Constants.ApplicationVersionMinorConfigurationKey]);
            return new Version(Convert.ToInt32(major), Convert.ToInt32(minor));
        }

        private static String GetOrCreateProperty(StringDictionary bag, String key)
        {
            if (!bag.ContainsKey(key))
            {
                bag.Add(key, Constants.DefaultVersionMinor);
            }
            return bag[key];
        }

        private void SaveVersionProperty(Version version)
        {
            Application.RootWeb.Properties[
                ConfigurationSettings.AppSettings[
                    Constants.ApplicationVersionMajorConfigurationKey]] = version.Major.ToString();
            Application.RootWeb.Properties[
                ConfigurationSettings.AppSettings[
                    Constants.ApplicationVersionMinorConfigurationKey]] = version.Minor.ToString();
            Application.RootWeb.Update();
        }
    }
}