using FluentValidation;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.CreateMountingBox;

public class CreateMountingBoxValidator : AbstractValidator<CreateMountingBoxRequest>
{
    public CreateMountingBoxValidator()
    {
        RuleFor(x =>x.Count).NotEmpty();   
    }
}
