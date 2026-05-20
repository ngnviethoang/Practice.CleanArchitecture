namespace MiniStore.Application.Shared.Commands;

public class DeleteByIdCommand<TResult> : ICommand<TResult>
{
    public Guid Id { get; set; }
}