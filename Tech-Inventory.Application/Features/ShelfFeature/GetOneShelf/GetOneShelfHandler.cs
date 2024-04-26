using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ShelfFeature.GetOneShelf;

public class GetOneShelfHandler : IRequestHandler<GetOneShelfRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneShelfHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneShelfRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var shelf = await _context.Shelves.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var shelfResponse = _mapper.Map<GetOneShelfResponse>(shelf);

            return ResponseHandler.GetAppResponse(type, shelfResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
