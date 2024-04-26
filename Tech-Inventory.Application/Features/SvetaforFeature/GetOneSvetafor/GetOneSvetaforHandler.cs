using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SvetaforFeature.GetOneSvetafor;

public class GetOneSvetaforHandler : IRequestHandler<GetOneSvetaforRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneSvetaforHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneSvetaforRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var svetafor = await _context.SvetoforDetectors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var svetaforResponse = _mapper.Map<GetOneSvetaforResponse>(svetafor);

            return ResponseHandler.GetAppResponse(type, svetaforResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
