using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Lib.Models.RestModels.HgBrasil
{
    public class RestModelHgBrasil<T>
    {
        [JsonProperty(PropertyName = "Results")]
        public T Resultado { get; set; }

        [JsonProperty(PropertyName = "Error")]
        public bool Sucesso { get; set; }

        [JsonProperty(PropertyName = "Message")]
        public string Mensagem { get; set; }
    }
}
