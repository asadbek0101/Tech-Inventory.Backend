using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetAllDistricts;

public class GetAllDistrictsHandler : IRequestHandler<GetAllDistrictsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllDistrictsHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetAllDistrictsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            var districts = await _context
                .Districts
                .OrderBy(x=>x.Id)
                .Include(x=>x.Region)
                .Where(x=>x.RegionId == request.RegionId)
                .Skip(skipRows)
                .Take(request.PageSize)
                .ToListAsync();

            var districtsResponse = _mapper.Map<List<GetAllDistrictsResponse>>(districts);
            var totalRowCount = await _context.Districts.Where(x=>x.RegionId == request.RegionId).CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);

            foreach (var item in districtsResponse)
            {
                var CreatorUser = await _userManager.FindByIdAsync(item.CreatedBy.ToString());
                var UpdatorUser = new ApplicationUser();

                if(item.UpdatedBy != null)
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

            var response = new PaginationResponse { Data = districtsResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
