using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;

namespace Tech_Inventory.Application.Features.NailFeature.UpdateNail;

public class UpdateNailHandler : IRequestHandler<UpdateNailRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNailHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateNailRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var nail = await _context.Nails.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var Message = "Nail not found";
            var Id = 0;

            if (nail != null)
            {
                nail.Weight = request.Weight;
                nail.Info = request.Info;

                _context.Nails.Update(nail);
                await _unitOfWork.Save(cancellationToken);
                Message = "Nail has updated!";
                Id = nail.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }
            

            return ResponseHandler.GetAppResponse(type, new UpdateNailResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
