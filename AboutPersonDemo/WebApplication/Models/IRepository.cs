using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        void DoAdd(TEntity entity);
        TEntity DoGetByKey(Guid id);
        IEnumerable<TEntity> DoGetAll(Expression<Func<TEntity, bool>> queryPredicate, Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder);
        void DoRemove(TEntity entity);
        void DoUpdate(TEntity entity);
    }
}
