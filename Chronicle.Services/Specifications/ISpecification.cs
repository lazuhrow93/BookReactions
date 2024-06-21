using System.Linq;
using System.Linq.Expressions;

namespace Chronicle.Services.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeString { get; }
    }
}
