﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC食品溯源.App_Start
{
	public class LoginAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			//if (String.IsNullOrEmpty(filterContext.HttpContext.Session["Username"].ToString()))
			//{
			//	base.OnActionExecuting(filterContext);
			//	///filterContext.HttpContext.Response.Redirect("/Login/LoginIndex");
			//}
			//else
			//{
			//	//filterContext.HttpContext.Response.Redirect("/Login/Login");
			//}
		}
	}
}