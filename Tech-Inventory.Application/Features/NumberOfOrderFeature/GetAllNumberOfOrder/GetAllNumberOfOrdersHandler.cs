using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetAllNumberOfOrder;

public class GetAllNumberOfOrdersHandler : IRequestHandler<GetAllNumberOfOrdersRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllNumberOfOrdersHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator, UserManager<ApplicationUser> useManager)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
        _userManager = useManager;
    }
    public async Task<ApiResponse> Handle(GetAllNumberOfOrdersRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            var numberOfOrders = await _context.NumberOfOrders
                .Include(x => x.Region)
                .Include(x => x.District)
                .OrderBy(x => x.Id)
                .Where(x => x.ProjectId == request.ProjectId)
                .Skip(skipRows)
                .Take(request.PageSize)
                .ToListAsync();

            var numberOfOrdersResponse = _mapper.Map<List<GetAllNumberOfOrdersResponse>>(numberOfOrders);

            foreach (var item in numberOfOrdersResponse)
            {
                var CreatorUser = await _userManager.FindByIdAsync(item.CreatedBy.ToString());
                var UpdatorUser = new ApplicationUser();

                if (item.UpdatedBy != null)
                {
                    UpdatorUser = await _userManager.FindByIdAsync(item.UpdatedBy.ToString());
                }

                if (CreatorUser != null)
                {
                    item.Creator = CreatorUser.UserName;
                }

                if (UpdatorUser != null)
                {
                    item.Updator = UpdatorUser.UserName;
                }
            }

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
