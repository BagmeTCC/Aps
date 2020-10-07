using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Lib.Helpers
{
    public class ConfigHelper
    {
        public static string UrlWeather
        {
            get { return ConfigurationManager.AppSettings["urlWeather"]; }
        }

        public static string UrlIBGE
        {
            get { return ConfigurationManager.AppSettings["urlIBGE"]; }
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
