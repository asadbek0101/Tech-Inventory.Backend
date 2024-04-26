using AutoMapper;
using MediatR;
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
        try
        {
            var stabilizer = _mapper.Map<Stabilizer>(request);
            _context.Stabilizers.Update(stabilizer);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateSocketResponse { Id = stabilizer.Id, Message = "Stabilizer has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
