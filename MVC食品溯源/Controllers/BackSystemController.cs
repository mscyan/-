using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.Controllers
{
    public class BackSystemController : Controller
    {
        // GET: BackSystem
        public ActionResult Index()
        {
            return View();
        }

		//角色管理页面
		public ActionResult Roles()
		{
			return View();
		}

		//用户管理页面
		public ActionResult Users()
		{
			return View();
		}

		//申请回复页面
		public ActionResult Replys()
		{
			return View();
		}

		//厂商信息页面
		public ActionResult Companys()
		{
			return View();
		}

		//菜单显示页面
		public ActionResult Menus()
		{
			return View();
		}
    }
}