using Newtonsoft.Json;

namespace ApsHgBrasilWeather.Models.RestModels
{
    public class RestModel<T>
    {
        [JsonProperty(PropertyName = "Results")]
        public T Resultado { get; set; }
    }
}