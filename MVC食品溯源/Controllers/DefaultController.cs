using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult View02()
		{
			return View();
		}

		public ActionResult View03()
		{
			return View();
		}

		public ActionResult SayHello(string aa,string bb)
		{
			string s = "Hello";
			return Json(s + "Hello -- " + aa + " -- " + bb); 
		}
    }
}