using WindowsService;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    });

var host = builder.Build();

await host.RunAsync(); 

