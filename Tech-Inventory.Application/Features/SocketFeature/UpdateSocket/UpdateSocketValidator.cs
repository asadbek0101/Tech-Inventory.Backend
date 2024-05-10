using FluentValidation;

namespace Tech_Inventory.Application.Features.SocketFeature.UpdateSocket;

public class UpdateSocketValidator : AbstractValidator<UpdateSocketRequest>
{
    public UpdateSocketValidator()
    {
        RuleFor(x => x.Count).NotEmpty();
    }
}
