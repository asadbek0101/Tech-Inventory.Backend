using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.SwitchFeature.UpdateSwitch;

public class UpdateSwitchHandler : IRequestHandler<UpdateSwitchRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSwitchHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateSwitchRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Switch not found!";
        var Id = 0;
        try
        {
            var switchT = await _context.Switches.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(switchT != null)
            {
                switchT.ModelId = request.ModelId;
                switchT.CountOfPorts = request.CountOfPorts;
                switchT.Info = request.Info;

                _context.Switches.Update(switchT);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateSwitchResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
