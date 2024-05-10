using FluentValidation;

namespace Tech_Inventory.Application.Features.ShelfFeature.UpdateShelf;

public class UpdateShelfValidator : AbstractValidator<UpdateShelfRequest>
{
    public UpdateShelfValidator()
    {
        RuleFor(x=>x.Number).NotEmpty();
    }
}
