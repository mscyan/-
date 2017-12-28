using DataAccessLibrary;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.Controllers
{
	public class RegisterController : Controller
	{
		// GET: Register
		public ActionResult RegisterIndex()
		{
			return View();
		}
		public ActionResult CheckUserRegister(User userInfo)
		{
			try
			{
				UserDataAccess uda = new UserDataAccess();
				if (uda.IsUserExist(userInfo.Username))
				{
					return Content("该用户已存在，请重新注册");
				}
				else
				{
					uda.AddUser(userInfo.Username, userInfo.Password, userInfo.Tel, userInfo.CompanyID);
					return Content("OK");
				}
			}
			catch (Exception ex)
			{
				return Content("注册异常" + ex.Message);
			}
		}
	}
}