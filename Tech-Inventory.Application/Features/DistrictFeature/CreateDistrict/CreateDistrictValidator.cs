using FluentValidation;

namespace Tech_Inventory.Application.Features.DistrictFeature.CreateDistrict;

public class CreateDistrictValidator : AbstractValidator<CreateDistrictRequest>
{
    public CreateDistrictValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
