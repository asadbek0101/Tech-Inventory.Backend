using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetAllObyekts;

public class GetAllObyektsHandler : IRequestHandler<GetAllObyektsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllObyektsHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetAllObyektsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {

            var query = _context
                .Obyekts
                .OrderBy(x=>x.Id)
                .Include(x=>x.Project)
                .Include(x=>x.Region)
                .Include(x=>x.District)
                .Include(x => x.Streett)
                .AsQueryable();

            if (request.CreatedBy != 0)
            {
                query = query.Where(x => x.CreatedBy == request.CreatedBy);
            }

            if (request.RegionId != 0)
            {
                query = query.Where(x => x.RegionId == request.RegionId);
            }

            if (request.StreetId != 0)
            {
                query = query.Where(x => x.StreetId == request.StreetId);
            }

            if (request.DistrictId != 0)
            {
                query = query.Where(x => x.DistrictId == request.DistrictId);
            }

            if (request.ProjectId != 0)
            {
                query = query.Where(x => x.ProjectId == request.ProjectId);
            }

            if (request.NumberOfOrderId != 0)
            {
                query = query.Where(x => x.NumberOfOrderId == request.NumberOfOrderId);
            }

            if (request.ObjectClassificationId != 0)
            {
                query = query.Where(x => x.ObjectClassId == request.ObjectClassificationId);
            }

            if (request.ObjectClassificationTypeId != 0)
            {
                query = query.Where(x => x.ObjectClassTypeId == request.ObjectClassificationTypeId);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchValue))
            {
                query = query
                       .Where(x => x.NameAndAddress.ToUpper().Contains(request.SearchValue.ToUpper()) || 
                       x.Region.Name.ToUpper().Contains(request.SearchValue.ToUpper()));
            }


            var pagedResult = await query
                .OrderBy(x => x.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var totalRowCount = await query.CountAsync();

            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);

            var obyektsResponse = _mapper.Map<List<GetAllObyektsResponse>>(pagedResult);

            foreach (var item in obyektsResponse)
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

            var response = new PaginationResponse { Data = obyektsResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
