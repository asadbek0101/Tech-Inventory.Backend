using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.FreezerFeature.GetOneFreezer;

public class GetOneFreezerHandler : IRequestHandler<GetOneFreezerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneFreezerHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneFreezerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var freezer = await _context.Freezers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var freezerResponse = _mapper.Map<GetOneFreezerResponse>(freezer);

            return ResponseHandler.GetAppResponse(type, freezerResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
