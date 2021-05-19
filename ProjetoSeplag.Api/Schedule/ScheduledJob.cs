using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjetoSeplag.Infra.Integration;
using Quartz;
using System;
using System.Threading.Tasks;

namespace ProjetoSeplag.Api.Schedule
{
    public class ScheduledJob : IJob
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ScheduledJob> logger;
        private readonly IIntegrationUpdates integrationUpdates;

        public ScheduledJob(IConfiguration configuration, ILogger<ScheduledJob> logger, IIntegrationUpdates integrationUpdates)
        {
            this.logger = logger;
            this.integrationUpdates = integrationUpdates;
            this.configuration = configuration;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            await this.integrationUpdates.Integrar();

            this.logger.LogWarning($"Schedule run {DateTime.Now.ToLongTimeString()}");

            await Task.CompletedTask;

        }
    }
}
