using FluentValidation;

namespace Tech_Inventory.Application.Features.HookFeature.UpdateHook;

public class UpdateHookValidator : AbstractValidator<UpdateHookRequest>
{
    public UpdateHookValidator()
    {
        RuleFor(x=>x.Count).NotEmpty();
    }
}
