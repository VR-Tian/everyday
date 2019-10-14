using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications
{
    public interface ICompositeSpecification<T>: ISpecification<T>
    {
        /// <summary>
        /// Gets the left side of the specification.
        /// </summary>
        ISpecification<T> Left { get; }
        /// <summary>
        /// Gets the right side of the specification.
        /// </summary>
        ISpecification<T> Right { get; }
    }
}
