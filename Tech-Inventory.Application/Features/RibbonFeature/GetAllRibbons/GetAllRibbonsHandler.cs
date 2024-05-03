using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RibbonFeature.GetAllRibbons;

public class GetAllRibbonsHandler : IRequestHandler<GetAllRibbonsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllRibbonsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllRibbonsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var ribbons = await _context.Ribbons
                .Where(x => x.ObyektId == request.ObyektId)
                .ToListAsync();

            var ribbonsResponse = _mapper.Map<List<GetAllRibbonsResponse>>(ribbons);

            return ResponseHandler.GetAppResponse(type, ribbonsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
