

namespace ProjetoSeplag.Aplication.Updates.Dtos
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class UpdatesDto
    {
        [JsonProperty("@odata.context")]
        public Uri OdataContext { get; set; }

        [JsonProperty("value")]
        public List<ValuesDto> Value { get; set; }
    }

}
