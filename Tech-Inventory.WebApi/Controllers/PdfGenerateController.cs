using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Tech_Inventory.Application.Features.PdfFeature.ObyektReport;

namespace Tech_Inventory.WebApi.Controllers;

public class PdfGenerateController : Controller 
{
    public IActionResult Index(string model)
    {
        var obyektReport = JsonSerializer.Deserialize<ObyektReportResponse>(model);
        return View(obyektReport);
    }
}
