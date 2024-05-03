using FluentValidation;

namespace Tech_Inventory.Application.Features.ConnectorFeature.CreateConnector;

public class CreateConnectorValidator : AbstractValidator<CreateConnectorRequest>
{
    public CreateConnectorValidator()
    {
        RuleFor(x => x.Count).NotEmpty();
    }
}
