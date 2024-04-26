using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ProjectorFeature.GetAllProjectors;

public class GetAllProjectorsHandler : IRequestHandler<GetAllProjectorsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllProjectorsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllProjectorsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var projectors = await _context.Projectors
                .Where(x => x.ObyektId == request.ObyektId)
                .Include(x => x.Model)
                .ToListAsync();

            var projectorsResponse = _mapper.Map<List<GetAllProjectorsResponse>>(projectors);

            return ResponseHandler.GetAppResponse(type, projectorsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
