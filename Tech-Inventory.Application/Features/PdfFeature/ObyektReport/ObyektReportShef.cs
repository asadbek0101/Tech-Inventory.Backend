namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportShef
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public string Number { get; set; }
    public string? Info { get; set; }
}
