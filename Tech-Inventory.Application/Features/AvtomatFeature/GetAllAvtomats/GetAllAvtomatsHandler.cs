using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.AvtomatFeature.GetAllAvtomats;

public class GetAllAvtomatsHandler : IRequestHandler<GetAllAvtomatsRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllAvtomatsHandler(ITechInventoryDB context, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<ApiResponse> Handle(GetAllAvtomatsRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var avtomats = await _context.Avtomats
                .Where(x => x.ObyektId == request.ObyektId)
                .Include(x => x.Model)
                .ToListAsync();

            var avtomatsResponse = _mapper.Map<List<GetAllAvtomatsResponse>>(avtomats);

            foreach (var item in avtomatsResponse)
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

            return ResponseHandler.GetAppResponse(type, avtomatsResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
