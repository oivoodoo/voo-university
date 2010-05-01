using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Voo.University.Models.Repositories
{
    /// <summary>
    /// Class implements basic groups access repository.
    /// </summary>
    public class GroupsRepository : Repository<GroupsRepository>
    {
        protected GroupsRepository(SPSite site)
            : base(site)
        {
        }

        protected override String ListName
        {
            get
            {
                return RepositoryConstants.ListNames.Groups;
            }
        }

        public Group GetGroupByStudentId(int studentId)
        {
            return null;
        }
    }
}
