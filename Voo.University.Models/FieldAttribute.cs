using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voo.University.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldAttribute : Attribute
    {
        public String ID { get; set; }

        public String Name { get; set; }
    }
}
