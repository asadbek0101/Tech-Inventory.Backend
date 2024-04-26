using AutoMapper;
using MediatR;
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
        try
        {
            var avtomat = _mapper.Map<Avtomat>(request);
            _context.Avtomats.Update(avtomat);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new UpdateAvtomatResponse { Id = avtomat.Id, Message = "Avtomat has updated" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
