using FluentValidation;

namespace Tech_Inventory.Application.Features.SwitchFeature.UpdateSwitch;

public class UpdateSwitchValidator : AbstractValidator<UpdateSwitchRequest>
{
    public UpdateSwitchValidator()
    {
        RuleFor(x=>x.Name).NotEmpty();
    }
}
