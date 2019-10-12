using Microsoft.VisualStudio.TestTools.UnitTesting;
using Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories.Tests
{
    [TestClass()]
    public class MY7WRepositoryTests
    {
        [TestMethod()]
        public void AddMY7WTest()
        {
            MY7WRepository mY7WRepository = new MY7WRepository(new EntityFramework.EntityFrameworkRepositoryContext());
            mY7WRepository.AddMY7W();
            Assert.IsTrue(true);
        }
    }
}