using GetLinkDownloadToomva.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services.Clawer;
using Services.WriteFile;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace GetLinkDownloadToomva.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClawer _clawer;
        private readonly IWriteFile _writeFile;
        private IHostingEnvironment _hostingEnvironment;
        private readonly string _folderSave = "writeFiles";
        public HomeController(IClawer clawer, IWriteFile writeFile, IHostingEnvironment hostingEnvironment)
        {
            _clawer = clawer;
            _writeFile = writeFile;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            string filePath = NormalizePath("email.txt");
            _writeFile.WriteTextAsync(filePath, $"test ne {DateTime.Now.TimeOfDay}").Wait();
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

        private string _pathFolder;
        protected virtual string pathFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_pathFolder))
                {
                    var physicalPath = _hostingEnvironment.WebRootFileProvider.GetFileInfo(_folderSave).PhysicalPath;
                    _pathFolder = InitFolderAssets(physicalPath);
                }
                return this._pathFolder;
            }
        }

        private string InitFolderAssets(IHostingEnvironment hostingEnvironment, string pathString)
        {
            var path = hostingEnvironment.WebRootFileProvider.GetFileInfo(pathString).PhysicalPath;
            var directory = Path.Combine(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }

        private string NormalizePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return pathFolder;
            }

            return Path.Combine(pathFolder, path);
        }
    }
}
