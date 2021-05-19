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
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<IntegrationUpdates> logger;

        public IntegrationUpdates(IUpdateServices updateServices, IHttpClientFactory httpClientFactory, ILogger<IntegrationUpdates> logger)
        {
            this.updateServices = updateServices;
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task Integrar()
        {
            this.logger.LogInformation("Entrei");

            var request = new HttpRequestMessage(HttpMethod.Get,"https://api.msrc.microsoft.com/cvrf/v2.0/updates");
                request.Headers.Add("Accept", "application/json");
            var client = httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                updateServices.Insert(await JsonSerializer.DeserializeAsync<UpdatesDto>(responseStream));
            }
            else
            {
                this.logger.LogError($"Erro ao acessar api {await response.Content.ReadAsStringAsync()}");
            }

            
        }
    }
}
