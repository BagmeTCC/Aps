using ApsHgBrasilWeather.Models.Helpers;
using ApsHgBrasilWeather.Models.RestModels;
using ApsHgBrasilWeather.Models.RestModels.HgBrasil;
using ApsHgBrasilWeather.Models.Services;
using ApsHgBrasilWeather.Models.ViewModels;
using Newtonsoft.Json;
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
        public ActionResult Index()
        {
            PrevisaoTempoViewModel viewModel = new PrevisaoTempoViewModel();

            return View(viewModel);
        }

        public async Task<ActionResult> GetPrevisaoTempo(string estadoEscolhido, string municipioEscolhido)
        {
            PrevisaoTempoAtualService service = new PrevisaoTempoAtualService();
            string parametros = service.MontarParametros(estadoEscolhido, municipioEscolhido);

            var retorno = await ApiHelper.GetPrevisaoTempoAtual(parametros);

            if (retorno.Sucesso)
            {
                return Json(new { OK = retorno.Sucesso, PrevisaoTempoAtual = retorno.Resultado }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { OK = false, Mensagem = retorno.Mensagem}, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> GetMunicipios(string estadoEscolhido)
        {
            var retorno = await ApiHelper.GetMunicipios(estadoEscolhido);

            if (retorno.Sucesso)
            {
                return Json(new { OK = retorno.Sucesso, Municipios = retorno.Resultado.OrderBy(p => p.Nome).ToList() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { OK = false}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}