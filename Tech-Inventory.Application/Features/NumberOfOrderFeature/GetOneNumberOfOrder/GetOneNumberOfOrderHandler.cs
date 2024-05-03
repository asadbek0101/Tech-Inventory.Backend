using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NumberOfOrderFeature.GetOneNumberOfOrder;

public class GetOneNumberOfOrderHandler : IRequestHandler<GetOneNumberOfOrderRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneNumberOfOrderHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneNumberOfOrderRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var numberOfOrder = await _context
                .NumberOfOrders
                .Include(x => x.Region)
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var numberOfOrderResponse = _mapper.Map<GetOneNumberOfOrderResponse>(numberOfOrder);

            return ResponseHandler.GetAppResponse(type, numberOfOrderResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
