using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;

namespace MVC食品溯源.Controllers
{
	public class UserController : Controller
	{
		// GET: User
		public ActionResult UserIndex()
		{
			return View();
		}

		public ActionResult AddUser(string user_name, string pass_word, string tel_, string company_id)
		{
			//UserDataAccess uda = new UserDataAccess();
			//uda.AddUser(user_name, pass_word, tel_, company_id);
			//用户注册时调用
			return View();
		}

		public ActionResult EditUser()
		{
			return View();
		}

		//public ActionResult GetAllUserAction()
		//{
		//	UserDataAccess uda = new UserDataAccess();
		//	var us = uda.GetAllUserList();
		//	return Json(us);
		//}

		public ActionResult GetPaginationUserAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			UserDataAccess uda = new UserDataAccess();
			var allRoles = uda.GetPaginationRole(pagesize, pageindex);
			return Content("{\"total\": " + uda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(allRoles) + "}");
		}

		public ActionResult AddUserAction(string username,string userpassword,string usertel,string usercompany)
		{
			UserDataAccess uda = new UserDataAccess();
			if (uda.AddUser(username, userpassword, usertel, usercompany))
			{
				return Json("添加成功");
			}
			else
			{
				return Json("添加失败");
			}
		}

		public ActionResult DeleteUserByUsername(string username)
		{
			UserDataAccess uda = new UserDataAccess();
			if (uda.DeleteUser(username))
			{
				return Json("删除成功");
			}
			else
			{
				return Json("删除失败");
			}
		}

		public ActionResult EditUserAction(string username, string userpassword, string usertel)
		{
			UserDataAccess uda = new UserDataAccess();
			if (uda.UpdateUser(username, userpassword, usertel))
			{
				return Json("编辑成功");
			}
			else
			{
				return Json("编辑失败");
			}
		}

		public ActionResult TreeRole()
		{
			return View();
		}

		public ActionResult GetAllRoles()
		{
			var gar = new RoleDataAccess().GetAllRole();
			return Json(gar);
		}

		public ActionResult GetUserCurrentRole(string Username)
		{
			List<string> list = new RoleDataAccess().GetRoleByUsername(Username);
			return Json(list);
		}

		public ActionResult AddUserRole()
		{
			try
			{
				string Username = Request["Username"];
				string RoleIds = Request["RoleIds"];
				bool res = new UserDataAccess().UserRoleAuthorize(Username, RoleIds);
				if (res)
				{
					return Content("{\"msg\":\"操作成功\",\"success\":true}");
				}
				else
				{
					return Content("{\"msg\":\"操作失败\",\"success\":false}");
				}
			}
			catch (Exception ex)
			{
				return Content("{\"msg\":\"操作失败," + ex.Message + "\",\"success\":false}");
			}
		}
	}
}