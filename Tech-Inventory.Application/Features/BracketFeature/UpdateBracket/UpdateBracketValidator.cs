using FluentValidation;

namespace Tech_Inventory.Application.Features.BracketFeature.UpdateBracket;

public class UpdateBracketValidator : AbstractValidator<UpdateBracketRequest>
{
    public UpdateBracketValidator()
    {
        RuleFor(x => x.ModelId).NotEmpty();
    }
}