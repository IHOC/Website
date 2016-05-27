using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;

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

            // Get recent activity
            for (int index = 0; index < members.Count; index++)
            {
                if (members[index].StreamingNames.ContainsKey("YoutubeRSS"))
                    members[index].RecentActivty = GetYoutubeActivity(members[index].StreamingNames["YoutubeRSS"]);

            }

            return View(members);
        }

        /// <summary>
        /// Fetch the recent videos based on a youtube channel ID. This can be found by viewing the source of the user's channel
        /// and searching for channel_id. It will be a string of characters like: UC4-NKBq5WKSesQ54KVmyxjA
        /// 
        /// </summary>
        /// <param name="channelId">Youtube's internal channel_id value</param>
        /// <returns></returns>
        public Dictionary<string,string> GetYoutubeActivity(string channelId)
        {
            var activity = new Dictionary<string, string>();
            int maxRecent = 3;

            var r = XmlReader.Create("https://www.youtube.com/feeds/videos.xml?channel_id=" + channelId);
            var youtubeRss = SyndicationFeed.Load(r);
            r.Close();

            if (youtubeRss.Items != null && youtubeRss.Items.Count() > 0)
                for (int index = 0; index < youtubeRss.Items.Count() && index < maxRecent; index++ )
                {
                    var item = youtubeRss.Items.ElementAt(index);
                    activity.Add(item.Links[0].Uri.AbsoluteUri.ToString(), item.Title.Text.ToString());
                }

            //activity.Add("test", "test");

            return activity;
        }


	    public ActionResult ServerInfo()
	    {
	        return View();
	    }
	}
}