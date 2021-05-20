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

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                if(!ControleExecucao.run)
                {
                    ControleExecucao.run = true;
                    try
                    {
                        await StopAsync(stoppingToken);
                        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                        await this.integrationUpdates.Integrar();
                        await Task.Delay(40000, stoppingToken);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.Message);
                    }
                    finally
                    {
                        await StartAsync(stoppingToken);
                        ControleExecucao.run = false;
                    }
                }
            }
        }
    }
}
