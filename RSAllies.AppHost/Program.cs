var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.RSAllies>("Web-frontend");
builder.AddProject<Projects.RSAllies_Marker>("MarkingServiceS");

builder.Build().Run();
