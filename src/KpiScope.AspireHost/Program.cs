var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.KpiScope_Web>("web");

builder.Build().Run();
