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
    public class MY7WRepository: EntityFrameworkRepository<UserInfo>
    {
        public MY7WRepository(EntityFrameworkRepositoryContext repositoryContext) :base(repositoryContext)
        {

        }
        public void AddMY7W(UserInfo my7W)
        {
            Add(my7W);
        }

        public IEnumerable<UserInfo> DoFindAll(UserInfo my7W)
        {
            ISpecification<UserInfo> spec = Specification<UserInfo>.Eval(o => (o as UserInfo).Name.Contains(my7W.Name));
            var queryModel = DoFindAll(spec, x => x.Id, System.Data.SqlClient.SortOrder.Ascending);
            return queryModel;
        }
    }
}
