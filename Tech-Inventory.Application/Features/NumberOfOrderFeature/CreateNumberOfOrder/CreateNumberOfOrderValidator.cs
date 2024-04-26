using FluentValidation;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.CreateNumberOfOrder;

public class CreateNumberOfOrderValidator : AbstractValidator<CreateNumberOfOrderRequest>
{
    public CreateNumberOfOrderValidator()
    {
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}
