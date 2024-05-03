using MediatR;
using Microsoft.AspNetCore.Identity;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.UserFeature.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, ApiResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public CreateUserHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            ApplicationUser user = new ApplicationUser { 
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                RegionId = request.RegionId,
                RoleName = request.RoleName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
            };

            var isCreatedUser = await _userManager.CreateAsync(user, request.Password);

            if(isCreatedUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, request.RoleValue);

                return ResponseHandler.GetAppResponse(type, new CreateUserResponse { Id = user.Id, Message = "User has created" });
            }
            else
            {
                type = ResponseType.Failed;
                var errorMessage = "";
                foreach (var item in isCreatedUser.Errors)
                {
                    errorMessage = errorMessage + item.Description + " ";
                }
                return ResponseHandler.GetAppResponse(type, new CreateUserResponse { Id = 0, Message = errorMessage });
            }
            
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
