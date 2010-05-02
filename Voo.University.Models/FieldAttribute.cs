using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voo.University.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        public Guid ID { get; set; }

        public String Name { get; set; }

        public FieldAttribute(String id, String name)
        {
            ID = new Guid(id);
            Name = name;
        }
    }
}
