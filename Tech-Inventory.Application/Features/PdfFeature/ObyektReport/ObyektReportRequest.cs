using MediatR;

namespace Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

public sealed record ObyektReportRequest : IRequest<ObyektReportResponse>
{
    public int Id { get; set; }
}
