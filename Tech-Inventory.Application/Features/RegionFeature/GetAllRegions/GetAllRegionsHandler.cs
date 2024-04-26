using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RegionFeature.GetAllRegions;

public class GetAllRegionsHandler : IRequestHandler<GetAllRegionsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;

    public GetAllRegionsHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
    }
    public async Task<ApiResponse> Handle(GetAllRegionsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var regions = new List<Region>();
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            if (request.SearchValue != null)
            {
                regions = await _context.Regions
                    .Where(x => x.Name.ToUpper().Contains(request.SearchValue.ToUpper()))
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }
            else
            {
                regions = await _context.Regions
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }

            var regionsResponse = _mapper.Map<List<GetAllRegionsResponse>>(regions);
            var totalRowCount = await _context.Regions.CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);
            var response = new PaginationResponse { Data = regionsResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
