using Storage.Models;
using System.Web.Mvc;
using System.Web.Security;
using Storage.Providers;

namespace Storage.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;
        public AccountController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public ActionResult Login()
        {
            if (_authProvider.IsLoggedIn)
            {
                return RedirectToAction("Index", "Storage");
            }
            else
            {
                return View();
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel model)
        {

            if (ModelState.IsValid && _authProvider.Login(model.Name, model.Password))
            {
                return RedirectToAction("Index", "Storage");
            }
            else
            {
                ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                return View(model);
            }
        }

        public ActionResult Register()
        {
            if (_authProvider.IsLoggedIn)
            {
                return RedirectToAction("Index", "Storage");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
                if (_authProvider.Register(model.Name, model.Password))
                {
                    return RedirectToAction("Index", "Storage");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    return View(model);
                }
            else
            {
                ModelState.AddModelError("", "Ошибка при регистрации");
                return View(model);
            }
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}