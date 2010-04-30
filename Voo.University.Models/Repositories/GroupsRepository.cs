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
        protected override String ListName
        {
            get
            {
                return RepositoryConstants.ListNames.Groups;
            }
        }

        protected static override GroupsRepository NewInstance(SPSite site)
        {
            return new GroupsRepository { Site = site };
        }
    }
}
