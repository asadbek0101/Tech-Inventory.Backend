using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ConnectorFeature.UpdateConnector;

public class UpdateConnectorHandler : IRequestHandler<UpdateConnectorRequest, ApiResponse>
{
    public Task<ApiResponse> Handle(UpdateConnectorRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
