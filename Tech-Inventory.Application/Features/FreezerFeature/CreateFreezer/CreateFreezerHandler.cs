using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.FreezerFeature.CreateFreezer;

public class CreateFreezerHandler : IRequestHandler<CreateFreezerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFreezerHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateFreezerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var freezer = _mapper.Map<Freezer>(request);
            _context.Freezers.Add(freezer);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateFreezerResponse { Id = freezer.Id, Message = "Freezer has created" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
