using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.CableFeature.UpdateCabel;

public class UpdateCabelHandler : IRequestHandler<UpdateCabelRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCabelHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateCabelRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Cabel not found!";
        var Id = 0;
        try
        {
            var cabel = await _context.Cabels.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (cabel != null)
            {

                cabel.ModelId = request.ModelId;
                cabel.CabelTypeId = request.CabelTypeId;
                cabel.Meter = request.Meter;
                cabel.Info = request.Info;

                _context.Cabels.Update(cabel);
                await _unitOfWork.Save(cancellationToken);
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateCabelResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
