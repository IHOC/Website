using System.Collections.Generic;

namespace TeamIHOC.Models
{
    public class MemberInfo
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        /// <summary>
        /// StreamingNames key is the service, value is the username/id/url
        /// </summary>
        public Dictionary<string, string> StreamingNames { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// RecentActivity key is URL, value is the name of the video
        /// </summary>
        public Dictionary<string, string> RecentActivty { get; set; }
    }
}