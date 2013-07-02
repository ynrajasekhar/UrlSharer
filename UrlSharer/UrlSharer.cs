using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using FastImage;
namespace UrlSharer
{
    public class UrlSharer
    {
        public static UrlInfo GetUrlInfo(string url)
        {
            UrlInfo urlInfo = new UrlInfo();
            var document = new HtmlWeb().Load(url);
            HtmlNode titleNode = document.DocumentNode.SelectSingleNode("//title");
            if(titleNode!=null)
            {
                urlInfo.Title = titleNode.InnerText;
            }
            else
            {
                urlInfo.Title = url;
            }
            HtmlNode node = document.DocumentNode.SelectSingleNode("//meta[@name='description']");
            if (node != null)
            {
                urlInfo.Description = node.GetAttributeValue("content", "");
            }
            else
            {
                bool foundDescription = false;
                HtmlNode bodyNode = document.DocumentNode.SelectSingleNode("//body");
                if (bodyNode != null)
                {
                    HtmlNodeCollection pNodes = bodyNode.SelectNodes(".//p");
                    foreach (HtmlNode htmlNode in pNodes)
                    {
                        if(htmlNode.InnerText.Length > 0)
                        {
                            urlInfo.Description = htmlNode.InnerText;
                            foundDescription = true;
                            break;
                        }
                    }
                    
                }
                if(!foundDescription)
                {
                    urlInfo.Description = urlInfo.Title;
                }
            }
            urlInfo.Images = new List<string>(3);
            var urls = document.DocumentNode.Descendants("img")
                .Select(e => e.GetAttributeValue("src", null))
                .Where(s => !String.IsNullOrEmpty(s));
            var baseUrl = new Uri(url);
            var fastImage = new FastImage.FastImage();
            foreach (string s in urls)
            {
                if (urlInfo.Images.Count < 100)
                {
                    var absoluteUri = new Uri(baseUrl, s);
                    ImageInfo imageInfo = fastImage.GetImageInfo(absoluteUri.ToString());
                    if ((imageInfo.Width >= 50 && imageInfo.Height >= 100) ||
                        (imageInfo.Width >= 100 && imageInfo.Height >= 50))
                    {
                        urlInfo.Images.Add(absoluteUri.ToString());
                    }
                }
            }
            return urlInfo;
        }

        public static void Main(string[] args)
        {
            GetUrlInfo("http://twitter.com/");
        }
    }
}
