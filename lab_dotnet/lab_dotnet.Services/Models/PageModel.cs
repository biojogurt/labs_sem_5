namespace lab_dotnet.Services.Models;

public class PageModel<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }

    public PageModel(IEnumerable<T> items, int totalCount)
    {
        Items = items;
        TotalCount = totalCount;
    }
}