using Microsoft.AspNetCore.Mvc;

namespace RSAllies.PDFService.Controllers;


[Microsoft.AspNetCore.Components.Route("api/[Controller]")]
public class FilesController : ControllerBase
{
    [HttpGet("DownloadFile")]
    public IActionResult DownloadFile(string filename)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "PDFs", filename);
        var stream = new FileStream(path, FileMode.Open);
        return File(stream, "application/octet-stream", filename);
    }
}