using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RegionFeature.GetOneRegion;

public class GetOneRegionHandler : IRequestHandler<GetOneRegionRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneRegionHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(GetOneRegionRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var region = await _context.Regions.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var regionResponse = _mapper.Map<GetOneRegionResponse>(region);

            return ResponseHandler.GetAppResponse(type, regionResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
