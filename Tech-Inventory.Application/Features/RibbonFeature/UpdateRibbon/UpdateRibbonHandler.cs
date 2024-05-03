using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RibbonFeature.UpdateRibbon;

public class UpdateRibbonHandler : IRequestHandler<UpdateRibbonRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRibbonHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateRibbonRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var ribbon = _mapper.Map<Ribbon>(request);
            _context.Ribbons.Update(ribbon);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateRibbonResponse { Id = ribbon.Id, Message = "Ribbon has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
