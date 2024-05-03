using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.BoxFeature.GetOneBox;

public class GetOneBoxHandler : IRequestHandler<GetOneBoxRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneBoxHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneBoxRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var box = await _context.Boxes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var boxResponse = _mapper.Map<GetOneBoxResponse>(box);

            return ResponseHandler.GetAppResponse(type, boxResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
