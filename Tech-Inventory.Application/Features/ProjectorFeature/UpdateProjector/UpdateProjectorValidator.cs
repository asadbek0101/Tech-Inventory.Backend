using FluentValidation;

namespace Tech_Inventory.Application.Features.ProjectorFeature.UpdateProjector;

public class UpdateProjectorValidator : AbstractValidator<UpdateProjectorRequest>
{
    public UpdateProjectorValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
