using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ModelFeature.GetModelsList;

public class GetModelsListHandler : IRequestHandler<GetModelsListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetModelsListHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetModelsListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var models = await _context.Models.Where(x => x.Type == request.Type).ToListAsync();

            var modelsResponse = _mapper.Map<List<GetModelsListResponse>>(models);

            return ResponseHandler.GetAppResponse(type, modelsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
