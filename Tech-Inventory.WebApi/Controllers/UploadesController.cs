using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tech_Inventory.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadesController : ControllerBase
{
    [HttpPost("UploadFile")]
    public async Task<IActionResult> Post(List<IFormFile> files)
    {
        string Message = "";

		try
		{
			foreach (var file in files)
			{
				if(file.Length > 0)
				{
					var filePath = Path.GetFullPath("C:\\Uploaded\\", file.FileName);
					using (var stream = System.IO.File.Create(filePath))
					{
						await file.CopyToAsync(stream);
						Message = "Your file is uploaded successfully.";
					}
				}
			}
		}
		catch (Exception)
		{

			Message = "Sorry, something went wrong, please try letter again";
		}

		return Ok(Message);
    }
}
