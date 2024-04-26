using Microsoft.AspNetCore.Identity;

namespace Tech_Inventory.Domain.IdentityEntities;

public class ApplicationRole : IdentityRole<int>
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
}
