using System.Collections.Generic;
using System;
using Voo.University.Models.Repositories;
using Microsoft.SharePoint;

namespace Voo.University.Models
{
    [ContentType("0x0100C38E2ADB319D4A93BBFDE97826C4CB2C")]
    public class Group : DataObject
    {
        private List<Student> _students = null;
        private Course _course = null;

        [Field("{FA564E0F-0C70-4AB9-B863-0177E6DDD247}", "Title")]
        public String Title { get; set; }

        public Group()
            : base()
        {
        }

        public Group(SPListItem item) 
            : base(item)
        {
        }

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

        public Course Course
        {
            get
            {
                if (_course == null)
                {
                    // TODO: Make repository for course retrievement.
                }
                return _course;
            }
        }
    }
}
