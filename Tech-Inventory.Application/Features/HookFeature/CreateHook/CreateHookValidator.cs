using FluentValidation;

namespace Tech_Inventory.Application.Features.HookFeature.CreateHook;

public class CreateHookValidator : AbstractValidator<CreateHookRequest>
{
    public CreateHookValidator()
    {
        RuleFor(x => x.Count).NotEmpty();
    }
}
