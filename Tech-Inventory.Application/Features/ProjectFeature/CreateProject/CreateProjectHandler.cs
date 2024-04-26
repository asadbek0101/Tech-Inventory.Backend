using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectFeature.CreateProject;

public class CreateProjectHandler : IRequestHandler<CreateProjectRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var project = _mapper.Map<Project>(request);
            _context.Projects.Add(project);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateProjectResponse { Id = project.Id, Message = "Project has created" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
