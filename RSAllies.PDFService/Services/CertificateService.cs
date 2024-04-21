using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace RSAllies.PDFService.Services;

public static class CertificateService
{
    public static void CreateCertificate(string name, Guid userId)
    {
        var filename = $"{userId}.pdf";
        var pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "PDFs", filename);

        Document.Create(document =>
        {
            document.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(2.54f, Unit.Centimetre);

                page.Header().Height(0, Unit.Centimetre);
                page.Footer().Height(0, Unit.Centimetre);

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(column =>
                    {
                        column.RelativeColumn();
                        column.ConstantColumn(100);
                    });



                    table.Cell().AlignCenter()
                        .Text("Certificate of Recognition")
                        .FontFamily("Segoe Script")
                        .FontSize(40)
                        .FontColor(Colors.Red.Accent3);

                    table.Cell().Image("Images/safety.png").FitArea();

                    table.Cell().ColumnSpan(2)
                        .Height(100)
                        .AlignCenter()
                        .Text("This certificate is proudly presented to:")
                        .FontFamily("Bahnschrift")
                        .FontSize(16);

                    table.Cell().ColumnSpan(2)
                        .Height(100)
                        .AlignCenter()
                        .Text($"{name}")
                        .DecorationDouble()
                        .FontFamily("Segoe Print")
                        .FontSize(40);

                    table.Cell().ColumnSpan(2)
                        .Height(30)
                        .AlignCenter()
                        .Text("Your hard work and dedication have paid off, and you are now one step closer to obtaining your driver’s license.")
                        .FontFamily("Bahnschrift")
                        .FontSize(14);
                    table.Cell().ColumnSpan(2)
                        .Height(100)
                        .AlignCenter()
                        .Text("Congratulations on passing the Driver’s Theoretical Test")
                        .FontFamily("Bahnschrift")
                        .FontSize(14);
                    table.Cell().ColumnSpan(2)
                        .AlignRight()
                        .Text($"Certificate Id.: {userId}")
                        .FontFamily("Bahnschrift");
                });
            });
        })
        .GeneratePdf(pdfPath);
    }
}