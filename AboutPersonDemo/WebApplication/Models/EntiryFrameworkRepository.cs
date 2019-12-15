using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    internal class EntiryFrameworkRepository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        #region Private Fields
        private readonly DbContext objContext;
        
        //private readonly ObjectContext objContext;
        private readonly string entitySetName;
        #endregion

        public EntiryFrameworkRepository(DbContext objContext)
        {
            this.objContext = objContext;
        }

        public void DoAdd(TAggregateRoot entity)
        {
            objContext.Set<TAggregateRoot>().Add(entity);
        }

        public TAggregateRoot DoGetByKey(Guid id)
        {
            return this.objContext.Set<TAggregateRoot>().Find(id);
        }

        public void DoRemove(TAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void DoUpdate(TAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, bool>> queryPredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = objContext.Set<TAggregateRoot>().Where(queryPredicate);
            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return query.OrderBy(sortPredicate).ToList();
                    case SortOrder.Descending:
                        return query.OrderByDescending(sortPredicate).ToList();
                    default:
                        break;
                }
            }
            return query.ToList();
        }
    }
}
