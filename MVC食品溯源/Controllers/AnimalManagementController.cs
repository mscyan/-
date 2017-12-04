using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;

namespace MVC食品溯源.Controllers
{
	public class AnimalManagementController : Controller
	{
		// GET: AnimalManagement
		// 此控制器主要用于牲畜养殖管理过程中的数据操作。
		public ActionResult AnimalIndex()
		{


			return View();
		}

		public ActionResult AddAnimal()
		{
			return View();
		}

		public ActionResult AlterAnimal()
		{
			return View();
		}

		public ActionResult AddOneAnimal(string AnimalType,string FeedType)
		{
			AnimalDataAccess ada = new AnimalDataAccess();
			bool isaddsuccess = ada.AddAnimal(AnimalType, "HBRH7823SC", FeedType);
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		public ActionResult GetAllAnimals()
		{
			AnimalDataAccess ada = new AnimalDataAccess();
			var animals = ada.getAllAnimals();

			return Json(animals);
		}

		public ActionResult GetPaginationAnimals()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 10 : Convert.ToInt32(Request["rows"]);
			
			AnimalDataAccess ada = new AnimalDataAccess();
			var animals = ada.GetPaginationAnimals(pagesize, pageindex);
			return Content("{\"total\": " + ada.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(animals) + "}");

		}

		public ActionResult DeleteAnimalById(string ids)
		{
			AnimalDataAccess ada = new AnimalDataAccess();
			bool isdeletesuccess = ada.deleteSingleAnimalByUniqueCode(ids);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除失败");
		}
    }
}