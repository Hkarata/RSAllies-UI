var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.RSAllies>("rsallies");

builder.Build().Run();
