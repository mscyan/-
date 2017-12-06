using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using Newtonsoft.Json;

namespace MVC食品溯源.Controllers
{
    public class SalesController : Controller
    {
		// GET: Sales
		// 超市/市场的管理平台的各项操作
		public ActionResult SaleIndex()
        {
            return View();
        }

		public ActionResult AddSalePage()
		{
			return View();
		}

		public ActionResult AlterSalepage()
		{
			return View();
		}

		public ActionResult AddSaleAction(string market_id,string sale_position, string animal_id, string sale_type, string has_saled)
		{
			SaleInfoDataAccess sda = new SaleInfoDataAccess();
			bool isaddsuccess = sda.AddSaleInfo(market_id, animal_id, null, sale_position, sale_type);
			if(isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		public ActionResult GetPaginationSaleAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			SaleInfoDataAccess sda = new SaleInfoDataAccess();
			var ss = sda.GetPaginationSaleInfo(pagesize, pageindex);

			return Content("{\"total\": " + sda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(ss) + "}");
		}

		public ActionResult UpdateSaleByIdAction(string sale_id,DateTime sale_time,string has_saled)
		{
			SaleInfoDataAccess sda = new SaleInfoDataAccess();
			bool isaltersuccess = sda.UpdateSaleInfo(sale_id, has_saled, sale_time);
			if (isaltersuccess)
				return Json("修改成功");
			else
				return Json("修改失败");
		}

		public ActionResult DeleteSaleByIdAction(string sale_id)
		{
			SaleInfoDataAccess sda = new SaleInfoDataAccess();
			bool isdeletesuccess = sda.DeleteSaleInfoById(sale_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除失败");
		}
    }
}