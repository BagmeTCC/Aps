using Newtonsoft.Json;

namespace ApsHgBrasilWeather.Models.RestModels.HgBrasil
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