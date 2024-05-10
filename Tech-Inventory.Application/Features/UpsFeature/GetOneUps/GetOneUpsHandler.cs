using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.UpsFeature.GetOneUps;

public class GetOneUpsHandler : IRequestHandler<GetOneUpsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneUpsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneUpsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var ups = await _context
                .Ups
                .Include(x => x.Model)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var upsResponse = _mapper.Map<GetOneUpsReponse>(ups);

            return ResponseHandler.GetAppResponse(type, upsResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
