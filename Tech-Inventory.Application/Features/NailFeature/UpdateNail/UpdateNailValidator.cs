using FluentValidation;

namespace Tech_Inventory.Application.Features.NailFeature.UpdateNail;

public class UpdateNailValidator : AbstractValidator<UpdateNailRequest>
{
    public UpdateNailValidator()
    {
        RuleFor(x=>x.Weight).NotEmpty();
    }
}
