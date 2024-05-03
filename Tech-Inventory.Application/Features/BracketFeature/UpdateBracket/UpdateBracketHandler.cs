using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.BracketFeature.UpdateBracket;

public class UpdateBracketHandler : IRequestHandler<UpdateBracketRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBracketHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateBracketRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var bracket = _mapper.Map<Bracket>(request);
            _context.Brackets.Update(bracket);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateBracketResponse { Id = bracket.Id, Message = "Bracket has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
