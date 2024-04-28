using Microsoft.AspNetCore.Identity;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Domain.IdentityEntities;

public class ApplicationUser : IdentityUser<int>
{
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public Region Region { get; set; }
    public District District { get; set; }
    public List<UserRegion> UserRegions { get; set; }
}
