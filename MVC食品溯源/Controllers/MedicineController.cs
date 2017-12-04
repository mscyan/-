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

		public ActionResult GetPaginationMedicineType()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 10 : Convert.ToInt32(Request["rows"]);

			MedicineTypeDataAccess mtda = new MedicineTypeDataAccess();
			var mts = mtda.GetPaginationMedicineType(pagesize, pageindex);
			return Content("{\"total\": " + mtda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(mts) + "}");
		}
    }
}