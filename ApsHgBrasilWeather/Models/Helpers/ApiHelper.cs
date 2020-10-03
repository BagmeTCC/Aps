using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ApsHgBrasilWeather.Models.Helpers
{
    public class ApiHelper
    {
        private static HttpClient client = new HttpClient();

        public static async Task<HttpResponseMessage> GetPrevisaoTempoAtual(string parametros)
        {
            HttpResponseMessage response = await client.GetAsync(ConfigHelper.UrlWeather);
            RetornoRestModel<PrevisaoTempoAtual> retorno = new RetornoRestModel<PrevisaoTempoAtual>();

            using (var a = await response.Content.ReadAsStreamAsync())
            {
                string batata = new StreamReader(a).ReadToEnd();

                retorno = JsonConvert.DeserializeObject<RetornoRestModel<PrevisaoTempoAtual>>(batata);
            }
            
  
            return response;
        }
    }
}