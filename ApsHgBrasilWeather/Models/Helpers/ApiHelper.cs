using ApsHgBrasilWeather.Models.RestModels;
using ApsHgBrasilWeather.Models.RestModels.HgBrasil;
using ApsHgBrasilWeather.Models.RestModels.IBGE;
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
            RestModelHgBrasil<PrevisaoTempoAtual> retorno = new RestModelHgBrasil<PrevisaoTempoAtual>();
            PrevisaoTempoAtualService service = new PrevisaoTempoAtualService();

            HttpResponseMessage response = await client.GetAsync(ConfigHelper.UrlWeather);
            
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                string stringJson = new StreamReader(responseStream).ReadToEnd();
                retorno = JsonConvert.DeserializeObject<RestModelHgBrasil<PrevisaoTempoAtual>>(stringJson);

                if (retorno != null && retorno.Resultado != null)
                {
                    service.FormatarDados(retorno.Resultado);
                }
            }
            
            return retorno.Resultado;
        }

        public static async Task GetMunicipios(string uf)
        {
            RestModelIBGE<Municipio> retorno = new RestModelIBGE<Municipio>();

            string urlFormatada = ConfigHelper.UrlIBGE.Replace("{UF}", uf);
            HttpResponseMessage response = await client.GetAsync(urlFormatada);

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                string stringJson = new StreamReader(responseStream).ReadToEnd();
                retorno.Resultado = JsonConvert.DeserializeObject<List<Municipio>>(stringJson);
            }
        }
    }
}