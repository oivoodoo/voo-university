using System.Collections.Generic;

namespace Voo.University.Models
{
    public class University
    {
        public string Address { get; set; }
        public string Name { get; set; }

        public List<Chair> Chairs { get; set; }
    }
}
