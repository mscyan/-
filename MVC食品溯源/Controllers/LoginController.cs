using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using Model;

namespace MVC食品溯源.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

		public string LoginResult(string _username,string _password)
		{
			string str = "hello";
			UserDataAccess uda = new UserDataAccess();
			User user = uda.GetUserByUsername(_username, _password);
			if (user!=null)
			{
				str = "登录成功";
			}
			else
				str = "登录失败";
			return str;
		}
    }
}