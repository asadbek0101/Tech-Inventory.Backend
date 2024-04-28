using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.GetAllAkumalators;

public class GetAllAkumalatorsHandler : IRequestHandler<GetAllAkumalatorsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllAkumalatorsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllAkumalatorsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var akumalators = await _context.Akumalators
                .Where(x => x.ObyektId == request.ObyektId)
                .ToListAsync();

            var akumalatorsResponse = _mapper.Map<List<GetAllAkumalatorsResponse>>(akumalators);

            return ResponseHandler.GetAppResponse(type, akumalatorsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
