using FluentValidation;

namespace Tech_Inventory.Application.Features.CableFeature.UpdateCabel;

public class UpdateCabelValidator : AbstractValidator<UpdateCabelRequest>
{
    public UpdateCabelValidator()
    {
        RuleFor(x => x.Meter).NotEmpty();
    }
}
