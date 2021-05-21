using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSeplag.Aplication.Updates.Dtos
{
    public class ValuesDto
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("Alias")]
        public string Alias { get; set; }

        [JsonProperty("DocumentTitle")]
        public string DocumentTitle { get; set; }

        [JsonProperty("Severity")]
        public string Severity { get; set; }

        [JsonProperty("InitialReleaseDate")]
        public DateTime InitialReleaseDate { get; set; }

        [JsonProperty("CurrentReleaseDate")]
        public DateTime CurrentReleaseDate { get; set; }

        [JsonProperty("CvrfUrl")]
        public Uri CvrfUrl { get; set; }
    }
}
