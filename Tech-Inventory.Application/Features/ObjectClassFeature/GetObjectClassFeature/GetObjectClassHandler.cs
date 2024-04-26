using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.ObjectClassFeature.GetObjectClassFeature;

public class GetObjectClassHandler : IRequestHandler<GetObjectClassRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetObjectClassHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetObjectClassRequest request, CancellationToken cancellationToken)
    {
        ResponseType type = ResponseType.Success;
        try
        {
            if(request.ObjectClassTypeId == 0)
            {
                var objectClassTypes = await _context.ObjectClassTypes.ToListAsync();

                return ResponseHandler.GetAppResponse(type, _mapper.Map<List<GetObjectClassResponse>>(objectClassTypes));
            }
            else
            {
                var objectClasses = await _context.ObjectClasses
                    .Where(x=>x.ObjectClassTypeId == request.ObjectClassTypeId)
                .ToListAsync();

                return ResponseHandler.GetAppResponse(type, _mapper.Map<List<GetObjectClassResponse>>(objectClasses));
            }
            
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
