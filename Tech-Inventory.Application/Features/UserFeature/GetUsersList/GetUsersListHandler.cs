using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.GetUsersList;

public class GetUsersListHandler : IRequestHandler<GetUsersListRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;
    public GetUsersListHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IPaginator paginator)
    {
        _userManager = userManager;
        _paginator = paginator;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetUsersListRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var users = await _userManager
                .Users.ToListAsync();
           
            var responseUsers = _mapper.Map<List<GetUsersListResponse>>(users);

            return ResponseHandler.GetAppResponse(type, responseUsers);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
