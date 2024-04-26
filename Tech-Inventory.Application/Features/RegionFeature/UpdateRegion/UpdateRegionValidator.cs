using FluentValidation;

namespace Tech_Inventory.Application.Features.RegionFeature.UpdateRegion;

public class UpdateRegionValidator : AbstractValidator<UpdateRegionRequest>
{
    public UpdateRegionValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
