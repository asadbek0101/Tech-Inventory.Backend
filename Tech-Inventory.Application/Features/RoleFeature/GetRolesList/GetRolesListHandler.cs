using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Application.Features.RoleFeature.GetRolesList;

public class GetRolesListHandler : IRequestHandler<GetRolesListRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IMapper _mapper;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public GetRolesListHandler(ITechInventoryDB context, IMapper mapper, RoleManager<ApplicationRole> roleManager)
    {
        _context = context;
        _mapper = mapper;
        _roleManager = roleManager;
    }
    public async Task<ApiResponse> Handle(GetRolesListRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        try
        {
            var roles = await _roleManager
                .Roles
                .Where(x => x.Name != "SuperAdmin")
                .ToListAsync();

            var rolesResponse = _mapper.Map<List<GetRolesListResponse>>(roles);

            return ResponseHandler.GetAppResponse(type, rolesResponse);

        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
