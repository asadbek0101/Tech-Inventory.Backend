using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.StanchionFeature.GetOneStanchion;

public class GetOneStanchionHandler : IRequestHandler<GetOneStanchionRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneStanchionHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneStanchionRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var stanchion = await _context
                .Stanchions
                .Include(x => x.Model)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var stanchionResponse = _mapper.Map<GetOneStanchionResponse>(stanchion);

            return ResponseHandler.GetAppResponse(type, stanchionResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
