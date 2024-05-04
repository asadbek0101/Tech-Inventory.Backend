using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UpdateUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            var user = await _userManager.Users.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(user == null)
            {
                type = ResponseType.Failed;
                return ResponseHandler.GetAppResponse(type, new UpdateUserResponse { Id = 0, Message = "User not Found" });
            }
            else
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.MiddleName = request.MiddleName;
                user.Email = request.Email;
                user.UserName = request.UserName;
                user.PhoneNumber = request.PhoneNumber;
                user.RegionId = request.RegionId;
                user.RoleName = request.RoleName;
                user.Image = request.Image;

                var isUpdateUser = await _userManager.UpdateAsync(user);

                if(isUpdateUser.Succeeded)
                {
                    var role = await _userManager.GetRolesAsync(user);

                    await _userManager.RemoveFromRoleAsync(user, role[0]);
                    await _userManager.AddToRoleAsync(user, request.RoleName);

                    return ResponseHandler.GetAppResponse(type, new UpdateUserResponse
                    {
                        Id = user.Id,
                        Message = "User has updated"
                    });
                }
                else
                {
                    type = ResponseType.Failed;

                    var errorMessage = "";
                    foreach (var item in isUpdateUser.Errors)
                    {
                        errorMessage = errorMessage + item.Description + " ";
                    }

                    return ResponseHandler.GetAppResponse(type, new UpdateUserResponse
                    {
                        Id = 0,
                        Message = errorMessage
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
