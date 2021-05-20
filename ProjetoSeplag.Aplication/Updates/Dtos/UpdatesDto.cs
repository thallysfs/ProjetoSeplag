

namespace ProjetoSeplag.Aplication.Updates.Dtos
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class UpdatesDto
    {
        [JsonProperty("value")]
        public List<ValuesDto> value { get; set; }
    }

}
