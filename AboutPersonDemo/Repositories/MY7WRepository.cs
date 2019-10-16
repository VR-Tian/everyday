using Domain.Specifications;
using Respositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    /// <summary>
    /// 实现业务的仓储
    /// </summary>
    public class MY7WRepository: EntityFrameworkRepository<My7W>
    {
        public MY7WRepository(EntityFrameworkRepositoryContext repositoryContext) :base(repositoryContext)
        {

        }
        public void AddMY7W(My7W my7W)
        {
            Add(my7W);
            //DoFindAll(new );
        }
    }
}
