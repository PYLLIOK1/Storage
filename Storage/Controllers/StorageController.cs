using System;
using System.Web;
using System.Web.Mvc;
using Storage.Core;
using Storage.Models;
using System.Drawing;
using System.IO;
using Storage.Providers;

namespace Storage.Controllers
{
    public class StorageController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IFileRepository _fileRepositoty;
        public StorageController(IFileProvider fileProvider, IFileRepository fileRepository)
        {
            _fileProvider = fileProvider;
            _fileRepositoty = fileRepository;
        }
        [Authorize]
        public ActionResult Index()
        {
            var viewModel = new ListViewSearchModel(_fileRepositoty, "");
            ViewBag.Title = "Список файлов";
            return View("Index", viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index(string search)
        {
            var viewModel = new ListViewSearchModel(_fileRepositoty,search);
            return PartialView("List", viewModel);
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                
                string filename = Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Files/" + filename));
                DateTime date = DateTime.Now;
                string author = User.Identity.Name;
                string path = Server.MapPath("~/Files/" + filename);
                Icon extractedIcon = Icon.ExtractAssociatedIcon(Server.MapPath("~/Files/" + filename));
                string icostr = filename;
                string v = Path.GetExtension(upload.FileName); 
                icostr = icostr.Replace(v,"") + ".ico";
                Bitmap bitmap = extractedIcon.ToBitmap();
                bitmap.Save(Server.MapPath("~/Files/Ico/" + icostr ));
                icostr = "/Files/Ico/" + icostr;
                _fileProvider.AddFileUser(filename, date, author,icostr, path);
            }
            return RedirectToAction("Index");
        }
    }
}