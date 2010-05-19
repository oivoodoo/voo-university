using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voo.University.Models
{
	[ContentType("0x010078E8FA8A0D8840E2B07B329A8BA87439")]
    public class Statement : DataObject
    {
		private Group _group;
		private Student _student;
		private Mark _mark;
		private Tutor _tutor;
		private TypeSubject _typeSubject;
		private Subject _subject;
	
		public Group Group
		{
			get
			{
				if (_group == null)
                {
                    using (GroupsRepository repository = GroupsRepository.Create(Site))
                    {
                        _group = repository.GetGroupByStatementId(Id);
                    }
                }
                return _group;
			}
		}
		
		public Student Student
		{
			get
			{
				if (_student == null)
                {
                    using (StudentsRepository repository = StudentsRepository.Create(Site))
                    {
                        _group = repository.GetGroupByStudentId(Id);
                    }
                }
                return _group;
			}
		}
		
		[Field("{BA635077-6C36-467F-9207-88D538D6CBAA}", "Date")]
		public DateTime Date
		{
			get;
			set;
		}
	
		[Field("{F2B93F10-AC75-4DE5-A24A-7FC5DD8EF3E5}", "Number")]
		public String Number
		{
			get;
			set;
		}
		
		[Field("{0396AAD3-A3E1-4390-BAB2-84CD833360D9}", "Comments")]
		public String Comments
		{
			get;
			set;
		}
    }
}
