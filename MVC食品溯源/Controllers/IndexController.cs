using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;

namespace MVC食品溯源.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
			
		public ActionResult About()
		{
			
			return View();
		}

		public ActionResult LoginResult()
		{
			
			return View();
		}

		public ActionResult TransPage()
		{	
			return View();
		}

		public ActionResult SearchByCode(string sales_Code)
		{
			SaleInfoDataAccess sda = new SaleInfoDataAccess();
			var saleinfo = sda.GetSaleInfoById(sales_Code);


			//return Json("没有查到此条记录");
			return Json("aba");
		}
    }
}