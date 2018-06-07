using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Services.Clawer
{
    public interface IClawer
    {
       Task<VideoModel> GetVideoDownload(string url);
    }

}
