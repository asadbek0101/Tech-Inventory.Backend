using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.BracketFeature.GetOneBracket;

public class GetOneBracketHandler : IRequestHandler<GetOneBracketRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneBracketHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneBracketRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var bracket = await _context.Brackets.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var bracketResponse = _mapper.Map<GetOneBracketResponse>(bracket);

            return ResponseHandler.GetAppResponse(type, bracketResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
