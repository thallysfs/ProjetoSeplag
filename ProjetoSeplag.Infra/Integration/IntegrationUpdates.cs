using Microsoft.Extensions.Logging;
using ProjetoSeplag.Aplication.Updates.Dtos;
using ProjetoSeplag.Aplication.Updates.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetoSeplag.Infra.Integration
{
    public class IntegrationUpdates : IIntegrationUpdates
    {
        private readonly IUpdateServices updateServices;
        private readonly HttpClient httpClient;
        private readonly ILogger<IntegrationUpdates> logger;

        public IntegrationUpdates(IUpdateServices updateServices, ILogger<IntegrationUpdates> logger)
        {
            this.updateServices = updateServices;
            this.httpClient = new HttpClient();
            this.logger = logger;
        }

        public async Task Integrar()
        {
            this.logger.LogInformation("Início de execução");

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await httpClient.GetAsync("https://api.msrc.microsoft.com/cvrf/v2.0/updates");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<UpdatesDto>(responseStream);
                await updateServices.Insert(dto);
                this.logger.LogInformation("Registros inseridos com sucesso!");

            }
            else
            {
                this.logger.LogError($"Erro ao acessar api {await response.Content.ReadAsStringAsync()}");
            }
                
        }
    }
}
