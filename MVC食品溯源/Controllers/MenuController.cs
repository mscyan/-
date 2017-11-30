using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult MenuIndex()
        {
            return View();
        }
    }
}