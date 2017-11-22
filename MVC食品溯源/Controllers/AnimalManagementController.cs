using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.Controllers
{
    public class AnimalManagementController : Controller
    {
        // GET: AnimalManagement
		// 此控制器主要用于牲畜养殖管理过程中的数据操作。
        public ActionResult Index()
        {
            return View();
        }
    }
}