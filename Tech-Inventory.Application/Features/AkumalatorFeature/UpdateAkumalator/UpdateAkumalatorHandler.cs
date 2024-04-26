using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.UpdateAkumalator;

public class UpdateAkumalatorHandler : IRequestHandler<UpdateAkumalatorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAkumalatorHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateAkumalatorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var akumalator = _mapper.Map<Akumalator>(request);
            _context.Akumalators.Update(akumalator);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateAkumalatorResponse { Id = akumalator.Id, Message = "Akumalator has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
