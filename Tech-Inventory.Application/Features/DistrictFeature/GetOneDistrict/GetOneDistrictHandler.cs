using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.DistrictFeature.GetOneDistrict;

public class GetOneDistrictHandler : IRequestHandler<GetOneDistrictRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneDistrictHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneDistrictRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var district = await _context.Districts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var districtResponse = _mapper.Map<GetOneDistrictResponse>(district);

            return ResponseHandler.GetAppResponse(type, districtResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
