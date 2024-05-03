using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.BoxFeature.GetAllBoxes;

public class GetAllBoxesHandler : IRequestHandler<GetAllBoxesRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllBoxesHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllBoxesRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var boxes = await _context.Boxes
                .Where(x => x.ObyektId == request.ObyektId)
                .Include(x => x.Model)
                .ToListAsync();

            var boxesResponse = _mapper.Map<List<GetAllBoxesResponse>>(boxes);

            return ResponseHandler.GetAppResponse(type, boxesResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
