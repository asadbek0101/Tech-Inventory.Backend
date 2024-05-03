using FluentValidation;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.CreateVideoRecorder;

public class CreateVideoRecorderValidator : AbstractValidator<CreateVideoRecorderRequest>
{
    public CreateVideoRecorderValidator()
    {
        RuleFor(x => x.ModelId).NotEmpty();
    }
}
