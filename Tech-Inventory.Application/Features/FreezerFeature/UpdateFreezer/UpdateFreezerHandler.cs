using AutoMapper;
using MediatR;
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
        try
        {
            var freezer = _mapper.Map<Freezer>(request);
            _context.Freezers.Update(freezer);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateFreezerResponse { Id = freezer.Id, Message = "Freezer has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
