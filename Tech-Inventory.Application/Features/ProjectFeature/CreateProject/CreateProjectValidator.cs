using FluentValidation;

namespace Tech_Inventory.Application.Features.ProjectFeature.CreateProject;

public class CreateProjectValidator : AbstractValidator<CreateProjectRequest>
{
    public CreateProjectValidator()
    {
        RuleFor(x=>x.Name).NotEmpty();
    }
}
