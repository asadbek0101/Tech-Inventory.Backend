using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ConnectorFeature.DeleteConnector;

public class DeleteConnectorHandler : IRequestHandler<DeleteConnectorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteConnectorHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteConnectorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var connector = await _context.Connectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (connector == null)
            {
                return ResponseHandler.GetAppResponse(type, new DeleteConnectorResponse { Id = 0, Message = "Avtomat not found" });
            }
            _context.Connectors.Remove(connector);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteConnectorResponse { Id = request.Id, Message = "Avtomat has deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
