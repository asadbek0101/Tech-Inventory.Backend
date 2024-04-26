using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AttechmentFeature.GetOneAttechment;

public class GetOneAttechmentHandler : IRequestHandler<GetOneAttechmentRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneAttechmentHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneAttechmentRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var attechment = await _context.Attachments.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var attechmentResponse = _mapper.Map<GetOneAttechmentResponse>(attechment);

            return ResponseHandler.GetAppResponse(type, attechmentResponse.Path);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
