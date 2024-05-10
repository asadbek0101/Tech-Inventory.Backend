using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ServerFeature.UpdateServer;

public class UpdateServerHandler : IRequestHandler<UpdateServerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateServerHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateServerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Server not found";
        var Id = 0;
        try
        {
            var server = await _context.Servers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (server != null)
            {
                server.Ip = request.Ip;
                server.Info = request.Info;

                _context.Servers.Update(server);
                await _unitOfWork.Save(cancellationToken);

                Message = "Server has updated!";
                Id = server.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateServerResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
