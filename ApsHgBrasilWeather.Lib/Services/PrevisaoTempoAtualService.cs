using ApsHgBrasilWeather.Lib.Helpers;
using ApsHgBrasilWeather.Lib.Models.RestModels.HgBrasil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Lib.Services
{
    public class PrevisaoTempoAtualService
    {
        public void FormatarDados(PrevisaoTempoAtual previsaoTempoAtual)
        {
            CultureInfo culture = new CultureInfo("pt-BR");

            previsaoTempoAtual.HorarioNascerSol =
                Convert.ToDateTime(previsaoTempoAtual.HorarioNascerSol, culture).ToString("HH:mm");
            previsaoTempoAtual.HorarioPorSol =
                Convert.ToDateTime(previsaoTempoAtual.HorarioPorSol, culture).ToString("HH:mm"); ;
            previsaoTempoAtual.TemperaturaAtual += " °C";
            previsaoTempoAtual.UmidadePercentual += "%";
            previsaoTempoAtual.Uf = previsaoTempoAtual.CidadeUf.Split(',')[1].Trim();
            previsaoTempoAtual.NomeImagemCondicaoTempo = GetNomeImagemPorCondicaoTempo(previsaoTempoAtual.CondicaoTempoAtual);

            previsaoTempoAtual.ListaPrevisaoTempoOutrosDias?
                .ForEach(p =>
                {
                    p.MinimaTemperatura += " °C";
                    p.MaximaTemperatura += " °C";
                    p.NomeImagemCondicaoTempo = GetNomeImagemPorCondicaoTempo(p.CondicaoTempo);
                    p.CondicaoTempo = GetDescricaoCondicaoTempo(p.CondicaoTempo);
                });

            previsaoTempoAtual.CondicaoTempoAtual = GetDescricaoCondicaoTempo(previsaoTempoAtual.CondicaoTempoAtual);

            previsaoTempoAtual.ListaPrevisaoTempoOutrosDias =
                previsaoTempoAtual.ListaPrevisaoTempoOutrosDias?.Count >= 7 ?
            previsaoTempoAtual.ListaPrevisaoTempoOutrosDias?.Take(7).ToList() : previsaoTempoAtual.ListaPrevisaoTempoOutrosDias;

            string dataConsultaFormatada = Convert.ToDateTime(previsaoTempoAtual.DataConsulta).ToString("dd/MM");
            previsaoTempoAtual.ListaPrevisaoTempoOutrosDias = previsaoTempoAtual.ListaPrevisaoTempoOutrosDias
                .Where(p => p.DataPrevisao != dataConsultaFormatada).ToList();
        }

        public string MontarParametros(string estadoEscolhido, string municipioEscolhido)
        {
            StringBuilder parametros = new StringBuilder();
            List<string> vet = municipioEscolhido.Split(' ').ToList();
            string valor = ConfigHelper.Chave2;

            parametros.Append($"?key={valor}&city_name=");

            if (vet.Count > 1)
            {
                vet.ForEach(s =>
                {
                    parametros.Append(s);
                    parametros.Append("_");
                });

                parametros.Remove(parametros.Length - 1, 1);
                parametros.Append(",");
                parametros.Append(estadoEscolhido);
            }
            else
            {
                parametros.Append(municipioEscolhido);
                parametros.Append(",");
                parametros.Append(estadoEscolhido);
            }

            return parametros.ToString();

        }

        private string GetDescricaoCondicaoTempo(string condicaoTempoAtual)
        {
            string desc = "";

            switch (condicaoTempoAtual)
            {
                case "storm":
                    desc = "Tempestade";
                    break;

                case "snow":
                    desc = "Neve";
                    break;

                case "hail":
                    desc = "Granizo";
                    break;

                case "rain":
                    desc = "Chuva";
                    break;

                case "fog":
                    desc = "Neblina";
                    break;

                case "clear_day":
                    desc = "Dia Limpo";
                    break;

                case "clear_night":
                    desc = "Noite Limpa";
                    break;

                case "cloud":
                    desc = "Nublado";
                    break;

                case "cloudly_day":
                    desc = "Dia Nublado";
                    break;

                case "cloudly_night":
                    desc = "Noite Nublada";
                    break;

                case "none_day":
                    desc = "Erro ao obter, mas está de dia";
                    break;

                case "none_night":
                    desc = "Erro ao obter mas está de noite";
                    break;
            }

            return desc;
        }

        private string GetNomeImagemPorCondicaoTempo(string condicaoTempoAtual)
        {
            string desc = "";

            switch (condicaoTempoAtual)
            {
                case "storm":
                    desc = "storm.png";
                    break;

                case "snow":
                    desc = "snow.png";
                    break;

                case "hail":
                    desc = "hail.png";
                    break;

                case "rain":
                    desc = "raining.png";
                    break;

                case "fog":
                    desc = "fog.png";
                    break;

                case "clear_day":
                    desc = "clear-day.png";
                    break;

                case "clear_night":
                    desc = "clear-night.png";
                    break;

                case "cloud":
                    desc = "cloud.png";
                    break;

                case "cloudly_day":
                    desc = "cloudly-day.png";
                    break;

                case "cloudly_night":
                    desc = "cloudly-night.png";
                    break;
            }

            return desc;
        }
    }
}
