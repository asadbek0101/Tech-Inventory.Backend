using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NailFeature.GetAllNails;

public class GetAllNailsHandler : IRequestHandler<GetAllNailsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllNailsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllNailsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var nails = await _context.Nails
                .Where(x => x.ObyektId == request.ObyektId)
                .ToListAsync();

            var nailsResponse = _mapper.Map<List<GetAllNailsResponse>>(nails);

            return ResponseHandler.GetAppResponse(type, nailsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
