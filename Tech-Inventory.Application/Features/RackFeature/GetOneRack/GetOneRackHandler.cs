using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RackFeature.GetOneRack;

public class GetOneRackHandler : IRequestHandler<GetOneRackRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneRackHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneRackRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var rack = await _context.Projectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var rackResponse = _mapper.Map<GetOneRackResponse>(rack);

            return ResponseHandler.GetAppResponse(type, rackResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
