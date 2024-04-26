using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.StanchionFeature.CreateStanchion;

public class CreateStanchionHandler : IRequestHandler<CreateStanchionRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStanchionHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateStanchionRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var stanchion = _mapper.Map<Stanchion>(request);
            _context.Stanchions.Add(stanchion);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateStanchionResponse { Id = stanchion.Id, Message = "Stanchion Server has created" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
