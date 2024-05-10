using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.BoxFeature.GetAllBoxes;

public class GetAllBoxesHandler : IRequestHandler<GetAllBoxesRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllBoxesHandler(ITechInventoryDB context, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetAllBoxesRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var boxes = await _context.Boxes
                .Where(x => x.ObyektId == request.ObyektId)
                .Include(x => x.Model)
                .ToListAsync();

            var boxesResponse = _mapper.Map<List<GetAllBoxesResponse>>(boxes);

            foreach (var item in boxesResponse)
            {
                var CreatorUser = await _userManager.FindByIdAsync(item.CreatedBy.ToString());
                var UpdatorUser = new ApplicationUser();

                if (item.UpdatedBy != null)
                {
                    UpdatorUser = await _userManager.FindByIdAsync(item.UpdatedBy.ToString());
                }

                if (CreatorUser != null)
                {
                    item.Creator = CreatorUser.UserName;
                }

                if (UpdatorUser != null)
                {
                    item.Updator = UpdatorUser.UserName;
                }
            }

            return ResponseHandler.GetAppResponse(type, boxesResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
