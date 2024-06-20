using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.AttachmentFeature.GetAllAttachments;

public class GetAllAttachmentsHandler : IRequestHandler<GetAllAttachmentsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllAttachmentsHandler(ITechInventoryDB context, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetAllAttachmentsRequest request, CancellationToken cancellationToken)
    {

        var type = ResponseType.Success;
        try
        {
            var attachments = await _context.Attachments
                .Where(x => x.ObyektId == request.ObyektId)
                .ToListAsync();

            var attachmentsResponse = _mapper.Map<List<GetAllAttachmentsResponse>>(attachments);

            return ResponseHandler.GetAppResponse(type, attachmentsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
