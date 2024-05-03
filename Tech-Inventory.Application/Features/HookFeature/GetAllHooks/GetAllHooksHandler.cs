using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.HookFeature.GetAllHooks;

public class GetAllHooksHandler : IRequestHandler<GetAllHooksRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllHooksHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllHooksRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var hooks = await _context.Hooks
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.HookType == request.HookType)
                .ToListAsync();

            var hooksResponse = _mapper.Map<List<GetAllHooksResponse>>(hooks);

            return ResponseHandler.GetAppResponse(type, hooksResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
