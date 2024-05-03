using FluentValidation;

namespace Tech_Inventory.Application.Features.ShellFeature.CreateShell;

public class CreateShellValidator : AbstractValidator<CreateShellRequest>
{
    public CreateShellValidator()
    {
        RuleFor(x=>x.Meter).NotEmpty();
    }
}
