using FluentValidation;

namespace Tech_Inventory.Application.Features.AttechmentFeature.CreateAttechment;

public class CreateAttechmentValidator : AbstractValidator<CreateAttechmentRequest>
{
    public CreateAttechmentValidator()
    {
        RuleFor(x=>x.FileName).NotEmpty();
    }
}
