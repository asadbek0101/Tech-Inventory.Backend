using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.FreezerFeature.UpdateFreezer;

public class UpdateFreezerHandler : IRequestHandler<UpdateFreezerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFreezerHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateFreezerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Freezer not found";
        var Id = 0;
        try
        {
            var freezer = await _context.Freezers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (freezer != null)
            {
                freezer.Count = request.Count;
                freezer.Info = request.Info;

                _context.Freezers.Update(freezer);
                await _unitOfWork.Save(cancellationToken);
                Id = freezer.Id;
                Message = "Freezer has found";
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateFreezerResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
