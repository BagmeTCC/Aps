using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApsHgBrasilWeather.Models
{
    public class PrevisaoTempoSeguinte
    {
        [JsonProperty(PropertyName = "Date")]
        public string DataPrevisao { get; set; }

        [JsonProperty(PropertyName = "Weekday")]
        public string DiaSemana { get; set; }

        [JsonProperty(PropertyName = "Max")]
        public int MaximaTemperatura { get; set; }

        [JsonProperty(PropertyName = "Min")]
        public int MinimaTemperatura { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string DescricaoPrevisao { get; set; }

        [JsonProperty(PropertyName = "Condition")]
        public string CondicaoTempo { get; set; }
    }

    public class PrevisaoTempoAtual
    {
        [JsonProperty(PropertyName = "Temp")]
        public int TemperaturaAtual { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public string DataConsulta { get; set; }

        [JsonProperty(PropertyName = "Time")]
        public string HoraConsulta { get; set; }

        [JsonProperty(PropertyName = "Condition_code")]
        public string CodigoCondicaoTempo { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "Currently")]
        public string DiaNoite { get; set; }

        [JsonProperty(PropertyName = "Cid")]
        public string CidadeID { get; set; }

        [JsonProperty(PropertyName = "City")]
        public string Cidade { get; set; }

        [JsonProperty(PropertyName = "Img_id")]
        public string ImgID { get; set; }

        [JsonProperty(PropertyName = "Humidity")]
        public int UmidadePercentual { get; set; }

        [JsonProperty(PropertyName = "Wind_speedy")]
        public string VelocidadeVento { get; set; }

        [JsonProperty(PropertyName = "Sunrise")]
        public string HorarioNascerSol { get; set; }

        [JsonProperty(PropertyName = "Sunset")]
        public string HorarioPorSol { get; set; }

        [JsonProperty(PropertyName = "Condition_slug")]
        public string CondicaoTempoAtual { get; set; }

        [JsonProperty(PropertyName = "City_name")]
        public string NomeCidade { get; set; }

        [JsonProperty(PropertyName = "Forecast")]
        public List<PrevisaoTempoSeguinte> ListaPrevisaoTempoOutrosDias { get; set; }
    }

    public class RetornoRestModel<T>
    {
        public T Results { get; set; }
    }
}