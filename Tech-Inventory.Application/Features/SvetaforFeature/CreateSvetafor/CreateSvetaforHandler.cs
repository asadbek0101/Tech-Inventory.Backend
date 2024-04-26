using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SvetaforFeature.CreateSvetafor;

public class CreateSvetaforHandler : IRequestHandler<CreateSvetaforRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSvetaforHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateSvetaforRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var svetafor = _mapper.Map<SvetoforDetector>(request);
            _context.SvetoforDetectors.Add(svetafor);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateSvetaforResponse { Id = svetafor.Id, Message = "Svetafor has created" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
