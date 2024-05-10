using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetAllObjectClassTypes;

public class GetAllObjectClassTypesHandler : IRequestHandler<GetAllObjectClassTypesRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;

    public GetAllObjectClassTypesHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetAllObjectClassTypesRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var objectClassTypes = new List<ObjectClassType>();
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            if (request.SearchValue != null)
            {
                objectClassTypes = await _context.ObjectClassTypes
                    .Where(x => x.Name.ToUpper().Contains(request.SearchValue.ToUpper()))
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }
            else
            {
                objectClassTypes = await _context.ObjectClassTypes
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }

            var objectClassTypesResponse = _mapper.Map<List<GetAllObjectClassTypesResponse>>(objectClassTypes);

            foreach (var item in objectClassTypesResponse)
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

            var totalRowCount = await _context.Regions.CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);
            var response = new PaginationResponse { Data = objectClassTypesResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
