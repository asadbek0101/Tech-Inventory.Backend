using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetOneObjectClassType;

public class GetOneObjectClassTypeHandler : IRequestHandler<GetOneObjectClassTypeRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneObjectClassTypeHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneObjectClassTypeRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var objectClassType = await _context.ObjectClassTypes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var objectClassTypeResponse = _mapper.Map<GetOneObjectClassTypeResponse>(objectClassType);

            return ResponseHandler.GetAppResponse(type, objectClassTypeResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
