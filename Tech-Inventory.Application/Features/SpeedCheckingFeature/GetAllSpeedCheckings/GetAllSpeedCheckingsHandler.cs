using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.GetAllSpeedCheckings;

public class GetAllSpeedCheckingsHandler : IRequestHandler<GetAllSpeedCheckingsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllSpeedCheckingsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllSpeedCheckingsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var speedCheckings = await _context.SpeedCheckings
                .Where(x => x.ObyektId == request.ObyektId)
                .Include(x => x.Model)
                .ToListAsync();

            var speedCheckingsResponse = _mapper.Map<List<GetAllSpeedCheckingsResponse>>(speedCheckings);

            return ResponseHandler.GetAppResponse(type, speedCheckingsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
