using FluentValidation;

namespace Tech_Inventory.Application.Features.BoxFeature.CreateBox;

public class CreateBoxValidator : AbstractValidator<CreateBoxRequest>
{
    public CreateBoxValidator()
    {
        RuleFor(x => x.TypeId).NotNull();
    }
}
