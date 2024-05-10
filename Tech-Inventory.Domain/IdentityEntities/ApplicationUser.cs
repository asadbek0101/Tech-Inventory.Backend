using Microsoft.AspNetCore.Identity;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Domain.IdentityEntities;

public class ApplicationUser : IdentityUser<int>
{
    public int RegionId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string RoleName { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public Region Region { get; set; }
    public List<UserRegion> UserRegions { get; set; }
}