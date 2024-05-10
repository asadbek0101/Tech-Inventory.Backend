using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.CameraFeature.GetOneCamera;

public class GetOneCameraHandler : IRequestHandler<GetOneCameraRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneCameraHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneCameraRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var camera = await _context
                .Cameras
                .Include(x => x.Model)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var cameraResponse = _mapper.Map<GetOneCameraResponse>(camera);

            return ResponseHandler.GetAppResponse(type, cameraResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
