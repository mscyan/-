using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using Newtonsoft.Json;

namespace MVC食品溯源.Controllers
{
    public class FeedController : Controller
    {
        // GET: Feed
        public ActionResult FeedTypePage()
        {
            return View();
        }

		public ActionResult AddFeedTypePage()
		{
			return View();
		}

		public ActionResult FeedPage()
		{
			return View();
		}

		public ActionResult AddFeedPage()
		{
			return View();
		}

		public ActionResult FeedUsePage()
		{
			return View();
		}

		public ActionResult AddFeedUsePage()
		{
			return View();
		}


		// 添加饲料种类
		public ActionResult AddFeedTypeAction(string feedtype_name)
		{
			FeedTypeDataAccess ftda = new FeedTypeDataAccess();
			bool isaddsuccess = ftda.AddFeedType(feedtype_name.Trim());
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		//根据ID删除饲料种类
		public ActionResult DeleteFeedTypeByIdAction(string feedtype_id)
		{
			FeedTypeDataAccess ftda = new FeedTypeDataAccess();
			bool isdeletesuccess = ftda.DeleteRowByID(feedtype_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除成功");
		}

		//获取所有的饲料种类
		public ActionResult GetAllFeedTypeAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);

			FeedTypeDataAccess ftda = new FeedTypeDataAccess();
			var fts = ftda.GetPaginationFeedType(pagesize, pageindex);
			return Content("{\"total\": " + ftda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(fts) + "}");
		}

		//更新饲料种类
		public ActionResult UpdateFeedTypeByIdAction(string feedtype_id,string feedtype_name)
		{
			FeedTypeDataAccess ftda = new FeedTypeDataAccess();
			bool isupdatesuccess = ftda.UpdateNameByID(feedtype_id, feedtype_name);
			if (isupdatesuccess)
				return Json("更新成功");
			else
				return Json("更新失败");
		}

		//添加饲料
		public ActionResult AddFeedAction(string feed_name, string feedtype_id,string feedtype_name,string duration,string provider,string amount)
		{
			FeedDataAccess fda = new FeedDataAccess();
			bool isaddsuccess = fda.AddFeedInfo(feedtype_id,feed_name,feedtype_name,int.Parse(duration),provider,int.Parse(amount));
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		//根据ID删除饲料
		public ActionResult DeleteFeedByIdAction(string feed_id)
		{
			FeedDataAccess fda = new FeedDataAccess();
			bool isdeletesuccess = fda.DeleteFeedInfoById(feed_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除失败");
		}

		//获得所有饲料
		public ActionResult GetAllFeedAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);
			FeedDataAccess fda = new FeedDataAccess();
			var fs = fda.GetPaginationFeed(pagesize,pageindex);
			return Content("{\"total\": " + fda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(fs) + "}");
		}

		//更新饲料表
		//public ActionResult UpdateFeedByIdAction()
		//{
		//	//FeedDataAccess fda = new FeedDataAccess();
		//	//fda.UpdateFeedInfoById(feed_id,)
		//	return Json("");
		//}

		//添加喂养记录
		public ActionResult AddFeedUseAction(string feed_id,string animal_id,string feed_person,int feed_amount)
		{
			FeedUseDataAccess fuda = new FeedUseDataAccess();
			bool isaddsuccess = fuda.AddFeedUse(feed_id, animal_id, feed_person, feed_amount);

			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		//根据ID删除喂养记录
		public ActionResult DeleteFeedUseAction(string feeduse_id)
		{
			FeedUseDataAccess fuda = new FeedUseDataAccess();
			bool isdeletesuccess = fuda.DeleteFeedUseById(feeduse_id);
			if (isdeletesuccess)
				return Json("删除成功");
			else
				return Json("删除成功");
		}

		//获得所有喂养记录
		public ActionResult GetAllFeedUseAction()
		{
			int pageindex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
			int pagesize = Request["rows"] == null ? 0 : Convert.ToInt32(Request["rows"]);
			FeedUseDataAccess fuda = new FeedUseDataAccess();
			var fus = fuda.GetAllFeedUseData();
			return Content("{\"total\": " + fuda.GetCount().ToString() + ",\"rows\":" + JsonConvert.SerializeObject(fus) + "}");
		}

		//更新喂养记录表
		public ActionResult UpdateFeedUseByIdAction()
		{
			return Json("");
		}
	}
}