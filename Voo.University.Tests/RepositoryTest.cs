using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voo.University.Models.Repositories;

namespace Voo.University.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void CreateStudentsRepository()
        {
            using (StudentsRepository repository = StudentsRepository.Create(null))
            {
                Assert.IsNotNull(repository.Current);
            }
        }

        [TestMethod]
        public void CreateGroupsRepository()
        {
            using (GroupsRepository repository = GroupsRepository.Create(null))
            {
                Assert.IsNotNull(repository.Current);
            }
        }
    }
}
