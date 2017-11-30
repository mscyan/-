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

		public ActionResult AddUser(string user_name,string pass_word,string tel_,string company_id)
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

		public ActionResult GetAllUserAction()
		{
			UserDataAccess uda = new UserDataAccess();
			var us = uda.GetAllUserList();
			return Json(us);
		}

		public ActionResult AddUserAction()
		{

			return Json("添加成功");
		}

		public ActionResult DeleteUserById(string id)
		{
			return Json("删除成功");
		}
    }
}