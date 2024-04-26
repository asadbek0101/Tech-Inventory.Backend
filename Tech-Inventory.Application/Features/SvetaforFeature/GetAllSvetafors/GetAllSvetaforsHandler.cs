using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.SvetaforFeature.GetAllSvetafors;

public class GetAllSvetaforsHandler : IRequestHandler<GetAllSvetaforsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllSvetaforsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllSvetaforsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Failed;
        try
        {
            var svetafors = await _context.SvetoforDetectors
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.SvetaforType == request.svetaforType)
                .Include(x => x.Model)
                .ToListAsync();

            var svetaforsResponse = _mapper.Map<List<GetAllSvetaforsResponse>>(svetafors);

            return ResponseHandler.GetAppResponse(type, svetaforsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
