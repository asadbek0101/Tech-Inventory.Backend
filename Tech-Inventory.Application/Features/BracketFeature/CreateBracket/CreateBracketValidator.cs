using FluentValidation;

namespace Tech_Inventory.Application.Features.BracketFeature.CreateBracket;

public class CreateBracketValidator : AbstractValidator<CreateBracketRequest>
{
    public CreateBracketValidator()
    {
        RuleFor(x=>x.ModelId).NotEmpty();
    }
}
