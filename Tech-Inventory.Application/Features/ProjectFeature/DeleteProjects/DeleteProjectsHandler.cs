using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectFeature.DeleteProjects;

public class DeleteProjectsHandler : IRequestHandler<DeleteProjectsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProjectsHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(DeleteProjectsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var projects = new List<Project>();

            foreach (var id in request.ProjectIds)
            {
                var project = await _context.Projects.Where(t => t.Id == id).FirstOrDefaultAsync();
                if (project != null)
                {
                    projects.Add(project);
                }
            }

            _context.Projects.RemoveRange(projects);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new DeleteProjectsResponse { Message = "Projects have deleted" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
