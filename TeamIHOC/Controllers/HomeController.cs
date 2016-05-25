using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamIHOC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Contact TeamIHOC.";

			return View();
		}

		public ActionResult Irc()
		{
			return View();
		}

		public ActionResult Modding()
		{
			return View();
		}

	    public ActionResult Application()
	    {
	        return View();
	    }

	    public ActionResult Youtube()
	    {
	        return View();
	    }

	    public ActionResult ServerInfo()
	    {
	        return View();
	    }
	}
}