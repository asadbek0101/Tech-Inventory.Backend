using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ProjectFeature.GetOneProject;

public class GetOneProjectHandler : IRequestHandler<GetOneProjectRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneProjectHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneProjectRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var project = await _context.Projects.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var projectResponse = _mapper.Map<GetOneProjectResponse>(project);

            return ResponseHandler.GetAppResponse(type, projectResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
