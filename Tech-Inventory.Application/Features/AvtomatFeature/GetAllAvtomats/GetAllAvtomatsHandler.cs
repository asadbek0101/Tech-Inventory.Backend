using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AvtomatFeature.GetAllAvtomats;

public class GetAllAvtomatsHandler : IRequestHandler<GetAllAvtomatsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllAvtomatsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllAvtomatsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var avtomats = await _context.Avtomats
                .Where(x => x.ObyektId == request.ObyektId)
                .Include(x => x.Model)
                .ToListAsync();

            var avtomatsResponse = _mapper.Map<List<GetAllAvtomatsResponse>>(avtomats);

            return ResponseHandler.GetAppResponse(type, avtomatsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
