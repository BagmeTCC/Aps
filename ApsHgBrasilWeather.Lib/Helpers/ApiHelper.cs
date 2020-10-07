using ApsHgBrasilWeather.Lib.Models.RestModels.HgBrasil;
using ApsHgBrasilWeather.Lib.Models.RestModels.IBGE;
using ApsHgBrasilWeather.Lib.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Lib.Helpers
{
    public class ApiHelper
    {
        private static HttpClient client = new HttpClient();

        public static async Task<RestModelHgBrasil<PrevisaoTempoAtual>> GetPrevisaoTempoAtual(string parametros)
        {
            RestModelHgBrasil<PrevisaoTempoAtual> retorno = new RestModelHgBrasil<PrevisaoTempoAtual>();
            PrevisaoTempoAtualService service = new PrevisaoTempoAtualService();

            string url = ConfigHelper.UrlWeather + parametros;

            HttpResponseMessage response = await client.GetAsync(url);

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                string stringJson = new StreamReader(responseStream).ReadToEnd();
                retorno = JsonConvert.DeserializeObject<RestModelHgBrasil<PrevisaoTempoAtual>>(stringJson);

                if (response.IsSuccessStatusCode && retorno != null && retorno.Resultado != null)
                {
                    service.FormatarDados(retorno.Resultado);
                }

                retorno.Sucesso = response.IsSuccessStatusCode;
            }

            return retorno;
        }

        public static async Task<RestModelIBGE<Municipio>> GetMunicipios(string uf)
        {
            RestModelIBGE<Municipio> retorno = new RestModelIBGE<Municipio>();

            string urlFormatada = ConfigHelper.UrlIBGE.Replace("{UF}", uf);
            HttpResponseMessage response = await client.GetAsync(urlFormatada);

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                string stringJson = new StreamReader(responseStream).ReadToEnd();
                retorno.Resultado = JsonConvert.DeserializeObject<List<Municipio>>(stringJson);

                if (retorno.Resultado != null && response.StatusCode == HttpStatusCode.OK)
                {
                    retorno.Sucesso = true;
                }
                return retorno;
            }
        }
    }
}
