using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.Controllers
{
    public class RoleController : Controller
    {
        // GET: Roles
        public ActionResult RoleIndex()
        {
            return View();
        }

		public ActionResult AddRole()
		{

			return View();
		}

		public ActionResult EditRole()
		{
			return View();
		}

		public ActionResult GetAllRoles()
		{

			return Json("hello");
		}

		public ActionResult AddRoleAction(string rolename,string roledesc,string giver)
		{

			return Json("添加成功");
		}

		public ActionResult DeleteRoleById(string id)
		{

			return Json("删除成功");
		}
    }
}