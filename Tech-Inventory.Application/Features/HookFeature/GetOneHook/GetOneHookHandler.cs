using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.HookFeature.GetOneHook;

public class GetOneHookHandler : IRequestHandler<GetOneHookRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneHookHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneHookRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var hook = await _context.Hooks.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var hookResponse = _mapper.Map<GetOneHookResponse>(hook);

            return ResponseHandler.GetAppResponse(type, hookResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
