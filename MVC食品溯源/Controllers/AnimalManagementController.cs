using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;

namespace MVC食品溯源.Controllers
{
    public class AnimalManagementController : Controller
    {
        // GET: AnimalManagement
		// 此控制器主要用于牲畜养殖管理过程中的数据操作。
        public ActionResult Index()
        {
			

            return View();
        }

		public ActionResult GetAllAnimals()
		{
			//AnimalDataAccess ada = new AnimalDataAccess();

			string constring = "Data Source=MSI;Initial Catalog=食品溯源;Integrated Security=True";
			IDbConnection con = new SqlConnection(constring);
			string sql = "select * from [Animal]";
			var result = con.Query(sql, null, null, true, null, CommandType.Text);
			//ContentResult cr = Content("{\"total\":"+",\"rows\":"+JsonConvert.SerializeObject(result)+"}");
			ContentResult cr = Content(JsonConvert.SerializeObject(result));
			//var result = ada.getAllAnimals();
			//ContentResult cr = Content(JsonConvert.SerializeObject(result));
			//JsonResult js = Json(JsonConvert.SerializeObject(result));
			return cr;
		}
    }
}