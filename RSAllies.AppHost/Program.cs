var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.RSAllies>("Web-frontend");
builder.AddProject<Projects.RSAllies_MarkingService>("MarkingService");
builder.AddProject<Projects.RSAllies_PDFService>("PDFService");

builder.Build().Run();
