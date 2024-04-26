using FluentValidation;

namespace Tech_Inventory.Application.Features.RackFeature.CreateRack;

public class CreateRackValidator : AbstractValidator<CreateRackRequest>
{
    public CreateRackValidator()
    {
    }
}
