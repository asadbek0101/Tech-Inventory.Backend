using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.GetAllVideoRecorders;

public class GetAllVideoRecordersHandler : IRequestHandler<GetAllVideoRecordersRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllVideoRecordersHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllVideoRecordersRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var vidoRecorders = await _context.VideoRecorders
                .Where(x => x.ObyektId == request.ObyektId)
                .Include(x => x.Model)
                .ToListAsync();

            var vidoRecordersResponse = _mapper.Map<List<GetAllVideoRecordersResponse>>(vidoRecorders);

            return ResponseHandler.GetAppResponse(type, vidoRecordersResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
