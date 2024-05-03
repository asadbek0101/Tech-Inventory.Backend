using FluentValidation;

namespace Tech_Inventory.Application.Features.ServerFeature.UpdateServer;

public class UpdateServerValidator : AbstractValidator<UpdateServerRequest>
{
    public UpdateServerValidator()
    {
        RuleFor(x => x.Ip).NotEmpty();
    }
}
