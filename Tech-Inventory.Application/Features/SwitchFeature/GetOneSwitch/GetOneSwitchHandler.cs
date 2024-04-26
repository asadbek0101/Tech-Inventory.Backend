using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SwitchFeature.GetOneSwitch;

public class GetOneSwitchHandler : IRequestHandler<GetOneSwitchRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneSwitchHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneSwitchRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var switchT = await _context.Switches.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var switchTResponse = _mapper.Map<GetOneSwitchResponse>(switchT);

            return ResponseHandler.GetAppResponse(type, switchTResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
