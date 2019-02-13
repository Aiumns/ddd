using AdminPannel.Models;
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
            //string strName = Request["userId"].ToString();
            //string pass = Request["password"].ToString();

            //string url = string.Format("/User/Login?EmailId={0}", "jitendranoidda333");
            // return Redirect(url);

            //UserLogin data = TempData["mydata"] as UserLogin;
            //string strName = data.Emailid;
            //string pass = data.Password;
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