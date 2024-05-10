using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.SocketFeature.UpdateSocket;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StabilizerFeature.UpdateStabilizer;

public class UpdateStabilizerHandler : IRequestHandler<UpdateStabilizerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStabilizerHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateStabilizerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Stabilizator not found";
        var Id = 0;
        try
        {
            var stabilizer = await _context.Stabilizers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (stabilizer != null)
            {
                stabilizer.ModelId = request.ModelId;
                stabilizer.Power = request.Power;
                stabilizer.Info = request.Info;

                _context.Stabilizers.Update(stabilizer);
                await _unitOfWork.Save(cancellationToken);

                Message = "Stabilizator has uppdated!";
                Id = stabilizer.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }

            

            return ResponseHandler.GetAppResponse(type, new UpdateSocketResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
