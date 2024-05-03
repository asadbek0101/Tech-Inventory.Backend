using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ConnectorFeature.GetAllConnectors;

public class GetAllConnectorsHandler : IRequestHandler<GetAllConnectorsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllConnectorsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllConnectorsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var connectors = await _context.Connectors
                .Where(x => x.ObyektId == request.ObyektId)
                .ToListAsync();

            var connectorsResponse = _mapper.Map<List<GetAllConnectorsResponse>>(connectors);

            return ResponseHandler.GetAppResponse(type, connectorsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
