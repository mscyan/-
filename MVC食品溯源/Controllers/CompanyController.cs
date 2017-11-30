using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using DataAccessLibrary;

namespace MVC食品溯源.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult CompanyIndex()
        {
            return View();
        }

		//公司注册
		public ActionResult AddCompany()
		{
			return View();
		}

		public ActionResult GetAllCompanyAction()
		{
			List<Company> list = new List<Company>();



			return Json(list);
		}

		//养殖场
		public ActionResult FarmPage()
		{
			return View();
		}

		public ActionResult ButchFactoryPage()
		{
			return View();
		}

		public ActionResult ManuFactoryPage()
		{
			return View();
		}

		public ActionResult MarketPage()
		{
			return View();
		}

		public ActionResult GetAllMarketAction()
		{
			MarketDataAccess mda = new MarketDataAccess();
			var ms = mda.GetAllMarket();
			return Json(ms);
		}

		public ActionResult GetAllManuFactoryAction()
		{
			ManuFactoryDataAccess mfda = new ManuFactoryDataAccess();
			var mfs = mfda.GetAllManuFactory();
			return Json(mfs);
		}

		public ActionResult GetAllButchFactoryAction()
		{
			ButchFactoryDataAccess bfda = new ButchFactoryDataAccess();
			var bfs = bfda.GetAllButchFactory();
			return Json(bfs);
		}

		public ActionResult GetAllFarmAction()
		{
			FarmDataAccess fda = new FarmDataAccess();
			var fs = fda.GetAllFarm();
			return Json(fs);
		}
    }
}