using FluentValidation;

namespace Tech_Inventory.Application.Features.RibbonFeature.UpdateRibbon;

public class UpdateRibbonValidator : AbstractValidator<UpdateRibbonRequest>
{
    public UpdateRibbonValidator()
    {
        RuleFor(x => x.Meter).NotEmpty();
    }
}
