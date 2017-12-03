using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;

namespace MVC食品溯源.Controllers
{
    public class FeedController : Controller
    {
        // GET: Feed
        public ActionResult FeedTypePage()
        {
            return View();
        }

		public ActionResult FeedPage()
		{
			return View();
		}

		public ActionResult FeedUsePage()
		{
			return View();
		}


		// 添加饲料种类
		public ActionResult AddFeedTypeAction(string feedtype_name)
		{
			FeedTypeDataAccess ftda = new FeedTypeDataAccess();
			bool isaddsuccess = ftda.AddFeedType(feedtype_name);
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
			FeedTypeDataAccess ftda = new FeedTypeDataAccess();
			var fts = ftda.GetAllFeedType();
			return Json(fts);
		}

		//更新饲料种类
		public ActionResult UpdateFeedTypeById(string feedtype_id,string feedtype_name)
		{
			FeedTypeDataAccess ftda = new FeedTypeDataAccess();
			bool isupdatesuccess = ftda.UpdateNameByID(feedtype_id, feedtype_name);
			if (isupdatesuccess)
				return Json("更新成功");
			else
				return Json("更新失败");
		}

		//添加饲料
		public ActionResult AddFeedAction(string feedtype_id,string feed_name,string feedtype_name,int duration,string provider,int amount)
		{
			FeedDataAccess fda = new FeedDataAccess();
			bool isaddsuccess = fda.AddFeedInfo(feedtype_id,feed_name,feedtype_name,duration,provider,amount);
			if (isaddsuccess)
				return Json("添加成功");
			else
				return Json("添加失败");
		}

		//根据饲料删除饲料
		public ActionResult DeleteFeedAction(string feed_id)
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
			FeedDataAccess fda = new FeedDataAccess();
			var fs = fda.GetAllFeedInfo();
			return Json(fs);
		}

		//更新饲料表
		//public ActionResult UpdateFeedByIdAction()
		//{
		//	//FeedDataAccess fda = new FeedDataAccess();
		//	//fda.UpdateFeedInfoById(feed_id,)
		//	return Json("");
		//}

		//添加喂养记录
		public ActionResult AddFeedUseAction()
		{
			FeedUseDataAccess fuda = new FeedUseDataAccess();
			//bool isaddsuccess = fuda.
			return Json("");
		}

		//根据ID删除喂养记录
		public ActionResult DeleteFeedUseAction()
		{
			return Json("");
		}

		//获得所有喂养记录
		public ActionResult GetAllFeedUseAction()
		{
			FeedUseDataAccess fuda = new FeedUseDataAccess();
			var fus = fuda.GetAllFeedUseData();
			return Json(fus);
		}

		//更新喂养记录表
		public ActionResult UpdateFeedUseByIdAction()
		{
			return Json("");
		}
	}
}