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

		public ActionResult AddOneAnimal(string AnimalType,string FeedType,string AnimalState)
		{
			AnimalDataAccess ada = new AnimalDataAccess();
			bool isaddsuccess = ada.AddAnimal(AnimalType, "HBRH7823SC", FeedType,AnimalState);
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

		public ActionResult UpdateAnimalById(string animal_id,string animal_state)
		{
			AnimalDataAccess ada = new AnimalDataAccess();
			bool isaltersuccess = ada.UpdateAnimalById(animal_id, animal_state);
			if (isaltersuccess)
				return Json("修改成功");
			else
				return Json("修改失败");
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

		public ActionResult GetFeedDetail(string animal_id)
		{
			FeedUseDataAccess fuda = new FeedUseDataAccess();
			var fus = fuda.GetTopTenFeedUseByAnimalId(animal_id);
			if(fus == null)
			{
				return Json("该牲畜无喂养记录");
			}
			else
			{
				List<Double> feedAmount = new List<double>();
				foreach (var item in fus)
				{
					feedAmount.Add(item.FeedAmount);
				}
				List<DateTime> feedDate = new List<DateTime>();
				foreach (var item in fus)
				{
					feedDate.Add(item.FeedDate);
				}
				var result = new
				{
					feedAmount = feedAmount,
					feedDate = feedDate
				};
				return Json(result);
			}
		}

		public ActionResult GetUnusualAnimal()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 10 : Convert.ToInt32(Request["rows"]);

			List<String> list = new List<string>();

			var animalList = new AnimalDataAccess().GetPaginationAnimals(pagesize, pageindex);
			foreach (var item in animalList)
			{
				var animals = new FeedUseDataAccess().GetTopTenFeedUseByAnimalId(item.AnimalID);
				if (animals != null)
				{
					var amounts = from animal in animals
								  orderby animal.FeedDate
								  select animal.FeedAmount;
					int[] abs = amounts.ToArray<int>();
					int x = DataAnalysis.FeedAnalysis.MaxReduce(abs, abs.Length);
					if (x > 10)
					{
						list.Add(item.AnimalID);
					}
				}
			}
			
			return Json(list);
		}
    }
}