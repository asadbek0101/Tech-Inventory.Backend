using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.DashboardFeature.GetObjectsDashboard;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.DashboardFeature.GetActiveUsersDashboard;

public class GetUserDashboardHandler : IRequestHandler<GetUserDashboardRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetUserDashboardHandler(ITechInventoryDB context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetUserDashboardRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await _userManager.Users.ToListAsync();

            var usersResponse = new List<GetObjectsDashboardDto>();

            users.ForEach(u =>
            {
                var todayUtc = DateTime.UtcNow.Date;
                var tomorrowUtc = todayUtc.AddDays(1);


                var count = _context.Obyekts.Where(x => x.CreatedBy == u.Id).Count();

                var thisDayCount = _context.Obyekts.Where(x => x.CreatedBy == u.Id && x.CreatedDate >= todayUtc && x.CreatedDate < tomorrowUtc).Count();

                usersResponse.Add(new GetObjectsDashboardDto
                {
                    Id = u.Id,
                    Label = u.FirstName + " " + u.LastName + " +" + thisDayCount,
                    Value = count
                });
            });

            return ResponseHandler.GetAppResponse(ResponseType.Success, usersResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
