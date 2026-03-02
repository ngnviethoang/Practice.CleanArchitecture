namespace WeTicket.Application.Shared.Queries;

public class PagedQuery<TResult> : IQuery<TResult>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}