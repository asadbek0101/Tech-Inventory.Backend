using FluentValidation;

namespace Tech_Inventory.Application.Features.BoxFeature.UpdateBox;

public class UpdateBoxValidator : AbstractValidator<UpdateBoxRequest>
{
    public UpdateBoxValidator()
    {
        RuleFor(x => x.TypeId).NotEmpty();
    }
}
