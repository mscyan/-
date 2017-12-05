using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using Newtonsoft.Json;

namespace MVC食品溯源.Controllers
{
    public class CheckController : Controller
    {
        // GET: Check
        public ActionResult CheckIndex()
        {
            return View();
        }

		public ActionResult AddCheckPage()
		{
			return View();
		}

		public ActionResult AlterCheckPage()
		{
			return View();
		}

		public ActionResult AddCheckAction(string check_position,string check_person,string check_result,string animal_id,string animal_state)
		{
			CheckDataAccess cda = new CheckDataAccess();
			bool isaddsuccess = cda.AddCheck(check_position, check_person, check_result, animal_id, animal_state);
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		public ActionResult UpdateCheckByIdAction(string check_id,string check_person,string check_result,string animal_state)
		{
			CheckDataAccess cda = new CheckDataAccess();
			bool isaltersuccess = cda.UpdateHealthCheckById(check_id,check_person,check_result,animal_state);
			if (isaltersuccess)
				return Json("修改成功");
			else
				return Json("修改失败");
		}

		public ActionResult GetPaginationCheckAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			CheckDataAccess cda = new CheckDataAccess();
			var cs = cda.GetPaginationHealthCheck(pagesize, pageindex);
			return Content("{\"total\": " + cda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(cs) + "}");
		}

		public ActionResult DeleteCheckById(string check_id)
		{
			CheckDataAccess cda = new CheckDataAccess();
			bool isdeletesuccess = cda.DeleteHealthCheckById(check_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除失败");
		}
    }
}