using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.GlueFornailFeature.GetAllGlues;

public class GetAllGluesHandler : IRequestHandler<GetAllGluesRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetAllGluesHandler(ITechInventoryDB context, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<ApiResponse> Handle(GetAllGluesRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var glues = await _context.GlueForNails
                .Where(x => x.ObyektId == request.ObyektId)
                .ToListAsync();

            var gluesResponse = _mapper.Map<List<GetAllGluesResponse>>(glues);

            foreach (var item in gluesResponse)
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

            return ResponseHandler.GetAppResponse(type, gluesResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
