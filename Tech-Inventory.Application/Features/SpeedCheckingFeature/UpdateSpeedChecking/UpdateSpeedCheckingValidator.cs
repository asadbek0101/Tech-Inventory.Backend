using FluentValidation;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.UpdateSpeedChecking;

public class UpdateSpeedCheckingValidator : AbstractValidator<UpdateSpeedCheckingRequest>
{
    public UpdateSpeedCheckingValidator()
    {
        RuleFor(x =>x.SerialNumber).NotEmpty();
    }
}
