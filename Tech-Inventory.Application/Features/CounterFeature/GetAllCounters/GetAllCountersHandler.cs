using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CounterFeature.GetAllCounters;

public class GetAllCountersHandler : IRequestHandler<GetAllCountersRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllCountersHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllCountersRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var counters = await _context.Counters
                .Where(x => x.ObyektId == request.ObyektId)
                .Include(x => x.Model)
                .ToListAsync();

            var countersResponse = _mapper.Map<List<GetAllCountersResponse>>(counters);

            return ResponseHandler.GetAppResponse(type, countersResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
