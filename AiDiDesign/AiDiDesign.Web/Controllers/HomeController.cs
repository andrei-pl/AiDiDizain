using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AiDiDesign.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            object text = "Our company is the best and always will be.";

            return View(text);
        }

        public ActionResult Contact()
        {
             object text = "Your contact page.";

            return View(text);
        }
    }
}