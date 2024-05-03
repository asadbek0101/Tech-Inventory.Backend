using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.AvtomatFeature.GetAllAvtomats;

namespace Tech_Inventory.Application.Features.ServerFeature.GetAllServers;

public class GetAllServersHandler : IRequestHandler<GetAllServersRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllServersHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllServersRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var servers = await _context.Servers
                .Where(x => x.ObyektId == request.ObyektId)
                .ToListAsync();

            var serversResponse = _mapper.Map<List<GetAllServersResponse>>(servers);

            return ResponseHandler.GetAppResponse(type, serversResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
