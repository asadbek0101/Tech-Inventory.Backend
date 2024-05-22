namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportSocket
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
}
