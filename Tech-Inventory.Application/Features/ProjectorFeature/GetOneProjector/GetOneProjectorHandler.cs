using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ProjectorFeature.GetOneProjector;

public class GetOneProjectorHandler : IRequestHandler<GetOneProjectorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneProjectorHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneProjectorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var projector = await _context
                .Projectors
                .Include(x => x.Model)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var projectorResponse = _mapper.Map<GetOneProjectorResponse>(projector);

            return ResponseHandler.GetAppResponse(type, projectorResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
