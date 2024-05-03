using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetAllNumberOfOrder;

public class GetAllNumberOfOrdersHandler : IRequestHandler<GetAllNumberOfOrdersRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;

    public GetAllNumberOfOrdersHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
    }
    public async Task<ApiResponse> Handle(GetAllNumberOfOrdersRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            var numberOfOrders = await _context.NumberOfOrders
                .Include(x => x.Region)
                .OrderBy(x => x.Id)
                .Where(x => x.ProjectId == request.ProjectId)
                .Skip(skipRows)
                .Take(request.PageSize)
                .ToListAsync();

            var numberOfOrdersResponse = _mapper.Map<List<GetAllNumberOfOrdersResponse>>(numberOfOrders);

            var totalRowCount = await _context.NumberOfOrders.Where(x=>x.ProjectId == request.ProjectId).CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);
            var response = new PaginationResponse { Data = numberOfOrdersResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
