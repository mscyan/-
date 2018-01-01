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
					User user = uda.GetUserByUsername(userInfo.Username, userInfo.Password);
					if (user != null)
					{
						Session["Username"] = userInfo.Username;
						string companyid = user.CompanyID;
						string address;
						switch (companyid)
						{
							case "养殖场":
								address = @"/Farm/FarmIndex";
								break;
							case "屠宰场":
								address = @"/ButchWork/ButchWorkIndex";
								break;
							case "加工厂":
								address = @"/ManuWork/ManuWorkIndex";
								break;
							case "零售点":
								address = @"/Sales/SaleIndex";
								break;
							default:
								address = "/BackSystem/Index";
								break;
						}
						return Content("{\"result\":\"OK\",\"address\":\"" + address + "\"}");
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