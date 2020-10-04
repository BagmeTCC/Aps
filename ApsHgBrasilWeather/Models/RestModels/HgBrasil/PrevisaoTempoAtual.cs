using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApsHgBrasilWeather.Models.RestModels.HgBrasil
{
    public class PrevisaoTempoAtual
    {
        [JsonProperty(PropertyName = "Temp")]
        public string TemperaturaAtual { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public string DataConsulta { get; set; }

        [JsonProperty(PropertyName = "Time")]
        public string HoraConsulta { get; set; }

        [JsonProperty(PropertyName = "Currently")]
        public string DiaNoite { get; set; }

        [JsonProperty(PropertyName = "City")]
        public string CidadeUf { get; set; }

        [JsonProperty(PropertyName = "Humidity")]
        public string UmidadePercentual { get; set; }

        [JsonProperty(PropertyName = "Wind_speedy")]
        public string VelocidadeVento { get; set; }

        [JsonProperty(PropertyName = "Sunrise")]
        public string HorarioNascerSol { get; set; }

        [JsonProperty(PropertyName = "Sunset")]
        public string HorarioPorSol { get; set; }

        [JsonProperty(PropertyName = "Condition_slug")]
        public string CondicaoTempoAtual { get; set; }

        [JsonProperty(PropertyName = "City_name")]
        public string Cidade { get; set; }

        public string Uf
        {
            get
            {
                return CidadeUf.Split(',')[1].Trim();
            }
        }

        [JsonProperty(PropertyName = "Forecast")]
        public List<PrevisaoTempoSeguinte> ListaPrevisaoTempoOutrosDias { get; set; }
    }
}