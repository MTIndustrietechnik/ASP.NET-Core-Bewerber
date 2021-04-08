using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bewerber.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Bewerber.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment Environment;
        public HomeController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            string[] filepaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "Files/"));
           
            List<FileModel> list = new List<FileModel>();
            foreach (string filepath in filepaths)
            {
                list.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return View(list);
        }

        public FileResult DownloadFile(string filename)
        {
            string path = Path.Combine(this.Environment.WebRootPath, "Files/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", filename);
        }

        public IActionResult About() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View();
        }

        public IActionResult neu()
        {
            return View();
        }

        public interface IMailer
        {
            Task SendEmailAsync(string email, string subject, string body);
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            await Task.CompletedTask;
        }
    }
}
