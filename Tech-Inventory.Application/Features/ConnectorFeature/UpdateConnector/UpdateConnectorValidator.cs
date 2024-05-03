using FluentValidation;

namespace Tech_Inventory.Application.Features.ConnectorFeature.UpdateConnector;

public class UpdateConnectorValidator : AbstractValidator<UpdateConnectorRequest>
{
    public UpdateConnectorValidator()
    {
        RuleFor(x => x.Count).NotEmpty();
    }
}
