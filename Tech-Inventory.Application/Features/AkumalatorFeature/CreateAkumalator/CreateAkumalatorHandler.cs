using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.CreateAkumalator;

public class CreateAkumalatorHandler : IRequestHandler<CreateAkumalatorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAkumalatorHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateAkumalatorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var akumalator = _mapper.Map<Akumalator>(request);
            _context.Akumalators.Add(akumalator);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateAkumalatorResponse { Id = akumalator.Id, Message = "Akumalator has created" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
