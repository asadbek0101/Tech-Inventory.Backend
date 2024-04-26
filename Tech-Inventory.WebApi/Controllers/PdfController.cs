using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using System.Text.Json;
using Tech_Inventory.Application.Features.PdfFeature.ObyektReport;


namespace Tech_Inventory.WebApi.Controllers;

public class PdfController : BaseController
{
    [HttpGet("GetObyektReport")]
    public async Task<IActionResult> GeneratePdf(int Id)
    {
        var obyektReport = await Mediator.Send(new ObyektReportRequest { Id = Id });

        var options = new LaunchOptions
        {
            Headless = true,
        };

        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        using var browser = await Puppeteer.LaunchAsync(options);
        using var page = await browser.NewPageAsync();
        using var memoryStream = new MemoryStream();

        var url = Url.ActionLink("Index", "PdfGenerate", new { model = JsonSerializer.Serialize(obyektReport) });

        await page.GoToAsync(url);

        var pdfStream = await page.PdfDataAsync();

        return File(pdfStream, "application/pdf", "ObyektReport.pdf");
    }
}




