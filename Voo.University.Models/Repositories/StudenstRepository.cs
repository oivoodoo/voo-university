using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Voo.University.Models.Repositories
{
    /// <summary>
    /// Class implements basic access layer to students list.
    /// </summary>
    public class StudentsRepository : Repository<StudentsRepository>
    {
        protected StudentsRepository(SPSite site)
            : base(site)
        {
        }


        protected override string ListName
        {
            get
            {
                return RepositoryConstants.ListNames.Students;
            }
        }

        public List<Student> GetStudentsByGroupId(int groupId)
        {
            SPQuery query = new SPQuery
            {
                Query = String.Format(@"")
            };
            return new List<Student>(); // replace with generated models.
        }
    }
}
