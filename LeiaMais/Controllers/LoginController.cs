using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace LeiaMais.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Autentica(String login, String senha)
        {
            if (WebSecurity.Login(login, senha))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}