using System;
using System.Threading; 
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CamadaDados;

namespace WindowsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Inserir _inserir;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            string connStr = configuration.GetConnectionString("DefaultConnection");
            _inserir = new Inserir(connStr);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Inserindo no banco: {time}", DateTimeOffset.Now);

                    await _inserir.InserirDadosAsync();

                    _logger.LogInformation("Inseriu");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Deu pau");
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
    
