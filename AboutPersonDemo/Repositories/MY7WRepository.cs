using Respositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public class MY7WRepository: EntityFrameworkRepository<My7W>
    {
        public MY7WRepository(EntityFrameworkRepositoryContext repositoryContext) :base(repositoryContext)
        {

        }
        public void AddMY7W()
        {
            My7W mY7W = new My7W() { Id = 1, Address = "马路", Name = "里斯" };
            DoAdd(mY7W);
        }
    }
}
