using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

		public ActionResult GetUserPowerButton()
		{
			try
			{
				string Username = Session["Username"].ToString();
				string pageName = Request["KeyName"];
				DataTable dt = new RoleDataAccess().GetUserPowerButtonByUsername(Username);

				StringBuilder sb = new StringBuilder();
				sb.Append("{\"toolbar\":[");
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					switch (dt.Rows[i][0].ToString().Trim())
					{
						case "add":
							sb.Append("{\"text\": \"添加\",\"iconCls\":\"icon-add\",\"handler\":\"Add" + pageName + "();\"},");
							break;
						case "delete":
							sb.Append("{\"text\": \"删除\",\"iconCls\":\"icon-remove\",\"handler\":\"delete" + pageName + "();\"},");
							break;
						case "update":
							sb.Append("{\"text\": \"更改\",\"iconCls\":\"icon-edit\",\"handler\":\"update" + pageName + "();\"},");
							break;
						default:
							break;
					}
				}
				sb.Remove(sb.Length - 1, 1);
				sb.Append("],\"success\":true}");
				return Content(sb.ToString());
			}
			catch
			{
				return Content("{\"msg\":\"无权浏览，请登录\",\"success\":false}");
			}
			//return Content("{\"msg\":\"授权成功\",\"success\":true}");
		}

		public ActionResult GetAllRoles()
		{
			RoleDataAccess rda = new RoleDataAccess();
			var allRoles = rda.GetAllRole();
			return Json(allRoles);
		}

		public ActionResult AddRoleAction(string rolename, string roledesc, string giver)
		{

			return Json("添加成功");
		}

		public ActionResult DeleteRoleById(string id)
		{

			return Json("删除成功");
		}

		public ActionResult TreePower()
		{
			return View();
		}
		public ActionResult SetRolePower()
		{
			try
			{
				string powerIds = Request["powerIds"];
				int roleId = Convert.ToInt32(Request["roleId"]);

				bool res = new RoleDataAccess().RolePowerAuthorize(roleId, powerIds);
				if (res)
				{
					return Content("{\"msg\":\"授权成功\",\"success\":true}");
				}
				else
				{
					return Content("{\"msg\":\"授权失败\",\"success\":false}");
				}
			}
			catch (Exception ex)
			{
				return Content("{\"msg\":\"授权失败," + ex.Message + "\",\"success\":false}");
			}
		}
	}
}