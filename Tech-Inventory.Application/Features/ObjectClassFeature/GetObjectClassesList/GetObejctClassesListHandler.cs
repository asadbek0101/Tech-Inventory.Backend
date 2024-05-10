using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassesList;

public class GetObejctClassesListHandler : IRequestHandler<GetObjectClassesListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetObejctClassesListHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetObjectClassesListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var objectClasses = await _context
                .ObjectClasses
                .Where(x=>x.ObjectClassTypeId == request.ObjectClassTypeId)
                .ToListAsync();

            var objectClassResponse = _mapper.Map<List<GetObjectClassesListResponse>>(objectClasses);

            return ResponseHandler.GetAppResponse(type, objectClassResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
