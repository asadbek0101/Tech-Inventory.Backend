namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportCabel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Meter { get; set; }
    public string? Info { get; set; }
}
