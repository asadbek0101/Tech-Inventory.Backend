using FluentValidation;

namespace Tech_Inventory.Application.Features.CounterFeature.CreateCounter;

public class CreateCounterValidator : AbstractValidator<CreateCounterRequest>
{
    public CreateCounterValidator()
    {
        RuleFor(x=>x.ModelId).NotEmpty();
    }
}
