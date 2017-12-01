using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;

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
			ButchWorkDataAccess bwda = new ButchWorkDataAccess();
			var bws = bwda.GetAllButchWorkInfo();
			return Json(bws);
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
    }
}