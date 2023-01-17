using System.Linq.Expressions;
using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;

namespace lab_dotnet.Services.Implementation;

public class PageService<T, U> : IPageService<T, U> where T : IBaseEntity
{
    private readonly IMapper mapper;

    public PageService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public PageModel<U> CreatePage<TKey>(IQueryable<T> elems, int limit, int offset, Expression<Func<T, TKey>> comparator)
    {
        int totalCount = elems.Count();
        var chunk = elems.OrderBy(comparator).Skip(offset).Take(limit);
        return new PageModel<U>(
            chunk.Select(x => mapper.Map<U>(x)),
            totalCount
        );
    }
}