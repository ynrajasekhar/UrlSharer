using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlSharer
{
    public class UrlInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public override string ToString()
        {
            string toString = "{Title:" + Title + ", Description:" + Description + ", Images:[";
             if(Images != null)
             {
                 toString += string.Join(",",Images.ToArray());
             }
             else
             {
                 toString += "";
             }
            toString += "]}";
            return toString;
        }
    }
}
