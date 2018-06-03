using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetLinkDownloadToomva.Models;
using Services.Infrashstructure;

namespace GetLinkDownloadToomva.Controllers
{
    public class HomeController : Controller
    {
        private IClawer _clawer;
        public HomeController(IClawer clawer)
        {
            _clawer = clawer;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetVideo(string url)
        {
            var videoVM = await _clawer.GetVideoDownload(url);
            return Json(new { response = videoVM });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
