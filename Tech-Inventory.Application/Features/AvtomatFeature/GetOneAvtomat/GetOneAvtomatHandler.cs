using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.AvtomatFeature.GetOneAvtomat;

public class GetOneAvtomatHandler : IRequestHandler<GetOneAvtomatRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;

    public GetOneAvtomatHandler(ITechInventoryDB context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ApiResponse> Handle(GetOneAvtomatRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var avtomat = await _context.Avtomats.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            var avtomatResponse = _mapper.Map<GetOneAvtomatResponse>(avtomat);

            return ResponseHandler.GetAppResponse(type, avtomatResponse);
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
