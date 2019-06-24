using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntraVisionTestTask.Controllers
{
    public class HomeController : Controller
    {
        private int count = 0;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert(int Count)
        {
            count += Count;
            return View("index");
        }

        public ActionResult Deliver(int Count)
        {

            return View("index");
        }
    }
}