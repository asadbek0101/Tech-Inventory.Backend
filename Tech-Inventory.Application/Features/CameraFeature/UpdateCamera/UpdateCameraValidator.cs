using FluentValidation;

namespace Tech_Inventory.Application.Features.CameraFeature.UpdateCamera;

public class UpdateCameraValidator : AbstractValidator<UpdateCameraRequest>
{
    public UpdateCameraValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
