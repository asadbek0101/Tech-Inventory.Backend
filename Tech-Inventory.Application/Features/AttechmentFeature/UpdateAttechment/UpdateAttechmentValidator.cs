using FluentValidation;

namespace Tech_Inventory.Application.Features.AttechmentFeature.UpdateAttechment;

public class UpdateAttechmentValidator : AbstractValidator<UpdateAttechmentRequest>
{
    public UpdateAttechmentValidator()
    {
        RuleFor(x => x.FileName).NotEmpty();
    }
}
