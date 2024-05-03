using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ModelFeature.GetAllModels;

public class GetAllModelsHandler : IRequestHandler<GetAllModelsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IPaginator _paginator;

    public GetAllModelsHandler(ITechInventoryDB context, IMapper mapper, IPaginator paginator)
    {
        _context = context;
        _mapper = mapper;
        _paginator = paginator;
    }
    public async Task<ApiResponse> Handle(GetAllModelsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var models = await _context.Models
                .OrderBy(x => x.Id)
                .ToListAsync();
            var skipRows = _paginator.Offset(request.PageNumber, request.PageSize);

            if (request.SearchValue != null)
            {
                models = models
                    .Where(x => x.Name.ToUpper().Contains(request.SearchValue.ToUpper()))
                    .ToList();
            }

            if (request.Type != ModelTypes.All)
            {
                models = models
                    .Where(x => x.Type == request.Type)
                    .ToList();
            }

            models = models
                    .Skip(skipRows)
                    .Take(request.PageSize)
                    .ToList();

            var modelsResponse = _mapper.Map<List<GetAllModelsResponse>>(models);
            var totalRowCount = await _context.Models.CountAsync();
            var totalPageCount = _paginator.GetTotalPageCount(request.PageSize, totalRowCount);
            var response = new PaginationResponse { Data = modelsResponse, TotalRowCount = totalRowCount, TotalPageCount = totalPageCount };

            return ResponseHandler.GetAppResponse(type, response);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
