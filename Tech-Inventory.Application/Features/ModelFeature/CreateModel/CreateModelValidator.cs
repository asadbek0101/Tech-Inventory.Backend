using FluentValidation;

namespace Tech_Inventory.Application.Features.ModelFeature.CreateModel;

public class CreateModelValidator : AbstractValidator<CreateModelRequest>
{
    public CreateModelValidator()
    {
        RuleFor(x=> x.Name).NotEmpty();
        RuleFor(x=> x.Type).NotEmpty();
    }
}
