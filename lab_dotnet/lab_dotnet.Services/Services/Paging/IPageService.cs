using System.Linq.Expressions;
using lab_dotnet.Entities.Models;
using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Abstract;

public interface IPageService<T, U> where T : IBaseEntity
{
    PageModel<U> CreatePage<TKey>(IQueryable<T> elems, int limit, int offset, Expression<Func<T, TKey>> comparator);
}