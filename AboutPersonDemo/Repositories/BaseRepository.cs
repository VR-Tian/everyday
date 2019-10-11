using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    /// <summary>
    //  Class base for repositories
    /// </summary>
    public abstract class BaseRepository<TAggregateRoot> : IBaseRepository<TAggregateRoot>
    {
        #region MyRegion

        /// <summary>
        /// Adds an aggregate root to the repository.
        /// </summary>
        /// <param name="aggregateRoot">The aggregate root to be added to the repository.</param>
        /// <remarks>
        /// 交由派生类具体实现
        /// </remarks>
        protected abstract void DoAdd(TAggregateRoot aggregateRoot);

        #endregion

        #region IRepository<TAggregateRoot> Members

        public void Add(TAggregateRoot aggregateRoot)
        {
            this.DoAdd(aggregateRoot);
        }

        public bool Exists(ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot Find(ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot Find(ISpecification<TAggregateRoot> specification, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot Get(ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot Get(ISpecification<TAggregateRoot> specification, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot GetByKey(string key)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
