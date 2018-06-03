using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Services.Infrashstructure
{
    public interface IClawer
    {
       Task<VideoModel> GetVideoDownload(string url);
    }

}
