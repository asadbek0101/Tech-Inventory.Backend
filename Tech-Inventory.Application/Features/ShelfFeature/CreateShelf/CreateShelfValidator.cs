using FluentValidation;

namespace Tech_Inventory.Application.Features.ShelfFeature.CreateShelf;

public class CreateShelfValidator : AbstractValidator<CreateShelfRequest>
{
    public CreateShelfValidator()
    {
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.SerialNumber).NotEmpty();
    }
}
