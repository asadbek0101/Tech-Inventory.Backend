using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetAllObjectClasses;

public class GetAllObjectClassesHandler : IRequestHandler<GetAllObjectClassesRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;

    public GetAllObjectClassesHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetAllObjectClassesRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            var ojbectClasses = await _context
                .ObjectClasses
                .OrderBy(x => x.Id)
                .Where(x => x.ObjectClassTypeId == request.ObjectClassTypeId)
                .Skip(skipRows)
                .Take(request.PageSize)
                .ToListAsync();

            var ojbectClassesResponse = _mapper.Map<List<GetAllObjectClassesResponse>>(ojbectClasses);
            var totalRowCount = await _context.ObjectClasses.Where(x => x.ObjectClassTypeId == request.ObjectClassTypeId).CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);

            foreach (var item in ojbectClassesResponse)
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

            var response = new PaginationResponse { Data = ojbectClassesResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
