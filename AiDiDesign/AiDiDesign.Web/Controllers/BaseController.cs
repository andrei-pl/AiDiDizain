namespace AiDiDesign.Web.Controllers
{
    using AiDiDesign.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        protected User CurrentUser { get; set; }

        [NonAction]
        public void SystemSettings()
        {

        }
    }
}