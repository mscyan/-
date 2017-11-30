using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using DataAccessLibrary;

namespace MVC食品溯源.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult CompanyIndex()
        {
            return View();
        }

		public ActionResult AddCompany()
		{
			return View();
		}

		public ActionResult GetAllCompanyAction()
		{
			List<Company> list = new List<Company>();



			return Json(list);
		}
    }
}