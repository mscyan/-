using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZTest.Controllers
{
	[ZTest.App_Start.Login]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Login()
		{
			return View();
		}
    }
}