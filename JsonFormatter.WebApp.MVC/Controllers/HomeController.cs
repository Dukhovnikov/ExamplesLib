using CommonData.ClassLib.Utils;
using JsonFormatter.WebApp.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonFormatter.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        [HttpPost]
        public ActionResult TestPage(string data)
        {
            var model = new PageTextData()
            {
                PrimaryData = data,
                SecondaryData = data.ToJson()
            };

            return PartialView(model);
        }
    }
}