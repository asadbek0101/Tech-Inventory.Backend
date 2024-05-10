using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.HookFeature.UpdateHook;

public class UpdateHookHandler : IRequestHandler<UpdateHookRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHookHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateHookRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Id = 0;
        var Message = "Hook not found";
        try
        {
            var hook = await _context.Hooks.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(hook != null) 
            {

                hook.Count = request.Count;
                hook.Info = request.Info;

                _context.Hooks.Update(hook);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateHookResponse { Id = Id, Message = Message});
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
