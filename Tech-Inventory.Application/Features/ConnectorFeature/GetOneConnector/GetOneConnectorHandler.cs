using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ConnectorFeature.GetOneConnector;

public class GetOneConnectorHandler : IRequestHandler<GetOneConnectorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneConnectorHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneConnectorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var connector = await _context.Connectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var connectorResponse = _mapper.Map<GetOneConnectorResponse>(connector);

            return ResponseHandler.GetAppResponse(type, connectorResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
