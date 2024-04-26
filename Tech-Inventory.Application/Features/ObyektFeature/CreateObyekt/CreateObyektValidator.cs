using FluentValidation;

namespace Tech_Inventory.Application.Features.ObyektFeature.CreateObyekt;

public class CreateObyektValidator : AbstractValidator<CreateObyektRequest>
{
    public CreateObyektValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
