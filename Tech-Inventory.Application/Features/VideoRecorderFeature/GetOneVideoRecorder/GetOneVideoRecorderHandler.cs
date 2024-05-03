using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.VideoRecorderFeature.GetOneVideoRecorder;

public class GetOneVideoRecorderHandler : IRequestHandler<GetOneVideoRecorderRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneVideoRecorderHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneVideoRecorderRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var videoRecorder = await _context.VideoRecorders.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var videoRecorderResponse = _mapper.Map<GetOneVideoRecorderResponse>(videoRecorder);

            return ResponseHandler.GetAppResponse(type, videoRecorderResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
