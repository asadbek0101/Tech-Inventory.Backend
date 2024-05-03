using FluentValidation;

namespace Tech_Inventory.Application.Features.ServerFeature.CreateServer;

public class CreateServerValidator : AbstractValidator<CreateServerRequest>
{
    public CreateServerValidator()
    {
        RuleFor(x=>x.Ip).NotEmpty();
    }
}
