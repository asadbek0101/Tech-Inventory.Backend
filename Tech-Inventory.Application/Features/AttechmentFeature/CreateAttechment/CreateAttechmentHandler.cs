using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AttechmentFeature.CreateAttechment;

public class CreateAttechmentHandler : IRequestHandler<CreateAttechmentRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAttechmentHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateAttechmentRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var attechment = _mapper.Map<Attachment>(request);
            _context.Attachments.Add(attechment);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateAttechmentResponse { Id = attechment.Id, Message = "Attachment has created" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
