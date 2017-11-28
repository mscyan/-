using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.Controllers
{
    public class ButchWorkController : Controller
    {
		// GET: ButchWork
		// 屠宰场管理平台的各项操作
		public ActionResult Index()
        {
            return View();
        }
    }
}