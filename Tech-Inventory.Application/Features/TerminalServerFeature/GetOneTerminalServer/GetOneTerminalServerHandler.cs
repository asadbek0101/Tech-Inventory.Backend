using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.TerminalServerFeature.GetOenTerminalServer;

public class GetOneTerminalServerHandler : IRequestHandler<GetOneTerminalServerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneTerminalServerHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneTerminalServerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var terminaServer = await _context
                .TerminalServers
                .Include(x => x.Model)
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var terminaServerResponse = _mapper.Map<GetOneTerminalServerResponse>(terminaServer);

            return ResponseHandler.GetAppResponse(type, terminaServerResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
