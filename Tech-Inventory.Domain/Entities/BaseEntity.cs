using System.Text.Json.Serialization;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
}
