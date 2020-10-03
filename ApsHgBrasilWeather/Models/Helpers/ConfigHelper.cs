﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ApsHgBrasilWeather.Models.Helpers
{
    public class ConfigHelper
    {
        public static string UrlWeather
        {
            get { return ConfigurationManager.AppSettings["urlWeather"]; }
        }

        public static string Chave1
        {
            get { return ConfigurationManager.AppSettings["chave1"]; }
        }

        public static string Chave2
        {
            get { return ConfigurationManager.AppSettings["chave2"]; }
        }
    }
}