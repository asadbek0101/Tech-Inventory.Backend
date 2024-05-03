using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NailFeature.GetOneNail;

public class GetOneNailHandler : IRequestHandler<GetOneNailRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneNailHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneNailRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var nail = await _context.Nails.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var nailResponse = _mapper.Map<GetOneNailResponse>(nail);

            return ResponseHandler.GetAppResponse(type, nailResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
