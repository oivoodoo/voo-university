using Voo.University.Models.Repositories;

namespace Voo.University.Models
{
    /// <summary>
    /// Class implements base model for students.
    /// </summary>
    [ContentType("0x01")]
    public class Student : Human
    {
        private Group _group;

        public Group Group 
        {
            get
            {
                if (_group == null)
                {
                    using (GroupsRepository repository = GroupsRepository.Create(Site))
                    {
                        _group = repository.GetGroupByStudentId(Id);
                    }
                }
                return _group;
            }
        }
    }
}
