namespace WeTicket.Application.Shared.Queries;

public class GetByIdQuery<TResult> : IQuery<TResult>
{
    public Guid Id { get; set; }
}