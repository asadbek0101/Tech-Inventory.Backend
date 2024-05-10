using FluentValidation;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.UpdateAkumalator;

public class UpdateAkumalatorValidator : AbstractValidator<UpdateAkumalatorRequest>
{
    public UpdateAkumalatorValidator()
    {
        RuleFor(x => x.Count).NotEmpty();
    }
}
