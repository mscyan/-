using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZTest.App_Start
{
	public class LoginAttribute:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if(true)
			{
				//base.OnActionExecuting(filterContext);
				filterContext.HttpContext.Response.Redirect("Login.cshtml");
			}
			else
			{
				filterContext.HttpContext.Response.Redirect("Login.cshtml");
			}
		}
	}
}