using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetoSeplag.Infra.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoSeplag.WorkServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IIntegrationUpdates integrationUpdates;

        public Worker(ILogger<Worker> logger, IIntegrationUpdates integrationUpdates)
        {
            _logger = logger;
            this.integrationUpdates = integrationUpdates;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await this.integrationUpdates.Integrar();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(300, stoppingToken);
            }
        }
    }
}
