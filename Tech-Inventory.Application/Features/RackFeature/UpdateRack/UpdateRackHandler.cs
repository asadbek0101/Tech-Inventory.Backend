using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.RackFeature.UpdateRack;

public class UpdateRackHandler : IRequestHandler<UpdateRackRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRackHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateRackRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Id = 0;
        var Message = "Rack not found";
        try
        {
            var rack = await _context.Racks.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (rack != null)
            {
            
                rack.NumberOfFibers = request.NumberOfFibers;
                rack.TypeOfAdapter = request.TypeOfAdapter;
                rack.CountOfPorts = request.CountOfPorts;
                rack.Info = request.Info;

                _context.Racks.Update(rack);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                type = ResponseType.Failed;
            }
            
            return ResponseHandler.GetAppResponse(type, new UpdateRackResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
