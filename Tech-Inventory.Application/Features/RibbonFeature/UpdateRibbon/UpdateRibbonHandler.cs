using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        var Message = "Ribbon not found";
        var Id = 0;
        try
        {
            var ribbon = await _context.Ribbons.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if(ribbon != null)
            {
                ribbon.Meter = request.Meter;
                ribbon.Info = request.Info;

                _context.Ribbons.Update(ribbon);
                await _unitOfWork.Save(cancellationToken);
                Message = "Ribbon has updated";
                Id = ribbon.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateRibbonResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
