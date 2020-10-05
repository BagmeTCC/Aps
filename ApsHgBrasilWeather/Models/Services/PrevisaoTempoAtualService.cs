using ApsHgBrasilWeather.Models.Helpers;
using ApsHgBrasilWeather.Models.RestModels;
using ApsHgBrasilWeather.Models.RestModels.HgBrasil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ApsHgBrasilWeather.Models.Services
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
            previsaoTempoAtual.CondicaoTempoAtual = GetDescricaoCondicaoTempo(previsaoTempoAtual.CondicaoTempoAtual);
            previsaoTempoAtual.TemperaturaAtual += " °C";
            previsaoTempoAtual.UmidadePercentual += "%"; 
            previsaoTempoAtual.Uf = previsaoTempoAtual.CidadeUf.Split(',')[1].Trim();

            previsaoTempoAtual.ListaPrevisaoTempoOutrosDias?
                .ForEach(p => 
                {
                    p.CondicaoTempo = GetDescricaoCondicaoTempo(p.CondicaoTempo);
                    p.MinimaTemperatura += " °C";
                    p.MaximaTemperatura += " °C";
                });
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
    }
}