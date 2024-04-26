using FluentValidation;

namespace Tech_Inventory.Application.Features.StabilizerFeature.UpdateStabilizer;

public class UpdateStabilizerValidator : AbstractValidator<UpdateStabilizerRequest>
{
    public UpdateStabilizerValidator()
    {
        RuleFor(x=>x.Name).NotEmpty();
    }
}
