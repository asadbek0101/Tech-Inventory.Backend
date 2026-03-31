using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.DashboardFeature.GetObjectsDashboard;

public class GetObjectsDashboardHandler : IRequestHandler<GetObjectsDashboardRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;

    public GetObjectsDashboardHandler(ITechInventoryDB context)
    {
        _context = context;
    }
    public async Task<ApiResponse> Handle(GetObjectsDashboardRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var query = _context.Obyekts.AsQueryable();


            var regions = await _context.Regions.Select(x => new { x.Name, x.Id }).OrderBy(x => x.Id).ToListAsync();

            var districts = new List<District>();

            if(request.RegionId != 0)
            {
                districts = await _context.Districts.Where(x => x.RegionId == request.RegionId).ToListAsync();

                query = query.Where(x => x.RegionId == request.RegionId);
            }

            var classificationTypes = await _context.ObjectClassTypes.Select(x => new { x.Name, x.Id }).ToListAsync();

            var classifications = new List<ObjectClass>();

            if (request.ClassTypeId != 0)
            {
                classifications = await _context.ObjectClasses.Where(x => x.ObjectClassTypeId == request.ClassTypeId).ToListAsync();

                query = query.Where(x => x.ObjectClassTypeId == request.ClassTypeId);
            }

            var projects = await _context.Projects.Select(x => new { x.Name, x.Id }).ToListAsync();

            var orders = new List<NumberOfOrder>();

            if (request.ProjectId != 0)
            {
                orders = await _context.NumberOfOrders.Where(x => x.ProjectId == request.ProjectId).ToListAsync();

                query = query.Where(x => x.ProjectId == request.ProjectId);
            }


            List<GetObjectsDashboardDto> regionsResponse = new List<GetObjectsDashboardDto>();
            List<GetObjectsDashboardDto> districtsResponse = new List<GetObjectsDashboardDto>();

            List<GetObjectsDashboardDto> classificationTypesResponse = new List<GetObjectsDashboardDto>();
            List<GetObjectsDashboardDto> classificationResponse = new List<GetObjectsDashboardDto>();

            List<GetObjectsDashboardDto> projectsResponse = new List<GetObjectsDashboardDto>();
            List<GetObjectsDashboardDto> ordersResponse = new List<GetObjectsDashboardDto>();

            var obyekts = query.ToList();

            if(request.RegionId != 0)
            {
                districts.ForEach(r =>
                {
                    var count = obyekts.Where(x => x.DistrictId == r.Id).Count();

                    districtsResponse.Add(new GetObjectsDashboardDto
                    {
                        Id = r.Id,
                        Label = r.Name,
                        Value = count
                    });
                });
            }
            else
            {
                regions.ForEach(r =>
                {
                    var count = obyekts.Where(x => x.RegionId == r.Id).Count();

                    regionsResponse.Add(new GetObjectsDashboardDto
                    {
                        Id = r.Id,
                        Label = r.Name,
                        Value = count
                    });
                });
            }

            if(request.ClassTypeId != 0)
            {
                classifications.ForEach(c =>
                {
                    var count = obyekts.Where(x => x.ObjectClassId == c.Id).Count();

                    classificationResponse.Add(new GetObjectsDashboardDto
                    {
                        Id = c.Id,
                        Label = c.Name + ": " + count,
                        Value = count
                    });
                });
            }
            else
            {
                classificationTypes.ForEach(c =>
                {
                    var count = obyekts.Where(x => x.ObjectClassTypeId == c.Id).Count();

                    classificationTypesResponse.Add(new GetObjectsDashboardDto
                    {
                        Id = c.Id,
                        Label = c.Name + ": " + count + " ta",
                        Value = count
                    });
                });
            }

            if(request.ProjectId != 0)
            {
                orders.ForEach(c =>
                {
                    var count = obyekts.Where(x => x.NumberOfOrderId == c.Id).Count();

                    ordersResponse.Add(new GetObjectsDashboardDto
                    {
                        Id = c.Id,
                        Label = c.Number,
                        Value = count
                    });
                });

            }
            else
            {
                projects.ForEach(c =>
                {
                    var count = obyekts.Where(x => x.ProjectId == c.Id).Count();

                    projectsResponse.Add(new GetObjectsDashboardDto
                    {
                        Id = c.Id,
                        Label = c.Name,
                        Value = count
                    });
                });
            }

            var response = new GetObjectsDashboardResponse { 
                Projects = request.ProjectId !=0 ? ordersResponse.OrderByDescending(x => x.Value).ToList() : projectsResponse.OrderByDescending(x => x.Value).ToList(), 
                Regions = request.RegionId != 0 ? districtsResponse.OrderByDescending(x => x.Value).ToList() : regionsResponse.OrderByDescending(x => x.Value).ToList(), 
                Classifications = request.ClassTypeId != 0 ? classificationResponse.OrderByDescending(x => x.Value).ToList() : classificationTypesResponse.OrderByDescending(x => x.Value).ToList(),
                RegionTitle = request.RegionId != 0 ? "Tumanlar kesimida" : "Hududlar kesimida",
                ProjectTitle = request.ProjectId != 0 ? "Buyurtma raqam kesimida" : "Loyihalar kesimida",
                ClassTitle = request.ClassTypeId != 0 ? "Tasniflar toifasi kesimida" : "Tasniflar kesimida",
            };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
