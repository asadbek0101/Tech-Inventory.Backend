using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetObejctClassTypesList;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetObjectClassTypesList;

public class GetObjectClassTypesListHandler : IRequestHandler<GetObjectClassTypesListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetObjectClassTypesListHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetObjectClassTypesListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var objectClassTypes = await _context.ObjectClassTypes.ToListAsync();

            var objectClassTypesResponse = _mapper.Map<List<GetObjectClassTypesListResponse>>(objectClassTypes);

            return ResponseHandler.GetAppResponse(type, objectClassTypesResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
