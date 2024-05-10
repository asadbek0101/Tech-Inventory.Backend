using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShelfFeature.UpdateShelf;

public class UpdateShelfHandler : IRequestHandler<UpdateShelfRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateShelfHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateShelfRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Shelf not found";
        var Id = 0;
        try
        {
            var shelf = await _context.Shelves.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(shelf != null)
            {
                shelf.SerialNumber = request.SerialNumber;
                shelf.Number = request.Number;
                shelf.Info = request.Info;

                _context.Shelves.Update(shelf);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateShelfResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
