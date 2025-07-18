using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.StreetFeature.GetStreetsList;

public class GetStreetsListHandler : IRequestHandler<GetStreetsListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetStreetsListHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetStreetsListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var streets = await _context.Streets.Where(x => x.DistrictId == request.DistrictId).ToListAsync();

            var streetsResponse = _mapper.Map<List<GetStreetsListResponse>>(streets);

            return ResponseHandler.GetAppResponse(type, streetsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
