var builder = DistributedApplication.CreateBuilder(args);

var weatherApi = builder.AddProject<Projects.AspireWeather_Weather_API>("weatherapi");

builder.AddNpmApp("webfrontend", "../aspire-weather-web")
    .WithReference(weatherApi)
    .WithEndpoint(containerPort: 3000, scheme: "http", env: "PORT")
    .AsDockerfileInManifest();

builder.Build().Run();
