using FluentValidation;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.CreateObjectClassType;

public class CreateObjectClassTypeValidator : AbstractValidator<CreateObjectClassTypeRequest>
{
    public CreateObjectClassTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
