using FluentValidation;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.CreateGlue;

public class CreateGlueValidator : AbstractValidator<CreateGlueRequest>
{
    public CreateGlueValidator()
    {
        RuleFor(x => x.CountOfCrate).NotEmpty();
    }
}
