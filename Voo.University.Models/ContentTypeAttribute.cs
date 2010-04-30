using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voo.University.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ContentTypeAttribute : Attribute
    {
        public String ContentTypeID { get; set; }

        public ContentTypeAttribute(String contentTypeID)
        { 
            ContentTypeID = contentTypeID;
        }
    }
}
