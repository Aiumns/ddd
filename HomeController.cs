using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AdminPannel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            // Redirecting to Login page after deleting Session
            return RedirectToAction("Login","User");
        }
    }
}