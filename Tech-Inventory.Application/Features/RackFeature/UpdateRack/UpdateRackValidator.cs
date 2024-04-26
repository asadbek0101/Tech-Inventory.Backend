using FluentValidation;

namespace Tech_Inventory.Application.Features.RackFeature.UpdateRack;

public class UpdateRackValidator : AbstractValidator<UpdateRackRequest>
{
    public UpdateRackValidator()
    {
        RuleFor(x=>x.Name).NotEmpty();
    }
}
