using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Domain.Entities;

public class Region : BaseEntity
{
    public string Name { get; set; }
    public string Info { get; set; }
    public double? Lat { get; set; }
    public double? Lng { get; set; }
    public List<NumberOfOrder> NumberOfOrders { get; set; }
    public List<District> Districts { get; set; }
    public List<Obyekt> Obyekts { get; set; }
    public List<ApplicationUser> Users { get; set; }
    public List<UserRegion> UserRegions { get; set; }
}