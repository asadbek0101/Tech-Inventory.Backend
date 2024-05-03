using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BoxFeature.UpdateBox;

public class UpdateBoxHandler : IRequestHandler<UpdateBoxRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBoxHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateBoxRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var box = _mapper.Map<Box>(request);
            _context.Boxes.Update(box);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateBoxResponse { Id = box.Id, Message = "Box has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
