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
			if (saleinfo == null)
			{
				return Json("没有查到此条记录");
			}
			else
			{
				string animalID = saleinfo.AnimalID;

				var animal = new AnimalDataAccess().getAnimalByUniqueCode(animalID);

				animal.FarmID = new FarmDataAccess().GetFarmById(animal.FarmID).FarmName;

				var manuworkinfo = new ManuWorkDataAccess().GetManuWorkInfoByAnimalId(animalID);
				var butchworkinfo = new ButchWorkDataAccess().GetButchWorkInfoByAnimalId(animalID);
				var healthcheck = new CheckDataAccess().GetCheckByAnimalId(animalID);

				ButchFactoryDataAccess bfda = new ButchFactoryDataAccess();//.GetButchFactoryById(butchworkinfo.ButchFactoryID);
				butchworkinfo.ButchInfo = bfda.GetButchFactoryById(butchworkinfo.ButchFactoryID).ButchFactoryName + " "+ bfda.GetButchFactoryById(butchworkinfo.ButchFactoryID).ButchPosition;

				ManuFactoryDataAccess mfda = new ManuFactoryDataAccess();
				manuworkinfo.ManuInfo = mfda.GetManuFactoryById(manuworkinfo.ManuFactoryID).ManuName+" "+mfda.GetManuFactoryById(manuworkinfo.ManuFactoryID).ManuPosition;

				var JsonData = new
				{
					animal = animal,
					manuworkinfo = (manuworkinfo == null) ? null : manuworkinfo,
					butchworkinfo = (butchworkinfo == null) ? null : butchworkinfo,
					healthcheck = (healthcheck == null) ? null : healthcheck,
					saleinfo = saleinfo
				};
				
				return Json(JsonData);
			}
		}

		public ActionResult modal()
		{
			return View();
		}

		public ActionResult SearchResultPage()
		{
			return View();
		}
    }
}