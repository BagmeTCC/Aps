using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Lib.Models.RestModels.IBGE
{
    public class Municipio
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
