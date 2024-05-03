using FluentValidation;

namespace Tech_Inventory.Application.Features.RibbonFeature.CreateRibbon;

public class CreateRibbonValidator : AbstractValidator<CreateRibbonRequest>
{
    public CreateRibbonValidator()
    {
        RuleFor(x => x.Meter).NotEmpty();
    }
}
