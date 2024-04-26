using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SocketFeature.GetOneSocket;

public class GetOneSocketHandler : IRequestHandler<GetOneSocketRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneSocketHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneSocketRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var socket = await _context.Sockets.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var socketResponse = _mapper.Map<GetOneSocketResponse>(socket);

            return ResponseHandler.GetAppResponse(type, socketResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
