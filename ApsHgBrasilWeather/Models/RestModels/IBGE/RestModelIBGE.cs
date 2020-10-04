using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApsHgBrasilWeather.Models.RestModels.IBGE
{
    public class RestModelIBGE<T>
    {
        public List<T> Resultado { get; set; }
        public bool Successo { get; set; }
    }
}