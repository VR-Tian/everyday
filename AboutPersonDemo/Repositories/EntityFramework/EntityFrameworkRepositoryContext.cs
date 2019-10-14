namespace Respositories.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// EF的Repository上下文
    /// </summary>
    /// <remarks>
    /// 泛型类型和泛型函数的区别体现
    /// </remarks>
    public class EntityFrameworkRepositoryContext
    {
        private readonly ThreadLocal<My7WDbContext> localCtx = new ThreadLocal<My7WDbContext>(() => new My7WDbContext());

        /// <summary>
        /// 线程唯一Db上下文
        /// </summary>
        public DbContext Context
        {
            get { return localCtx.Value; }
        }

        public void RegisterNew<TAggregateRoot>(TAggregateRoot obj) where TAggregateRoot: class
        {
            localCtx.Value.Entry<TAggregateRoot>(obj).State = System.Data.Entity.EntityState.Added;
            localCtx.Value.SaveChanges();
        }
    }
}