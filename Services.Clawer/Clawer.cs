using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Clawer
{
    public class Clawer : IClawer
    {
        private HtmlWeb htmlWeb;
        public Clawer()
        {
            this.htmlWeb = new HtmlWeb();
        }

        public async Task<VideoModel> GetVideoDownload(string url)
        {
            Uri uri = new Uri(url);
            var htmlDoc = GetFromLinkAsync(url);
            var linkVideo = GetLinkVideo(htmlDoc);
            var lstSubs = GetScriptPath4(htmlDoc);
            
            var videoVM = new VideoModel()
            {
                LinkDownload = linkVideo
            };

            if (lstSubs.Length > 0)
            {
                var scripts = lstSubs[4].Replace("\n", "").Split(',');
                var subEn = GetStringChar(scripts[0], '=')[1];
                var subVn = GetStringChar(scripts[1], '=')[1];
                videoVM.Sub1 = string.Format("{0}{1}", uri.Host, subEn.Replace("'", "").Trim());
                videoVM.Sub2 = string.Format("{0}{1}", uri.Host, subVn.Replace("'","").Trim());
            }
            return videoVM;
        }

        private string[] GetStringChar(string input, char charactor)
        {
            return input.Split(charactor);
        }

        private HtmlDocument GetFromLinkAsync(string url)
        {
            // From Web
            return htmlWeb.Load(url);
        }

        private string GetLinkVideo(HtmlDocument htmlDoc)
        {
            var videoId = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"video\"]/source[1]").FirstOrDefault();
            if (videoId == null) return "Link not found";

            return videoId.Attributes["src"].Value;
        }

        private string[] GetScriptPath4(HtmlDocument htmlDoc)
        {
            var script = htmlDoc.DocumentNode.SelectNodes("/html/body/script[4]").FirstOrDefault();
            if (script == null) return new string[] { "Not link "};
            return script.InnerText.Split(';');
        }
    }
}
