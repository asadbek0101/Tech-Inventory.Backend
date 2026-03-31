using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetNumberOfOrdersList;

public class GetNumberOfOrdersListHandler : IRequestHandler<GetNumberOfOrdersListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetNumberOfOrdersListHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetNumberOfOrdersListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var query = _context
                .NumberOfOrders
                .Where(x => x.ProjectId == request.ProjectId)
                .AsQueryable();

            if(request.RegionId != null)
            {
                query = query.Where(x => x.RegionId == request.RegionId);
            }

            if(request.DistrictId != null)
            {
                query = query.Where(x => x.DistrictId == request.DistrictId);
            }

            var numberOfOrders = await query.ToListAsync();

            var numberOfOrdersResponse = _mapper.Map<List<GetNumberOfOrdersListResponse>>(numberOfOrders);

            return ResponseHandler.GetAppResponse(type, numberOfOrdersResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
