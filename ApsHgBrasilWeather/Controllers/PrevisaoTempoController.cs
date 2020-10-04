using ApsHgBrasilWeather.Models.Helpers;
using ApsHgBrasilWeather.Models.RestModels;
using ApsHgBrasilWeather.Models.RestModels.HgBrasil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApsHgBrasilWeather.Controllers
{
    public class PrevisaoTempoController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //PrevisaoTempoAtual previsao = await ApiHelper.GetPrevisaoTempoAtual("");

             await ApiHelper.GetMunicipios("RJ");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string cidade)
        {
            return View();
        }

        public ActionResult GetPrevisaoTempo()
        {

            return null;
        }
    }
}