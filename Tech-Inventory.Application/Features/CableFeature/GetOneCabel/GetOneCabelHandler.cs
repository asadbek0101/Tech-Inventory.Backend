using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CableFeature.GetOneCabel;

public class GetOneCabelHandler : IRequestHandler<GetOneCabelRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneCabelHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneCabelRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var cabel = await _context.Cabels.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var cabelResponse = _mapper.Map<GetOneCabelResponse>(cabel);

            return ResponseHandler.GetAppResponse(type, cabelResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
