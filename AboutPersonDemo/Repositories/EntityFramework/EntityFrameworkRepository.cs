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
    /// <typeparam name="T"></typeparam>
    public class EntityFrameworkRepository<T> : BaseRepository<T>
        where T:class
    {
        #region Private Fields
        private readonly EntityFrameworkRepositoryContext repositoryContext;
        #endregion

        public EntityFrameworkRepository(EntityFrameworkRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        protected override void DoAdd(T aggregateRoot)
        {
            this.repositoryContext.RegisterNew(aggregateRoot);
        }

        protected override IEnumerable<T> DoFindAll(ISpecification<T> specification)
        {
            return base.DoFindAll(specification);
        }

        protected override IEnumerable<T> DoFindAll(ISpecification<T> specification, System.Linq.Expressions.Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = repositoryContext.Context.Set<T>().
                   Where(specification.GetExpression());
            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return query.OrderBy(sortPredicate.Compile()).ToList();
                    case SortOrder.Descending:
                        return query.OrderByDescending(sortPredicate.Compile()).ToList();
                    default:
                        break;
                }
            }
            return query;
        }
    }
}
