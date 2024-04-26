using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AttechmentFeature.GetAllAttechments;

public class GetAllAttechmentsHandler : IRequestHandler<GetAllAttechmentsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllAttechmentsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllAttechmentsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var attechments = await _context.Attachments.Where(x => x.ObyektId == request.ObyektId).ToListAsync();

            var attechmentsResponse = _mapper.Map<List<GetAllAttechmentsResponse>>(attechments);

            return ResponseHandler.GetAppResponse(type, attechmentsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
