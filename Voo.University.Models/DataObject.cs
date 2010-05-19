using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Reflection;

namespace Voo.University.Models
{
    /// <summary>
    /// Class implements 
    /// </summary>
    public class DataObject
    {
        protected int Id { get; set; }

        /// <summary>
        /// We have to use this objects only we initialized dataobject via SPListItem.
        /// </summary>
        protected SPListItem Item { get; set; }
        protected SPSite Site { get; set; }
        protected SPWeb Web { get; set; }

        public DataObject(SPListItem item)
        {
            Id = item.ID;
            Item = item;
            Web = item.ParentList.ParentWeb;
            Site = Web.Site;

            RetrieveAttributes();
        }

        public DataObject()
        {
        }

        private void RetrieveAttributes()
        {
            foreach (var property in GetType().GetProperties())
            {
                foreach (var attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is FieldAttribute)
                    {
                        FieldAttribute fieldAttribute = attribute as FieldAttribute;
                        property.SetValue(this, Item[fieldAttribute.ID], null);
                    }
                }
            }
        }

        // TODO: Add saving methods as generic.
    }
}
