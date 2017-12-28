using DataAccessLibrary;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.Controllers
{
	public class LoginController : Controller
	{
		// GET: Login
		public ActionResult LoginIndex()
		{
			return View();
		}
		public ActionResult CheckUserLogin(User userInfo)
		{
			try
			{
				UserDataAccess uda = new UserDataAccess();
				if (uda.IsUserExist(userInfo.Username))
				{
					if (uda.GetUserByUsername(userInfo.Username, userInfo.Password) != null)
					{
						Session["Username"] = userInfo.Username;
						return Content("OK");
					}
					else
					{
						return Content("密码错误");
					}
				}
				else
				{
					return Content("用户名错误");
				}
			}
			catch (Exception ex)
			{
				return Content("登录异常" + ex.Message);
			}
		}

		public ActionResult LoginOut()
		{
			Session["Username"] = "";
			return Content("{ \"msg\":\"退出成功\",\"success\":true }");
		}

	}
}