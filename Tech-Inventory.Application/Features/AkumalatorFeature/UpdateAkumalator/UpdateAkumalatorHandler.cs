using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AkumalatorFeature.UpdateAkumalator;

public class UpdateAkumalatorHandler : IRequestHandler<UpdateAkumalatorRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAkumalatorHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateAkumalatorRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Id = 0;
        var Message = "Akumalator not found";
        try
        {
            var akumalator = await _context.Akumalators.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(akumalator != null)
            {
                akumalator.Power = request.Power;
                akumalator.Count = request.Count;
                akumalator.Info = request.Info;

                _context.Akumalators.Update(akumalator);
                await _unitOfWork.Save(cancellationToken);

                Message = "Akumnalator has updated!";
                Id = akumalator.Id;
            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateAkumalatorResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
