using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RackFeature.GetAllRacks;

public class GetAllRacksHandler : IRequestHandler<GetAllRacksRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public  GetAllRacksHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllRacksRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var racks = await _context.Racks
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.RackType == request.rackType)
                .ToListAsync();

            var projectorsResponse = _mapper.Map<List<GetAllRacksResponse>>(racks);

            return ResponseHandler.GetAppResponse(type, projectorsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
