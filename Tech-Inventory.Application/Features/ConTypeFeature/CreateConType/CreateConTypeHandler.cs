using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ConTypeFeature.CreateConType;

public class CreateConTypeHandler : IRequestHandler<CreateConTypeRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateConTypeHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(CreateConTypeRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var id = 0;
            if(request.Type == ConnectionTypes.FTTX)
            {
                var fttx = _mapper.Map<FTTX>(request);
                _context.FTTXs.Add(fttx);
                await _unitOfWork.Save(cancellationToken);
                id = fttx.Id;
            }

            if (request.Type == ConnectionTypes.GPON)
            {
                var gpon = _mapper.Map<GPON>(request);
                _context.GPONs.Add(gpon);
                await _unitOfWork.Save(cancellationToken);
                id = gpon.Id;
            }

            if (request.Type == ConnectionTypes.GSM)
            {
                var gsm = _mapper.Map<GSM>(request);
                _context.GSMs.Add(gsm);
                await _unitOfWork.Save(cancellationToken);
                id = gsm.Id;
            }

            return ResponseHandler.GetAppResponse(type, new CreateConTypeResponse { Id = id, Message = "dd" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
