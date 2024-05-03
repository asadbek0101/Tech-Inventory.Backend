using FluentValidation;

namespace Tech_Inventory.Application.Features.FreezerFeature.CreateFreezer;

public class CreateFreezerValidator : AbstractValidator<CreateFreezerRequest>
{
    public CreateFreezerValidator()
    {
        RuleFor(x => x.Count).NotEmpty();
    }
}
