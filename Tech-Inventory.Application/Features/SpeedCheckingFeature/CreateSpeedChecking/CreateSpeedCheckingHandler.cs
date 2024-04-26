using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.CreateSpeedChecking;

public class CreateSpeedCheckingHandler : IRequestHandler<CreateSpeedCheckingRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSpeedCheckingHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateSpeedCheckingRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var speedChecking = _mapper.Map<SpeedChecking>(request);
            _context.SpeedCheckings.Add(speedChecking);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateSpeedCheckingResponse { Id = speedChecking.Id, Message = "SpeedChecking has created" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
