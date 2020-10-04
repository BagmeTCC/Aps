using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApsHgBrasilWeather.Models.RestModels.IBGE
{
    public class Municipio
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}