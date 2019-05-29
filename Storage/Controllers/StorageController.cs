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
        private readonly IFileRepository _fileRepositoty;
        private readonly AuthProvider _authProvider;
        public StorageController(IFileRepository fileRepository, AuthProvider authProvider)
        {
            _authProvider = authProvider;
            _fileRepositoty = fileRepository;
        }
        [Authorize]
        public ActionResult Index()
        {
            var viewModel = new ListViewSearchModel(_fileRepositoty, "");
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
                string pathFile = "~/Files/" + User.Identity.Name + "/";
                string pathIco = "~/Files/Ico/" + User.Identity.Name + "/";
                if (!Directory.Exists(Server.MapPath(pathFile)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathFile));
                }
                if (!Directory.Exists(Server.MapPath(pathIco)))
                {
                    Directory.CreateDirectory(Server.MapPath(pathIco));
                }
                string filename = Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath(pathFile + filename));
                Icon extractedIcon = Icon.ExtractAssociatedIcon(Server.MapPath(pathFile + filename));
                string icostr = filename;
                string v = Path.GetExtension(filename); 
                icostr = icostr.Replace(v,"") + ".jpg";
                Bitmap bitmap = extractedIcon.ToBitmap();
                bitmap.Save(Server.MapPath(pathIco + icostr));
                icostr = "Files/Ico/" + User.Identity.Name + "/" + icostr;
                string path = "Files/" + User.Identity.Name + "/" + filename;
                DateTime date = DateTime.Now;
                int author = _authProvider.SearchUser(User.Identity.Name);
                _fileRepositoty.Add(filename, date, author,icostr, path);
            }
            return RedirectToAction("Index");
        }
    }
}