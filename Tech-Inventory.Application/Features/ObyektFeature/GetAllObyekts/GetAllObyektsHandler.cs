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
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            var obyekts = await _context
                .Obyekts
                .Include(x=>x.Project)
                .Include(x=>x.Region)
                .Include(x=>x.District)
                .ToListAsync();

            if(request.RegionId != 0)
            {
                obyekts = obyekts.Where(x=>x.RegionId == request.RegionId).ToList();
            }

            if(request.DistrictId != 0)
            {
                obyekts = obyekts.Where(x => x.DistrictId == request.DistrictId).ToList();
            }

            if (request.ProjectId != 0)
            {
                obyekts = obyekts.Where(x => x.ProjectId == request.ProjectId).ToList();
            }

            if (request.NumberOfOrderId != 0)
            {
                obyekts = obyekts.Where(x => x.NumberOfOrderId == request.NumberOfOrderId).ToList();
            }

            if (request.ObjectClassificationId != 0)
            {
                obyekts = obyekts.Where(x => x.ObjectClassId == request.ObjectClassificationId).ToList();
            }

            if (request.ObjectClassificationTypeId != 0)
            {
                obyekts = obyekts.Where(x => x.ObjectClassTypeId == request.ObjectClassificationTypeId).ToList();
            }

            if (request.SearchValue != null)
            {
                obyekts = obyekts.Where(x => x.Name.ToUpper().Contains(request.SearchValue.ToUpper())).ToList();
            }

            obyekts = obyekts.Skip(skipRows).Take(request.PageSize).ToList();

            var obyektsResponse = _mapper.Map<List<GetAllObyektsResponse>>(obyekts);

            var totalRowCount = await _context.Obyekts.CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);

            foreach( var item in obyektsResponse)
            {
                var user = await _userManager.FindByIdAsync(item.CreatedBy.ToString());

                if (user != null)
                {
                    item.Owner = user.UserName;
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
