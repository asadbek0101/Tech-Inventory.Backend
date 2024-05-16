using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;

namespace Tech_Inventory.WebApi.Controllers;

public class PdfController : ControllerBase
{
    [HttpGet("GetObyektReport")]
    public async Task<IActionResult> GeneratePdf()
    {

        var options = new LaunchOptions
        {
            Headless = true,
        };

        using var browser = await Puppeteer.LaunchAsync(options);
        using var page = await browser.NewPageAsync();

        var htmlContent = "";

        htmlContent += "<h1 style='color: red; font-family: Arial, Helvetica, sans-serif; text-align: center;'> Asadbek Rejabboyev </h1>";

        await page.SetContentAsync(htmlContent);

        var pdfStream = await page.PdfDataAsync();

        return File(pdfStream, "application/pdf", "ObyektReport.pdf");
    }

}




