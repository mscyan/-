using DataAccessLibrary;
using Newtonsoft.Json;
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
				int teststring = dt.Rows.Count;
				if (dt.Rows.Count != 0)
				{
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						switch (dt.Rows[i][0].ToString().Trim())
						{
							case "add":
								sb.Append("{\"text\": \"添加\",\"iconCls\":\"icon-add\",\"handler\":\"add" + pageName + "();\"},");
								break;
							case "delete":
								sb.Append("{\"text\": \"删除\",\"iconCls\":\"icon-remove\",\"handler\":\"delete" + pageName + "();\"},");
								break;
							case "edit":
								sb.Append("{\"text\": \"更改\",\"iconCls\":\"icon-edit\",\"handler\":\"edit" + pageName + "();\"},");
								break;
							default:
								break;
						}
					}
					sb.Remove(sb.Length - 1, 1);
				}
				sb.Append("],\"success\":true}");
				return Content(sb.ToString());
			}
			catch
			{
				return Content("{\"msg\":\"无权浏览，请登录\",\"success\":false}");
			}
			//return Content("{\"msg\":\"授权成功\",\"success\":true}");
		}

		public ActionResult GetPaginationRoles()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			RoleDataAccess rda = new RoleDataAccess();
			var allRoles = rda.GetPaginationRole(pagesize,pageindex);
			return Content("{\"total\": " + rda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(allRoles) + "}");
		}

		public ActionResult GetAllRoles()
		{
			RoleDataAccess rda = new RoleDataAccess();
			var allRoles = rda.GetAllRole();
			return Json(allRoles);
		}

		public ActionResult AddRoleAction(string rolename, string roledesc, string giver)
		{
			RoleDataAccess rda = new RoleDataAccess();
			if (rda.AddRole(rolename,roledesc,giver))
			{
				return Json("添加成功");
			}
			else
			{
				return Json("添加失败");
			}
		}

		public ActionResult EditRoleAction(int roleid, string rolename, string roledesc)
		{
			RoleDataAccess rda = new RoleDataAccess();
			if (rda.UpdateRole(roleid,rolename,roledesc))
			{
				return Json("更新成功");
			}
			else
			{
				return Json("更新失败");
			}
		}

		public ActionResult DeleteRoleById(string id)
		{
			RoleDataAccess rda = new RoleDataAccess();
			if (rda.DeleteRoleById(id))
			{
				return Json("删除成功");
			}
			else
			{
				return Json("删除失败");
			}
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