using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ConnectorFeature.UpdateConnector;

public class UpdateConnectorHandler : IRequestHandler<UpdateConnectorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateConnectorHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateConnectorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Connector not found";
        var Id = 0;
        try
        {
            var connector = await _context.Connectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (connector != null)
            {
                connector.Count = request.Count;
                connector.Info = request.Info;

                _context.Connectors.Update(connector);
                await _unitOfWork.Save(cancellationToken);

                Id = connector.Id;
                Message = "Connector has updated!";
            }
            else
            {
                type = ResponseType.Failed;
            }


            return ResponseHandler.GetAppResponse(type, new UpdateConnectorResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
