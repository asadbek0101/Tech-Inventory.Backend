using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetAllDistricts;

public class GetAllDistrictsHandler : IRequestHandler<GetAllDistrictsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;

    public GetAllDistrictsHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
    }
    public async Task<ApiResponse> Handle(GetAllDistrictsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            var districts = await _context.Districts
                .Include(x=>x.Region)
                .Where(x => x.RegionId == request.RegionId)
                .Skip(skipRows)
                .Take(request.PageSize)
                .ToListAsync();

            var districtsResponse = _mapper.Map<List<GetAllDistrictsResponse>>(districts);
            var totalRowCount = await _context.Districts.Where(x=>x.RegionId == request.RegionId).CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);
            var response = new PaginationResponse { Data = districtsResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
