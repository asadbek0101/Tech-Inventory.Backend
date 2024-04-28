using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Domain.Entities;

public class UserRegion : BaseEntity
{
    public int RegionId { get; set; }
    public int UserId { get; set; }
    public Region Region { get; set; }
    public ApplicationUser User { get; set; }
}
