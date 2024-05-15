namespace Tech_Inventory.Application.Features.ObyektFeature.GetOneObyekt;

public sealed record GetOneObyektFileResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FileName { get; set; }
    public string FileSize { get; set; }
}
