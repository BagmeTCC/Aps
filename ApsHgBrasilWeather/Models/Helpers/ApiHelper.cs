using ApsHgBrasilWeather.Models.RestModels;
using ApsHgBrasilWeather.Models.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Models.Helpers
{
    public class ApiHelper
    {
        private static HttpClient client = new HttpClient();

        public static async Task<PrevisaoTempoAtual> GetPrevisaoTempoAtual(string parametros)
        {
            RestModel<PrevisaoTempoAtual> retorno = new RestModel<PrevisaoTempoAtual>();
            PrevisaoTempoAtualService service = new PrevisaoTempoAtualService();

            HttpResponseMessage response = await client.GetAsync(ConfigHelper.UrlWeather);
            
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                string stringJson = new StreamReader(responseStream).ReadToEnd();
                retorno = JsonConvert.DeserializeObject<RestModel<PrevisaoTempoAtual>>(stringJson);

                if (retorno != null && retorno.Resultado != null)
                {
                    service.FormatarDados(retorno.Resultado);
                }
            }
            
            return retorno.Resultado;
        }
    }
}