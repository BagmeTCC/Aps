using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsHgBrasilWeather.Lib.Models.RestModels.IBGE
{
    public class RestModelIBGE<T>
    {
        public List<T> Resultado { get; set; }
        public bool Sucesso { get; set; }
    }
}
