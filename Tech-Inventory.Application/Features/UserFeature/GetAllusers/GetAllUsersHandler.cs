using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.GetAllusers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;
    public GetAllUsersHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IPaginator paginator)
    {
        _userManager = userManager;
        _paginator = paginator;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);
            var users = await _userManager
                .Users
                .Include(x => x.Region)
                .Include(x => x.District)
                .Skip(skipRows)
                .Take(request.PageSize).ToListAsync();

            var usersResponse = _mapper.Map<List<GetAllUsersResponse>>(users);

            var totalRowCount = await _userManager.Users.CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);
            var response = new PaginationResponse { Data = usersResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
