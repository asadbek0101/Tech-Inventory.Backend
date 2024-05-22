namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportShef
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string SerialNumber { get; set; }
    public string Number { get; set; }
}
