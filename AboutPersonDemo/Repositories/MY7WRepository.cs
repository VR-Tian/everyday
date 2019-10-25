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
        }

        public IEnumerable<My7W> DoFindAll(My7W my7W)
        {
            ISpecification<My7W> spec = Specification<My7W>.Eval(o => (o as My7W).Name.Contains(my7W.Name) && o.Id == 1);
            var queryModel = DoFindAll(spec);
            return queryModel;
        }
    }
}
