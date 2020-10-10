using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Lib.Util
{
    public class RazorUtil
    {
        public static string GetTemplate<T>(T model)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "bin\\Template\\";
                string file = "PainelPrevisaoTempo.cshtml";

                string template = File.ReadAllText(path + file);

                string stringHtml = Engine.Razor.RunCompile(new LoadedTemplateSource(template),
                   "", typeof(T), model);

                return stringHtml;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            
        }
    }
}
