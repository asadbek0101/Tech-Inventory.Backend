using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ProjectFeature.GetProjectsList;

public class GetProjectsListHandler : IRequestHandler<GetProjectsListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetProjectsListHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetProjectsListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var projects = await _context.Projects.ToListAsync();

            var projectsResponse = _mapper.Map<List<GetProjectsListResponse>>(projects);

            return ResponseHandler.GetAppResponse(type, projectsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
