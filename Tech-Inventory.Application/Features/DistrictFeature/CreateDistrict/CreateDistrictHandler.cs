using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.DistrictFeature.CreateDistrict;

public class CreateDistrictHandler : IRequestHandler<CreateDistrictRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDistrictHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(CreateDistrictRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var district = _mapper.Map<District>(request);
            _context.Districts.Add(district);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateDistrictResponse { Id = district.Id, Message = "District has created" });
        }
        catch (Exception ex)
        {
            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
