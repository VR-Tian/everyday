using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories.EntityFramework
{
    public class EntityFrameworkRepository<TAggregateRoot> : BaseRepository<TAggregateRoot>
        where TAggregateRoot:class
    {
        #region Private Fields
        private readonly EntityFrameworkRepositoryContext repositoryContext;
        #endregion

        public EntityFrameworkRepository(EntityFrameworkRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            this.repositoryContext.RegisterNew(aggregateRoot);
        }
    }
}
