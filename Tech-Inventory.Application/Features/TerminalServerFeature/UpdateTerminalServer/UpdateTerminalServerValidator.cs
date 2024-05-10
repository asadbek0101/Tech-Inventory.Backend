using FluentValidation;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.UpdateTerminalServer;

public class UpdateTerminalServerValidator : AbstractValidator<UpdateTerminalServerRequest>
{
    public UpdateTerminalServerValidator()
    {
        RuleFor(x => x.ModelId).NotEmpty();
    }
}
