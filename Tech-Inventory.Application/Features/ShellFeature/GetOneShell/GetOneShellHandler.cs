using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ShellFeature.GetOneShell;

public class GetOneShellHandler : IRequestHandler<GetOneShellRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneShellHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneShellRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var shell = await _context.Shells.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var shellResponse = _mapper.Map<GetOneShellResponse>(shell);

            return ResponseHandler.GetAppResponse(type, shellResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
