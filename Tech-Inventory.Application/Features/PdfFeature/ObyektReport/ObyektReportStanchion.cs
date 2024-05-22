namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportStanchion
{
    public int Id { get; set; }
    public string StanchionType { get; set; }
    public string Count { get; set; }
}
