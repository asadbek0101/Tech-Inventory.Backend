using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SwitchFeature.GetAllSwitches;

public class GetAllSwitchesHandler : IRequestHandler<GetAllSwitchesRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllSwitchesHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllSwitchesRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var switches = await _context.Switches
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.SwitchType == request.switchType)
                .Include(x => x.Model)
                .ToListAsync();

            var switchesResponse = _mapper.Map<List<GetAllSwitchesResponse>>(switches);

            return ResponseHandler.GetAppResponse(type, switchesResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
