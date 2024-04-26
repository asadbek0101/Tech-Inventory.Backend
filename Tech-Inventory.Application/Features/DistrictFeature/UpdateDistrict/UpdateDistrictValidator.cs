using FluentValidation;

namespace Tech_Inventory.Application.Features.DistrictFeature.UpdateDistrict;

public class UpdateDistrictValidator : AbstractValidator<UpdateDistrictRequest>
{
    public UpdateDistrictValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
