using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SvetaforFeature.UpdateSvetafor;

public class UpdateSvetaforHandler : IRequestHandler<UpdateSvetaforRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSvetaforHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateSvetaforRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var svetafor = _mapper.Map<SvetoforDetector>(request);
            _context.SvetoforDetectors.Update(svetafor);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateSvetaforResponse { Id = svetafor.Id, Message = "Svetafor has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
