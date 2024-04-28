namespace Tech_Inventory.Application.Features.RoleFeature.GetRolesList;

public sealed record GetRolesListResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
}
