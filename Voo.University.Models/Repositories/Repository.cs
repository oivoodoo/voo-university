using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Voo.University.Models.Repositories
{
    /// <summary>
    /// Class implements general repository model.
    /// </summary>
    public class Repository<T> : IDisposable
    {
        private static object _sync = new object();
        protected static T _repository;
        private SPList _list;

        protected abstract String ListName { get; set; }

        protected abstract T NewInstance(SPSite site);

        protected SPSite Site { get; set; }

        protected SPList List
        {
            get
            {
                try
                {
                    if (_list == null)
                    {
                        if (Site != null)
                        {
                            _list = Site.RootWeb.Lists[ListName];
                        }
                    }
                }
                catch (Exception ex) 
                {
                    // Adding loging.
                }
                return _list;
            }
        }

        public T Current
        {
            get
            {
                return _repository;
            }
        }

        public static T Create(SPSite site)
        {
            if (_repository == null)
            {
                lock (_sync)
                {
                    if (_repository == null)
                    {
                        _repository = NewInstance(site);
                    }
                }
            }
            return _repository;
        }

        public void Dispose()
        {
            _repository = default(T);
        }
    }
}
