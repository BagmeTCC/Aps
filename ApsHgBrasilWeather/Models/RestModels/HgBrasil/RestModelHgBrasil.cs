using Newtonsoft.Json;

namespace ApsHgBrasilWeather.Models.RestModels.HgBrasil
{
    public class RestModelHgBrasil<T>
    {
        [JsonProperty(PropertyName = "Results")]
        public T Resultado { get; set; }

        public bool Successo { get; set; }
    }
}