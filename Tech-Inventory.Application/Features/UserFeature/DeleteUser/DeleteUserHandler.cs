using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public DeleteUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var user = await _userManager.Users.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (user == null)
            {
                type = ResponseType.Failed;
                return ResponseHandler.GetAppResponse(type, new DeleteUserResponse { 
                Id = 0,
                Message = "User Not Found",
                });
            }
            else
            {
                var isDeletedUser = await _userManager.DeleteAsync(user);
                if (isDeletedUser != null)
                {
                    type = ResponseType.Success;
                    return ResponseHandler.GetAppResponse(type, new DeleteUserResponse 
                    {
                        Id = user.Id,
                        Message = "User Has Deleted"
                    });
                }
                else
                {
                    return ResponseHandler.GetAppResponse(type, new DeleteUserResponse
                    {
                        Id = 0,
                        Message = "Something went wrong"
                    });
                }
            }
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
