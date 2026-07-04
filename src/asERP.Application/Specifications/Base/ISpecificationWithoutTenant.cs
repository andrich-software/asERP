using System.Linq.Expressions;
using asERP.Domain.Entities.Common;

namespace asERP.Application.Specifications.Base;

public interface ISpecificationWithoutTenant<T> where T : class, IBaseEntityWithoutTenant
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
    Expression<Func<T, bool>> And(Expression<Func<T, bool>> query);
    Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query);
}