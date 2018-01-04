using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using Newtonsoft.Json;

namespace MVC食品溯源.Controllers
{
    public class ManuWorkController : Controller
    {
        // GET: ManuWork
		// 加工厂管理平台的各项操作
        public ActionResult ManuWorkIndex()
        {
            return View();
        }

		public ActionResult AddManuWorkPage()
		{
			return View();
		}

		public ActionResult AlterManuWorkPage()
		{
			return View();
		}

		public ActionResult GetAllManuWorkInfo()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);
			ManuWorkDataAccess mwda = new ManuWorkDataAccess();
			//var mws = mwda.GetAllManuWork();
			var mws = mwda.GetAllManuWork();
			return Content("{\"total\": " + mwda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(mws) + "}");
		}

		public ActionResult AddManuWorkAction(string animal_id,string manu_info)
		{
			ManuWorkDataAccess mwda = new ManuWorkDataAccess();
			bool isaddsuccess = mwda.AddManuWorkInfo("XQGM1241JG", animal_id,manu_info);
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		public ActionResult AlterManuWorkByIdAction(string manu_id,string manu_info)
		{
			ManuWorkDataAccess mwda = new ManuWorkDataAccess();
			bool isaltersuccess = mwda.UpdateManuWorkInfoById(manu_id, manu_info);
			if (isaltersuccess)
				return Json("修改成功");
			else
				return Json("修改失败");
		}

		public ActionResult DeleteManuWorkByIdAction(string manu_id)
		{
			ManuWorkDataAccess mwda = new ManuWorkDataAccess();
			bool isdeletesuccess = mwda.DeleteManuWorkInfoById(manu_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除成功");
		}
    }
}