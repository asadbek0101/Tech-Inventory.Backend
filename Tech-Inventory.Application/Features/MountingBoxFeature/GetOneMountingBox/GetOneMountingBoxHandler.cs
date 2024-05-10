using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.MountingBoxFeature.GetOneMountingBox;

public class GetOneMountingBoxHandler : IRequestHandler<GetOneMountingBoxRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneMountingBoxHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneMountingBoxRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var nail = await _context
                .MountingBoxs
                .Include(x => x.Model)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var nailResponse = _mapper.Map<GetOneMountingBoxResponse>(nail);

            return ResponseHandler.GetAppResponse(type, nailResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
