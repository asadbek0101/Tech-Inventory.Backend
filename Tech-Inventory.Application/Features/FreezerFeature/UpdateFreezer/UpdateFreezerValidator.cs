using FluentValidation;

namespace Tech_Inventory.Application.Features.FreezerFeature.UpdateFreezer;

public class UpdateFreezerValidator : AbstractValidator<UpdateFreezerRequest>
{
    public UpdateFreezerValidator()
    {
        RuleFor(x=>x.Count).NotEmpty();
    }
}
