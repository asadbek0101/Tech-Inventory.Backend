using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ShelfFeature.GetAllShelfs;

public class GetAllShelfsHandler : IRequestHandler<GetAllShelfsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllShelfsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllShelfsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var shelfs = await _context.Shelves
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.ShelfType == request.ShelfType)
                .ToListAsync();

            var shelfsResponse = _mapper.Map<List<GetAllShelfsResponse>>(shelfs);

            return ResponseHandler.GetAppResponse(type, shelfsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
