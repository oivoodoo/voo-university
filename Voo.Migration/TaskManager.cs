using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Voo.Migration
{
    /// <summary>
    /// Class implements task manager for update tasks.
    /// If you wanna to write new update build you have to change last version in the 
    /// app.config(and add all previous major versions with max minor number) and create 
    /// new namespace with name same as version(for example: v1_0). Then write in this namespace
    /// classes that's have to derived of Task abstract class and implement Run method.
    /// </summary>
    public class TaskManager
    {
        private const String NamespaceTemplate = "IEFS.Update.Versions.{0}";

        public void RunTasks()
        {
            var site = new Site(ConfigurationSettings.AppSettings[Constants.SiteConfigurationKey]);
            var versions = ConfigurationSettings.AppSettings[Constants.VersionsConfigurationKey].Split(new[] { ';' }).Select(v => new Version(v)).OrderBy(v => v.Major).ToList();
            var firstVersion = versions.Where(v => v.Major == site.CurrentVersion.Major).First();
            int index = versions.IndexOf(firstVersion);
            var types = Assembly.GetExecutingAssembly().GetTypes();

            for (int i = index; i < versions.Count; i++)
            {
                int minorIndex = (i == index) ? site.CurrentVersion.Minor + 1 : 0;
                for(int j = minorIndex; j <= versions[i].Minor; j++)
                {
                    String taskNamespace = String.Format("v{0}_{1}", i, j);
                    var tasks = types.Where(t => t.Namespace == String.Format(NamespaceTemplate, taskNamespace)).
                                      Where(t => t.IsSubclassOf(typeof(Task))).
                                      ToList();
                    UpdateSite(site, tasks);
                }
            }

            UpdateSiteVersion(site, versions.Last());
        }

        private static void UpdateSiteVersion(Site site, Version lastVersion)
        {
            site.CurrentVersion = lastVersion;
            site.Update();
        }

        private static void UpdateSite(Site site, IEnumerable<Type> tasks)
        {
            foreach (var t in tasks)
            {
                ConstructorInfo constructor = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod).FirstOrDefault();
                var task = (Task)constructor.Invoke(new object[]{site});
                task.Run();
            }
        }
    }
}