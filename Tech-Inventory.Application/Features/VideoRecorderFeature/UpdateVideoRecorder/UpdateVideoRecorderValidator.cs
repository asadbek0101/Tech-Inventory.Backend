using FluentValidation;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.UpdateVideoRecorder;
public class UpdateVideoRecorderValidator : AbstractValidator<UpdateVideoRecorderRequest>
{
    public UpdateVideoRecorderValidator()
    {
        RuleFor(x => x.ModelId).NotEmpty();
    }
}
