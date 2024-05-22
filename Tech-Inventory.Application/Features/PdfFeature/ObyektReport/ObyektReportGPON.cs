namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportGPON
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string NumberOfPort { get; set; }
}
