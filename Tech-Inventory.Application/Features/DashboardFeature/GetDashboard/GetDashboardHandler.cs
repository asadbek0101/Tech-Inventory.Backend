using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.DashboardFeature.GetDashboard;

public class GetDashboardHandler : IRequestHandler<GetDashboardRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetDashboardHandler(ITechInventoryDB context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetDashboardRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var regions = await _context.Regions.Select(x => new { x.Name, x.Id }).OrderBy(x => x.Id).ToListAsync();

            var classifications = await _context.ObjectClassTypes.Select(x => new { x.Name, x.Id }).ToListAsync();

            var users = await _userManager.Users.ToListAsync();

            List<GetDashboardDto> cameraTypes = new List<GetDashboardDto>
            {
                new GetDashboardDto{ Label = "Kamera", Id = 1, Value = 0 },
                new GetDashboardDto{ Label = "Radar", Id = 2, Value = 0 },
                new GetDashboardDto{ Label = "ANPR", Id = 3, Value = 0 },
                new GetDashboardDto{ Label = "PTZ", Id = 4, Value = 0 },
                new GetDashboardDto{ Label = "C327", Id = 5, Value = 0 },
                new GetDashboardDto{ Label = "CHQBA", Id = 6, Value = 0 },
                new GetDashboardDto{ Label = "C733", Id = 7, Value = 0 },
            };

            List<GetDashboardDto> regionsResponse = new List<GetDashboardDto>();

            List<GetDashboardDto> classificationsResponse = new List<GetDashboardDto>();

            List<GetDashboardDto> camerasResponse = new List<GetDashboardDto>();

            List<GetDashboardDto> usersResponse = new List<GetDashboardDto>();

            regions.ForEach( r =>
            {
                var count =  _context.Obyekts.Where(x => x.RegionId == r.Id).Count();

                regionsResponse.Add(new GetDashboardDto
                {
                    Id = r.Id,
                    Label = r.Name,
                    Value = count
                });
            });

            cameraTypes.ForEach(c =>
            {
                var count = _context.Cameras.Where(x => x.CameraType == (CameraTypes)c.Id).Count();

                camerasResponse.Add(new GetDashboardDto
                {
                    Id = c.Id,
                    Label = c.Label,
                    Value = count
                });
            });

            classifications.ForEach(c =>
            {
                

                var count = _context.Obyekts.Where(x => x.ObjectClassTypeId == c.Id).Count();

                

                classificationsResponse.Add(new GetDashboardDto
                {
                    Id = c.Id,
                    Label = c.Name + ": " + count + " ta",
                    Value = count
                });
            });

            users.ForEach(u =>
            {
                var todayUtc = DateTime.UtcNow.Date;
                var tomorrowUtc = todayUtc.AddDays(1);


                var count = _context.Obyekts.Where(x => x.CreatedBy == u.Id).Count();

                var thisDayCount = _context.Obyekts.Where(x => x.CreatedBy == u.Id && x.CreatedDate >= todayUtc && x.CreatedDate < tomorrowUtc).Count();

                usersResponse.Add(new GetDashboardDto
                {
                    Id = u.Id,
                    Label = u.FirstName + " " + u.LastName + " +" +thisDayCount,
                    Value = count
                });
            });

            var response = new GetDashboardResponse { Cameras = camerasResponse, Regions = regionsResponse, Classifications = classificationsResponse, Users = usersResponse };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
