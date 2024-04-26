using FluentValidation;

namespace Tech_Inventory.Application.Features.SvetaforFeature.UpdateSvetafor;

public class UpdateSvetaforValidator : AbstractValidator<UpdateSvetaforRequest>
{
    public UpdateSvetaforValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
