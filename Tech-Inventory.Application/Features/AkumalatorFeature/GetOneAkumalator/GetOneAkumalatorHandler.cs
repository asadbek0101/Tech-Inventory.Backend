using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.GetOneAkumalator;

public class GetOneAkumalatorHandler : IRequestHandler<GetOneAkumalatorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneAkumalatorHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneAkumalatorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var akumalator = await _context.Akumalators.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var akumalatorResponse = _mapper.Map<GetOneAkumalatorResponse>(akumalator);

            return ResponseHandler.GetAppResponse(type, akumalatorResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
