using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using FourWalled.Utils;
using FourWalled.Models;
using System.Windows.Media.Imaging;

namespace FourWalled.Utils
{
    /// <summary>
    /// Always call DownloadSiteHTML after initializing the scraper class
    /// so that you get the siteHtml prior to performing other functions
    /// constructors cannot be async hence this problem is unavoidable
    /// </summary>
    public class ThumbnailScraper
    {
        public string CORE_URL = "http://4walled.cc/search.php?";
        public List<Uri> thumbnailList = new List<Uri>();
        public string siteHtml;

        public async Task<bool> DownloadSiteHTML(string parameters)
        {
            var httpClient = new HttpClient();
            siteHtml = await httpClient.GetStringAsync(new Uri(CORE_URL + parameters, UriKind.Absolute));
            return true;
        }

        public List<ImageModel> GenerateImageThumbnailClasses()
        {
            List<ImageModel> thumbModels = new List<ImageModel>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(siteHtml);
            var lis = doc.DocumentNode.SelectNodes("/html[1]/body[1]/center[2]/ul[1]/li");
            if (lis == null)
            {
                return thumbModels;
            }
            foreach (var li in lis)
            {
                var uri = li.SelectSingleNode("a").Attributes.Where(attr => attr.Name == "href").FirstOrDefault().Value;
                var thumb = li.SelectSingleNode("a").SelectSingleNode("img").Attributes.Where(attr => attr.Name == "src").FirstOrDefault().Value;
                if (uri != null && thumb != null)
                {
                    thumbModels.Add(new ImageModel(new BitmapImage(new Uri(thumb, UriKind.Absolute)), new Uri(uri, UriKind.Absolute)));
                }
            }
            return thumbModels;
        }
    }

    public static class WallpaperScraper
    {
        public static string resolution;
        public static string dateAdded;
        public static string tags;

        public static async Task<BitmapImage> ScrapeWallpaper(string url)
        {
            var httpClient = new HttpClient();
            var siteHtml = await httpClient.GetStringAsync(new Uri(url, UriKind.Absolute));
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(siteHtml);
            var hyperlinks = doc.DocumentNode.SelectNodes("//a");
            string wallpaper = string.Empty;

            foreach (var link in hyperlinks)
            {
                if (link.Attributes.Where(attr => attr.Name == "href").FirstOrDefault().Value.Contains(".jpg") || link.Attributes.Where(attr => attr.Name == "href").FirstOrDefault().Value.Contains(".png"))
                {
                    wallpaper = link.Attributes.Where(attr => attr.Name == "href").FirstOrDefault().Value;
                    break;
                }
            }

            var spans = doc.DocumentNode.SelectNodes("//span");
            foreach (var span in spans)
            {
                if (span.Attributes.Where(attr => attr.Name == "id").FirstOrDefault().Value == "info_resolution")
                {
                    resolution = span.InnerText;
                    break;
                }
            }
            foreach (var span in spans)
            {
                if (span.Attributes.Where(attr => attr.Name == "id").FirstOrDefault().Value == "info_dateadded")
                {
                    dateAdded = span.InnerText;
                    break;
                }
            }

            var inputs = doc.DocumentNode.SelectNodes("//input");
            foreach (var input in inputs)
            {
                if (input.Attributes.Where(attr => attr.Name == "name").FirstOrDefault().Value == "tagsText")
                {
                    tags = input.Attributes.Where(attr => attr.Name == "value").FirstOrDefault().Value;
                    break;
                }
            }

            return new BitmapImage(new Uri(wallpaper, UriKind.Absolute));
        }
    }
}
