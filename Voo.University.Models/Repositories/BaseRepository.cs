using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Voo.University.Models.Repositories
{
    public class BaseRepository
    {
        private SPList _list;
        protected String _listName;

        protected virtual String ListName
        {
            get { return _listName; } 
        }

        protected SPSite Site { get; set; }

        public BaseRepository(SPSite site)
        {
            Site = site;
        }

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

    }
}
