using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.ProjectFeature.GetAllProjects;

public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllProjectsHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator , UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetAllProjectsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var projects = new List<Project>();
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            if (request.SearchValue != null)
            {
                projects = await _context.Projects
                    .Where(x => x.Name.ToUpper().Contains(request.SearchValue.ToUpper()))
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }
            else
            {
                projects = await _context.Projects
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToListAsync();
            }

            var projectsResponse = _mapper.Map<List<GetAllProjectsResponse>>(projects);

            foreach (var item in projectsResponse)
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
            var response = new PaginationResponse { Data = projectsResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
