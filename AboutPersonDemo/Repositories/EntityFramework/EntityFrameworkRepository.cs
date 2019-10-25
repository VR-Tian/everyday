using Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories.EntityFramework
{
    /// <summary>
    /// EF实现的仓储
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
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

        protected override IEnumerable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = repositoryContext.Context.Set<TAggregateRoot>().
                   Where(specification.GetExpression());
            if (sortPredicate != null)
            {
                query = query.OrderBy(sortPredicate);
            }
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    return query.OrderBy(sortPredicate.Compile()).ToList();
                case SortOrder.Descending:
                    return query.OrderByDescending(sortPredicate.Compile()).ToList();
            }
            return query;
        }
    }
}
