using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using Newtonsoft.Json;

namespace MVC食品溯源.Controllers
{
    public class ButchWorkController : Controller
    {
		// GET: ButchWork
		// 屠宰场管理平台的各项操作
		public ActionResult ButchWorkIndex()
        {
            return View();
        }

		//添加信息页面
		public ActionResult AddButchWorkPage()
		{
			return View();
		}

		//修改页面
		public ActionResult AlterButchWorkPage()
		{
			return View();
		}

		//返回所有屠宰操作
		public ActionResult GetAllButchWorkAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			ButchWorkDataAccess bwda = new ButchWorkDataAccess();
			var bws = bwda.GetPaginationButchWorkInfo(pagesize,pageindex);
			return Content("{\"total\": " + bwda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(bws) + "}");
		}

		//根据id删除指定操作
		public ActionResult DeleteButchWorkById(string butch_id)
		{
			ButchWorkDataAccess bwda = new ButchWorkDataAccess();
			bool isdeletesuccess = bwda.DeleteButchWorkById(butch_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除失败");
		}

		public ActionResult AddOneButchWorkInfo(string butch_info,string animal_id,string animal_state)
		{
			ButchWorkDataAccess bwda = new ButchWorkDataAccess();
			bool isaddsuccess = bwda.AddButchWork("JHBY8237TZ", butch_info, animal_id, animal_state);
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		public ActionResult AlterButchWorkInfoById(string butch_id, string butch_info, string animal_state)
		{
			ButchWorkDataAccess bwda = new ButchWorkDataAccess();
			bool isaltersuccess = bwda.UpdateButchWork(butch_id,butch_info,animal_state);
			if (isaltersuccess)
				return Json("修改成功");
			else
				return Json("修改失败");
		}
    }
}