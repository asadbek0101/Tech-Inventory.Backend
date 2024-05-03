using FluentValidation;

namespace Tech_Inventory.Application.Features.ObyektFeature.UpdateObyekt;

public class UpdateObyektValidator : AbstractValidator<UpdateObyektRequest>
{
    public UpdateObyektValidator()
    {
        RuleFor(x => x.NameAndAddress).NotEmpty();
    }
}
