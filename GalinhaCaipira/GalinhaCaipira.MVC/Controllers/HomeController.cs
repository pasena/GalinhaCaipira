using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalinhaCaipira.MVC.Controllers
{
    public class HomeController : GalinhaControllerBase
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}