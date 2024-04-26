using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SocketFeature.GetAllSockets;

public class GetAllSocketsHandler : IRequestHandler<GetAllSocketsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllSocketsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllSocketsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var sockets = await _context.Sockets.Where(x => x.ObyektId == request.ObyektId).ToListAsync();

            var socketsResponse = _mapper.Map<List<GetAllSocketsResponse>>(sockets);

            return ResponseHandler.GetAppResponse(type, socketsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
