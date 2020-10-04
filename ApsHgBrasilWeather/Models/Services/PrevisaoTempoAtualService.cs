﻿using ApsHgBrasilWeather.Models.RestModels;
using System;
using System.Globalization;

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

            previsaoTempoAtual.ListaPrevisaoTempoOutrosDias?
                .ForEach(p => 
                {
                    p.CondicaoTempo = GetDescricaoCondicaoTempo(p.CondicaoTempo);
                    p.MinimaTemperatura += " °C";
                    p.MaximaTemperatura += " °C";
                });
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
                    desc = "erro ao obter mas está de noite";
                    break;
            }

            return desc;
        }
    }
}