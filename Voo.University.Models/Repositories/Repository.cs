using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Reflection;

namespace Voo.University.Models.Repositories
{
    /// <summary>
    /// Class implements general repository model. As template pattern we are using 
    /// 'Generic Singleton' with one modification for implemeting this singleton as 
    /// base class.
    /// </summary>
    public class Repository<T> : BaseRepository, IDisposable where T : class
    {
        private static object _sync = new object();
        protected static T _repository;

        protected Repository(SPSite site) : base(site)
        {
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
                        _repository = typeof(T).InvokeMember(typeof(T).Name,
                                                            BindingFlags.CreateInstance |
                                                            BindingFlags.Instance |
                                                            BindingFlags.Public |
                                                            BindingFlags.NonPublic,
                                                            null, null, new []{ site }) as T;
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
