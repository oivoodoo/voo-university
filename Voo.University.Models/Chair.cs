using System.Collections.Generic;

namespace Voo.University.Models
{
    /// <summary>
    /// Class implements chair for the university.
    /// </summary>
    [ContentType("0x01")]
    public class Chair
    {
        public string Name { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Tutor> Tutors { get; set; }
    }
}
