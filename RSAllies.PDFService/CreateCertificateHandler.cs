using RSAllies.Data.Contracts;
using RSAllies.PDFService.Services;

namespace RSAllies.PDFService;

public class CreateCertificateHandler(ILogger<CreateCertificateHandler> logger)
{
    public async Task Handle(CreateCertificate request)
    {
        CertificateService.CreateCertificate(request.Name, request.UserId);
        logger.LogInformation("Certificate for user with Id {UserId} has been created",request.UserId);
    }
}