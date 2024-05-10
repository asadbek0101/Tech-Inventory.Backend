using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.CreateObjectClassType;

public class CreateObjectClassTypeHandler : IRequestHandler<CreateObjectClassTypeRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateObjectClassTypeHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateObjectClassTypeRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var objectClassType = _mapper.Map<ObjectClassType>(request);
            _context.ObjectClassTypes.Add(objectClassType);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateObjectClassTypeResponse { Id = objectClassType.Id, Message = "Object class type has created" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
