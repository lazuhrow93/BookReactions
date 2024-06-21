using System.Linq.Expressions;

namespace Chronicle.Services.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeString { get; } = new List<string>();

        protected virtual void AddInclude(Expression<Func<T, object>> toInclude)
        {
            Includes.Add(toInclude);
        }

        protected virtual void AddInclude(string include)
        {
            IncludeString.Add(include);
        }
    }
}
