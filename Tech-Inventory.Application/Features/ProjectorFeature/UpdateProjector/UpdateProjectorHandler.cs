using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ProjectorFeature.UpdateProjector;

public class UpdateProjectorHandler : IRequestHandler<UpdateProjectorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProjectorHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateProjectorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Projector not found!";
        var Id = 0;
        try
        {
            var projector = await _context.Projectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();


            if (projector != null)
            {
                projector.ModelId = request.ModelId;
                projector.Count = request.Count;
                projector.Info = request.Info;

                _context.Projectors.Update(projector);
                await _unitOfWork.Save(cancellationToken);

                Message = "Projector has updated!";
                Id = projector.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateProjectorResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
