using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetoSeplag.Infra.Integration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ProjetoSeplag.WorkServices
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private readonly IIntegrationUpdates integrationUpdates;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger, IIntegrationUpdates integrationUpdates)
        {
            _logger = logger;
            this.integrationUpdates = integrationUpdates;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            if (!ControleExecucao.run)
            {
                ControleExecucao.run = true;
                try
                {
                    StopAsync(CancellationToken.None);
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    this.integrationUpdates.Integrar().GetAwaiter().GetResult(); 
                    //await Task.Delay(40000, stoppingToken);
                    _logger.LogInformation("Worker finish insert: {time}", DateTimeOffset.Now);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
                finally
                {
                    StartAsync(CancellationToken.None);
                    ControleExecucao.run = false;
                    _logger.LogInformation("Worker Finish at: {time}", DateTimeOffset.Now);
                }
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
