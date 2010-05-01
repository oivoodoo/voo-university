using System.Collections.Generic;
using System;
using Voo.University.Models.Repositories;

namespace Voo.University.Models
{
    [ContentType("0x01")]
    public class Group : DataObject
    {
        private List<Student> _students = null;

        public String Name { get; set; }

        public List<Student> Students 
        {
            get
            {
                if (_students == null)
                {
                    using (StudentsRepository repository = StudentsRepository.Create(Site))
                    {
                        _students = repository.GetStudentsByGroupId(Id);
                    }
                }
                return _students;
            }
        }
    }
}
