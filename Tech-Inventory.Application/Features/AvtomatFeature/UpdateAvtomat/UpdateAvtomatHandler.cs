using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AvtomatFeature.UpdateAvtomat;

public class UpdateAvtomatHandler : IRequestHandler<UpdateAvtomatRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAvtomatHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateAvtomatRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Id = 0;
        var Message = "Avtomat not found";
        try
        {
            var avtomat = await _context.Avtomats.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (avtomat != null)
            {
                avtomat.ModelId = request.ModelId;
                avtomat.Count = request.Count;
                avtomat.Info = request.Info;

                _context.Avtomats.Update(avtomat);
                await _unitOfWork.Save(cancellationToken);

                Id = avtomat.Id;
                Message = "Avtomat has updated!";

            }
            else
            {
                type = ResponseType.Failed;
            }

            return ResponseHandler.GetAppResponse(type, new UpdateAvtomatResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
