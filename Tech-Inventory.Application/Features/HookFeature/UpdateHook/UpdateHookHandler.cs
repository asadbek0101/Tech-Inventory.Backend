using AutoMapper;
using MediatR;
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
        try
        {
            var hook = _mapper.Map<Hook>(request);
            _context.Hooks.Update(hook);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateHookResponse { Id = hook.Id, Message = "Hook has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
