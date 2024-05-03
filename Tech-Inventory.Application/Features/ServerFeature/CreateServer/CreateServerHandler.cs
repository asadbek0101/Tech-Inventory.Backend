using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ServerFeature.CreateServer;

public class CreateServerHandler : IRequestHandler<CreateServerRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateServerHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateServerRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var server = _mapper.Map<Server>(request);
            _context.Servers.Add(server);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateServerResponse { Id = server.Id, Message = "Server has created" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
