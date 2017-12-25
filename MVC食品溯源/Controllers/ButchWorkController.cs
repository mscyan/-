using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using Newtonsoft.Json;
using System.IO;

namespace MVC食品溯源.Controllers
{
    public class ButchWorkController : Controller
    {
		static string videopath = "";
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
			bool isaddsuccess = bwda.AddButchWork("JHBY8237TZ", butch_info, animal_id, animal_state,videopath);
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

		public ActionResult Upload(FormCollection form)
		{
			string len = "";
			if (Request.Files.Count == 0)
			{
				//return Json("文件数为0");
				return this.JavaScript("alert('caozuochenggong');");
			}
			var file = Request.Files[0];
			if (file.ContentLength == 0)
			{
				return Json("文件大小为0");
				//return "filelen_0";
			}
			else
			{
				file = Request.Files[0];
				string target = Server.MapPath("/") + ("/Videos/");
				string filename = file.FileName;
				string path = target + filename;
				file.SaveAs(path);

				byte[] temp = new byte[file.InputStream.Length];
				file.InputStream.Read(temp, 0, (int)file.InputStream.Length);
				FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				fs.Write(temp, 0, temp.Length);
				len = temp.Length.ToString();
				videopath = path;
				fs.Close();
			}
			//return "上传成功" + len;
			//return JavaScript("$.dialog.alert('上传成功')");
			return Content("<script>alert('操作成功')</script>");
		}
    }
}