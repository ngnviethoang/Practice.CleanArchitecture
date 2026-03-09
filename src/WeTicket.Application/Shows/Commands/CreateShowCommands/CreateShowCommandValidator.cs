using FluentValidation;

namespace WeTicket.Application.Shows.Commands.CreateShowCommands;

public class CreateShowCommandValidator : AbstractValidator<CreateShowCommand>
{
    public CreateShowCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Location)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.StartTime)
            .NotEmpty();

        RuleFor(x => x.EndTime)
            .NotEmpty()
            .GreaterThan(x => x.StartTime)
            .WithMessage("EndTime must be greater than StartTime");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}