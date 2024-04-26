using FluentValidation;

namespace Tech_Inventory.Application.Features.CameraFeature.CreateCamera;

public class CreateCameraValidator : AbstractValidator<CreateCameraRequest>
{
    public CreateCameraValidator()
    {
    }
}
