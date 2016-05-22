using System.Collections.Generic;

namespace TeamIHOC.Models
{
    public class MemberInfo
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public Dictionary<string, string> StreamingNames { get; set; }
        public string Description { get; set; }
    }
}