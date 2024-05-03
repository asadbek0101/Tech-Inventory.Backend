using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ShellFeature.GetAllShells;

public class GetAllShellsHandler : IRequestHandler<GetAllShellsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllShellsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllShellsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var shells = await _context.Shells
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.ShellType == request.ShellType)
                .ToListAsync();

            var shellsResponse = _mapper.Map<List<GetAllShellsResponse>>(shells);

            return ResponseHandler.GetAppResponse(type, shellsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
