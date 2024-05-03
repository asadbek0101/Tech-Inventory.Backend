using FluentValidation;

namespace Tech_Inventory.Application.Features.ShellFeature.UpdateShell;

public class UpdateShellValidator : AbstractValidator<UpdateShellRequest>
{
    public UpdateShellValidator()
    {
        RuleFor(x => x.Meter).NotEmpty();
    }
}
