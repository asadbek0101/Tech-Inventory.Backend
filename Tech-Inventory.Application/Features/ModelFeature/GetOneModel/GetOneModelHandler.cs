using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ModelFeature.GetOneModel;

public class GetOneModelHandler : IRequestHandler<GetOneModelRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneModelHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneModelRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var model = await _context.Models
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            var modelResponse = _mapper.Map<GetOneModelResponse>(model);

            return ResponseHandler.GetAppResponse(type, modelResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
