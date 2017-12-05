using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using Newtonsoft.Json;

namespace MVC食品溯源.Controllers
{
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult MedicineTypePage()
		{
			return View();
		}

		public ActionResult AddMedicineTypePage()
		{
			return View();
		}

		public ActionResult MedicinePage()
		{
			return View();
		}

		public ActionResult AddMedicinePage()
		{
			return View();
		}

		public ActionResult MedicineUsePage()
		{
			return View();
		}

		public ActionResult AddMedicineUsePage()
		{
			return View();
		}

		public ActionResult AddMedicineTypeAction(string medicinetype_name)
		{
			MedicineTypeDataAccess mtda = new MedicineTypeDataAccess();
			bool isaddsuccess = mtda.AddMedicine(medicinetype_name);
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		public ActionResult GetPaginationMedicineTypeAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			MedicineTypeDataAccess mtda = new MedicineTypeDataAccess();
			var mts = mtda.GetPaginationMedicineType(pagesize, pageindex);
			return Content("{\"total\": " + mtda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(mts) + "}");
		}

		public ActionResult DeleteMedicineTypeByIdAction(string medicinetype_id)
		{
			MedicineTypeDataAccess mtda = new MedicineTypeDataAccess();
			bool isdeletesuccess = mtda.DeleteMedicineTypeById(medicinetype_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除失败");
		}

		public ActionResult AddMedicineAction(string medicine_name,string medicinetype_id,string medicinetype_name,int duration,string provider,int amount)
		{
			MedicineDataAccess mda = new MedicineDataAccess();
			bool isaddsuccess = mda.AddMedicine(medicine_name,medicinetype_id,medicinetype_name,duration,provider,amount);
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		public ActionResult GetPaginationMedicineAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			MedicineDataAccess mda = new MedicineDataAccess();
			var ms = mda.GetPaginationMedicine(pagesize, pageindex);
			return Content("{\"total\": " + mda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(ms) + "}");
		}

		public ActionResult DeleteMedicineByIdAction(string medicine_id)
		{
			MedicineDataAccess mda = new MedicineDataAccess();
			bool isdeletesuccess = mda.DeleteMedicineById(medicine_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除失败");
		}

		public ActionResult AddMedicineUseAction(string animal_id,string medicine_id,
			int medicine_amount,string medicine_person,string reason)
		{
			MedicineDataAccess mda = new MedicineDataAccess();
			var m = mda.GetMedicineById(medicine_id);
			MedicineUseDataAccess muda = new MedicineUseDataAccess();
			bool isaddsuccess = muda.AddMedicineUse(
				m.MedicineTypeID, medicine_id, animal_id, medicine_person, medicine_amount, reason
				);
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		public ActionResult GetPaginationMedicineUseAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			MedicineUseDataAccess muda = new MedicineUseDataAccess();
			var mus = muda.GetPaginationMedicineUse(pagesize,pageindex);
			return Content("{\"total\": " + muda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(mus) + "}");
		}

		public ActionResult DeleteMedicineUseByIdAction(string feeduse_id)
		{
			MedicineUseDataAccess muda = new MedicineUseDataAccess();
			bool isdeletesuccess = muda.DeleteMedicineUseById(feeduse_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除失败");
		}
	}
}