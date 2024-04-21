using Microsoft.AspNetCore.Mvc;
using RSAllies.PDFService.Services;

namespace RSAllies.PDFService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetUserCertificate(Guid userId)
        {
            var filename = $"{userId}.pdf";
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "PDFs", filename);
                var stream = new FileStream(path, FileMode.Open);
                return File(stream, "application/octet-stream", filename);
            }
            catch (FileNotFoundException)
            {
                return NotFound("The requested file does not exist.");
            }
            catch (Exception)
            {
                // Log the exception details here for debugging purposes
                return StatusCode(500, "An error occurred while trying to download the file.");
            }
        }

        [HttpPost]
        public IActionResult CreateUserCertificate(Guid UserId)
        {
            CertificateService.CreateCertificate("John Doe", UserId);
            return Ok();
        }

    }
}
