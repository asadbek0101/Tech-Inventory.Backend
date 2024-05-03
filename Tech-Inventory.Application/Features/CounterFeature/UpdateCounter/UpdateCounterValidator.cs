using FluentValidation;

namespace Tech_Inventory.Application.Features.CounterFeature.UpdateCounter;

public class UpdateCounterValidator : AbstractValidator<UpdateCounterRequest>
{
    public UpdateCounterValidator()
    {
        RuleFor(x=>x.ModelId).NotEmpty();
    }
}
