using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CableFeature.GetAllCabels;

public class GetAllCabelsHandler : IRequestHandler<GetAllCabelsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllCabelsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllCabelsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var cabels = await _context.Cabels
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.CabelType == request.cabelType)
                .Include(x => x.Model)
                .ToListAsync();

            var cabelsResponse = _mapper.Map<List<GetAllCabelsResponse>>(cabels);

            return ResponseHandler.GetAppResponse(type, cabelsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
