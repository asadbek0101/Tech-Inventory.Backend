namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportAvtomat
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Count { get; set; }
    public string Info { get; set; }

}
