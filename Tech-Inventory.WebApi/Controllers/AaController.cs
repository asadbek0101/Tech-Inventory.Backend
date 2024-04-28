using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Tech_Inventory.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;

namespace Tech_Inventory.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AaController : ControllerBase
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AaController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpGet("/Check")]
    public async Task<ActionResult> CheckProject()
    {

        return Ok("Project is working");
    }

    [Authorize(Policy = "CreateUser")]
    [HttpGet("GetName")]
    public async Task<ActionResult> GetName(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        var role = await _userManager.GetRolesAsync(user);

        return Ok(role);
    }

    [HttpPost("CreateRole")]
    public async Task<ActionResult> CreateRole([FromBody] CreateRoleRequest request)
    {
        var role = new ApplicationRole
        {
            Name = request.Name,
        };
        var result = await _roleManager.CreateAsync(role);
        return Ok(result);
    }

    [HttpPost("AddRoleToUser")]
    public async Task<ActionResult> AddRol([FromBody] AddRoleToUserRequest request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        
        if(user == null)
        {
            return Ok("User not found");
        }
        else
        {
            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            return Ok(result);
        }

    }

    [HttpPost("AddClaimToUser")]
    public async Task<ActionResult> AddClaimToUser([FromBody] AddClaimToUserRequest request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (user == null)
        {
            return Ok("User not found");
        }
        else
        {
            var result = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, request.ClaimName));
            return Ok(result);
        }

    }

    [HttpPost("AddClaimToRole")]
    public async Task<ActionResult> AddClaimToRole([FromBody] AddClaimToRoleRequest request)
    {
        var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());

        if (role == null)
        {
            return Ok("Role not found");
        }
        else
        {
            var result = await _roleManager.AddClaimAsync(role, new Claim(request.ClaimType, request.ClaimName));
            return Ok(result);
        }

    }

    public sealed record CreateRoleRequest
    {
        public string Name { get; set; }
    }
    

    public sealed record AddRoleToUserRequest
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }

    public sealed record AddClaimToUserRequest
    {
        public int UserId { get; set; }
        public string ClaimName { get; set; }
    }

    public sealed record AddClaimToRoleRequest
    {
        public int RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimName { get; set; }
    }
}
