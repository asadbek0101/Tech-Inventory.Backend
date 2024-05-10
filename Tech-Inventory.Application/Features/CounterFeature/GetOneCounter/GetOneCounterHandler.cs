using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CounterFeature.GetOneCounter;

public class GetOneCounterHandler : IRequestHandler<GetOneCounterRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneCounterHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneCounterRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var counter = await _context.Counters.Include(x=>x.Model).Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var countertResponse = _mapper.Map<GetOneCounterResponse>(counter);

            return ResponseHandler.GetAppResponse(type, countertResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
