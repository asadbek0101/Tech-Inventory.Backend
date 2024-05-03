using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RibbonFeature.CreateRibbon;

public class CreateRibbonHandler : IRequestHandler<CreateRibbonRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRibbonHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateRibbonRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var ribbon = _mapper.Map<Ribbon>(request);
            _context.Ribbons.Add(ribbon);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateRibbonResponse { Id = ribbon.Id, Message = "Ribbon has created" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
