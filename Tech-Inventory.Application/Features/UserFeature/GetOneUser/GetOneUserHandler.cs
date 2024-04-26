using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.GetOneUser;

public class GetOneUserHandler : IRequestHandler<GetOneUserRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public GetOneUserHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneUserRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var user = await _userManager.Users.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (user == null)
            {
                type = ResponseType.Failed;

                return ResponseHandler.GetAppResponse(type, new { Message = "User Not Found" });
            }
            else
            {
                var responseUser = _mapper.Map<GetOneUserResponse>(user);

                return ResponseHandler.GetAppResponse(type, responseUser);
            }
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
