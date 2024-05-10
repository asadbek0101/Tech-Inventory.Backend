using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ProjectFeature.UpdateProject;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProjectHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Project not found";
        var Id = 0;
        try
        {
            var project = await _context.Projects.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (project != null)
            {
                project.Name = request.Name;
                project.Info = request.Info;
                _context.Projects.Update(project);
                await _unitOfWork.Save(cancellationToken);
                Message = "Project has updated";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateProjectResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
