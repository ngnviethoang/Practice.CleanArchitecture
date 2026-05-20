namespace MiniStore.Application.Shared.Queries;

public class PagedQuery<TResult> : IQuery<IEnumerable<TResult>>
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}