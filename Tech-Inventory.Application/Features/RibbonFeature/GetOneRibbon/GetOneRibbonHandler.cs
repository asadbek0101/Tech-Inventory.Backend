using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.RibbonFeature.GetOneRibbon;

public class GetOneRibbonHandler : IRequestHandler<GetOneRibbonRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneRibbonHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneRibbonRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var ribbon = await _context.Ribbons.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var ribbonResponse = _mapper.Map<GetOneRibbonResponse>(ribbon);

            return ResponseHandler.GetAppResponse(type, ribbonResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
