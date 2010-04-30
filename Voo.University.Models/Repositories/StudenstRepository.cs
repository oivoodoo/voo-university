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
        protected override string ListName
        {
            get
            {
                return RepositoryConstants.ListNames.Students;
            }
        }

        protected static override StudentsRepository NewInstance(SPSite site)
        {
            return new StudentsRepository { Site = site };
        }

        public List<Student> GetStudentsByGroupId(String groupId)
        {
            SPQuery query = new SPQuery
            {
                Query = String.Format(@"")
            };
            return new List<Student>(); // replace with generated models.
        }
    }
}
