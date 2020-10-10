using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Lib.Models.RestModels.HgBrasil
{
    public class PrevisaoTempoSeguinte
    {
        [JsonProperty(PropertyName = "Date")]
        public string DataPrevisao { get; set; }

        [JsonProperty(PropertyName = "Weekday")]
        public string DiaSemana { get; set; }

        [JsonProperty(PropertyName = "Max")]
        public string MaximaTemperatura { get; set; }

        [JsonProperty(PropertyName = "Min")]
        public string MinimaTemperatura { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string DescricaoPrevisao { get; set; }

        [JsonProperty(PropertyName = "Condition")]
        public string CondicaoTempo { get; set; }

        public string NomeImagemCondicaoTempo { get; set; }
    }
}
