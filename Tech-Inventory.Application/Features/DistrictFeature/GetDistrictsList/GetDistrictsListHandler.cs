using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetDistrictsList;

public class GetDistrictsListHandler : IRequestHandler<GetDistrictsListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetDistrictsListHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetDistrictsListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var districts = await _context.Districts.Where(x => x.RegionId == request.RegionId).ToListAsync();

            var districtsResponse = _mapper.Map<List<GetDistrictsListResponse>>(districts);

            return ResponseHandler.GetAppResponse(type, districtsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
