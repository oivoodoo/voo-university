using System;

namespace Voo.Migration
{
    /// <summary>
    /// Class implements general model of task for updating production server
    /// from last minor version to maximum number of version.
    /// </summary>
    public abstract class Task
    {
        protected Task(Site site)
        {
            Site = site;
        }

        protected bool IsValid()
        {
            return !String.IsNullOrEmpty(Site.SiteUrl);
        }

        protected Site Site { get; set; }

        public abstract void Run();
    }
}