using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.FreezerFeature.GetAllFreezers;

public class GetAllFreezersHandler : IRequestHandler<GetAllFreezersRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllFreezersHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllFreezersRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var freezers = await _context.Freezers
                .Where(x => x.ObyektId == request.ObyektId)
                .ToListAsync();

            var freezersResponse = _mapper.Map<List<GetAllFreezersResponse>>(freezers);

            return ResponseHandler.GetAppResponse(type, freezersResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
