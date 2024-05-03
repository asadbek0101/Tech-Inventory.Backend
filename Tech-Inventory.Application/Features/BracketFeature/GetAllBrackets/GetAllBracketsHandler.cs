using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.BracketFeature.GetAllBrackets;

public class GetAllBracketsHandler : IRequestHandler<GetAllBracketsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetAllBracketsHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetAllBracketsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var brackets = await _context.Brackets
                .Where(x => x.ObyektId == request.ObyektId)
                .Where(x => x.BracketType == request.bracketType)
                .Include(x => x.Model)
                .ToListAsync();

            var bracketsResponse = _mapper.Map<List<GetAllBracketsResponse>>(brackets);

            return ResponseHandler.GetAppResponse(type, bracketsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
