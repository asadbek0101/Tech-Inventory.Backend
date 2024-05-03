using FluentValidation;

namespace Tech_Inventory.Application.Features.NailFeature.CreateNail;

public class CreateNailValidator : AbstractValidator<CreateNailRequest>
{
    public CreateNailValidator()
    {
        RuleFor(x => x.Weight).NotEmpty();
    }
}
