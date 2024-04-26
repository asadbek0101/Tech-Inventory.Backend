using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RegionFeature.GetRegionsList;

public class GetRegionsListHandler : IRequestHandler<GetRegionsListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetRegionsListHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetRegionsListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var regions = await _context.Regions.ToListAsync();

            var regionsResponse = _mapper.Map<List<GetRegionsListResponse>>(regions);

            return ResponseHandler.GetAppResponse(type, regionsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
