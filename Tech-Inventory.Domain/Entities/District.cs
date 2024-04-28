using System.Text.Json.Serialization;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Domain.Entities;

public class District : BaseEntity
{
    public int RegionId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }

    [JsonIgnore]
    public Region Region { get; set; }
    public List<Obyekt> Obyekts { get; set; }
    public List<ApplicationUser> Users { get; set; }
}
