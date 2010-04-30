using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Voo.University.Models
{
    /// <summary>
    /// Class implements 
    /// </summary>
    public class DataObject
    {
        public String Id { get; set; }
        protected SPListItem Item { get; set; }

        public DataObject(SPListItem item)
        {
            Item = item;
        }

        public DataObject() 
        {
        }
    }
}
