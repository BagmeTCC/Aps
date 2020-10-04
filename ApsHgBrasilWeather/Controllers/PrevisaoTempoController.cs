using ApsHgBrasilWeather.Models.Helpers;
using ApsHgBrasilWeather.Models.RestModels;
using ApsHgBrasilWeather.Models.RestModels.HgBrasil;
using ApsHgBrasilWeather.Models.ViewModels;
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
            PrevisaoTempoViewModel viewModel = new PrevisaoTempoViewModel();
            //PrevisaoTempoAtual previsao = await ApiHelper.GetPrevisaoTempoAtual("");

             await ApiHelper.GetMunicipios("RJ");

            return View(viewModel);
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

        public async Task<ActionResult> GetMunicipios(string estadoEscolhido)
        {
            var retorno = await ApiHelper.GetMunicipios(estadoEscolhido);

            if (retorno.Successo)
            {
                return Json(new { OK = retorno.Successo, Municipios = retorno.Resultado.OrderBy(p => p.Nome).ToList() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { OK = false}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}