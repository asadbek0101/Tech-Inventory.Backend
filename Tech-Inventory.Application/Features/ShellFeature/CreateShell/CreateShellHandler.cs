using AutoMapper;
using MediatR;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ShellFeature.CreateShell;

public class CreateShellHandler : IRequestHandler<CreateShellRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateShellHandler(ITechInventoryDB context, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(CreateShellRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var shell = _mapper.Map<Shell>(request);
            _context.Shells.Add(shell);
            await _unitOfWork.Save(cancellationToken);

            return ResponseHandler.GetAppResponse(type, new CreateShellResponse { Id = shell.Id, Message = "Avtomat has created" });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
