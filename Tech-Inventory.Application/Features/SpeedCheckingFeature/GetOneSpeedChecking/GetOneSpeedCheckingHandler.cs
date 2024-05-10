using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SpeedCheckingFeature.GetOneSpeedChecking;

public class GetOneSpeedCheckingHandler : IRequestHandler<GetOneSpeedCheckingRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneSpeedCheckingHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneSpeedCheckingRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var speedChecking = await _context
                .SpeedCheckings
                .Include(x => x.Model)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var speedCheckingResponse = _mapper.Map<GetOneSpeedCheckingResponse>(speedChecking);

            return ResponseHandler.GetAppResponse(type, speedCheckingResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
