using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.UpdateTerminalServer;

public class UpateTerminalServerHandler : IRequestHandler<UpdateTerminalServerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpateTerminalServerHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateTerminalServerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Terminal server not found";
        var Id = 0;
        try
        {
            var terminalServer = await _context.TerminalServers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (terminalServer != null)
            {
                terminalServer.ModelId = request.ModelId;
                terminalServer.Info = request.Info;

                _context.TerminalServers.Update(terminalServer);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateTerminalServerResponse { Id = terminalServer.Id, Message = "Terminal server has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
