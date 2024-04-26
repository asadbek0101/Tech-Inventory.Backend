using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.AvtomatFeature.CreateAvtomat;

public class CreateAvtomatHandler : IRequestHandler<CreateAvtomatRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAvtomatHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateAvtomatRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var avtomat = _mapper.Map<Avtomat>(request);
            _context.Avtomats.Add(avtomat);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateAvtomatResponse { Id = avtomat.Id, Message = "Avtomat has created" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
