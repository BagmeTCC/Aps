using ApsHgBrasilWeather.Models;
using ApsHgBrasilWeather.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApsHgBrasilWeather.Controllers
{
    public class HomeController : Controller
    {
        private string url = "https://api.hgbrasil.com/weather";

        public ActionResult Index()
        {
            var a = ApiHelper.GetPrevisaoTempoAtual("");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}