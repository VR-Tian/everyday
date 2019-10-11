using Microsoft.VisualStudio.TestTools.UnitTesting;
using Respositories;
using Respositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoriesTest
{
    class TestClass
    {
        [TestMethod]
        public void TestAddMY7W()
        {
            MY7WRepository mY7WRespository = new MY7WRepository(new EntityFrameworkRepositoryContext());
            mY7WRespository.AddMY7W();
            Assert.Fail();
        }
    }
}
