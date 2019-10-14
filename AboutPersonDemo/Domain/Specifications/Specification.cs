using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> AndNot(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }

        public abstract Expression<Func<T, bool>> GetExpression();

        public bool IsSatisfiedBy(T obj)
        {
            return this.GetExpression().Compile()(obj);
        }

        public ISpecification<T> Not()
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
