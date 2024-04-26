using FluentValidation;

namespace Tech_Inventory.Application.Features.RegionFeature.CreateRegion;

public class CreateRegionValidator : AbstractValidator<CreateRegionRequest>
{
    public CreateRegionValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
