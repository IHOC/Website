using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            List<Models.MemberInfo> members;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Content/members.json")))
            {
                string json = r.ReadToEnd();
                members = JsonConvert.DeserializeObject<List<Models.MemberInfo>>(json);
            }

            // Put members with pictures before members without. Alphabetize both groups
            members.Sort((a,b) =>
            {
                if (String.IsNullOrEmpty(a.ImageURL) && !String.IsNullOrEmpty(b.ImageURL))
                    return 1;
                else if (!String.IsNullOrEmpty(a.ImageURL) && String.IsNullOrEmpty(b.ImageURL))
                    return -1;
                else
                {
                    return String.Compare(a.Name, b.Name);
                }
            });

            return View(members);
        }
    }
}