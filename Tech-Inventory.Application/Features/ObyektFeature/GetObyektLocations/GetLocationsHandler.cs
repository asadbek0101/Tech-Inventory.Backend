using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektLocations;

public class GetLocationsHandler : IRequestHandler<GetLocationsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetLocationsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {

            var query = _context
                .Obyekts
                .AsQueryable();

            var locations = await query
                .OrderBy(x => x.Id)
                .ToListAsync();

            var obyektsResponse = _mapper.Map<List<GetLocationsResponse>>(locations);

            return ResponseHandler.GetAppResponse(type, obyektsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
