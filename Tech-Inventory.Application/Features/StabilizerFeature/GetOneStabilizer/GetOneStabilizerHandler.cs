using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.StabilizerFeature.GetOneStabilizer;

public class GetOneStabilizerHandler : IRequestHandler<GetOneStabilizerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneStabilizerHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneStabilizerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var stabilizer = await _context.Stabilizers.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var stabilizerResponse = _mapper.Map<GetOneStabilizerResponse>(stabilizer);

            return ResponseHandler.GetAppResponse(type, stabilizerResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
