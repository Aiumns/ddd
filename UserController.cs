//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
////using System.Web.WebPages.Html;
//using AdminPannel.Models;
//using System.Configuration;
//using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPannel.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace AdminPannel.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/
        public ActionResult Index()
        {           
            return View();
        }        
        public ActionResult Signup() 
        { 
               UserModels model = new UserModels();               
               ViewBag.tblcountry = PopulateDropDown("SELECT CountryId, CountryName FROM tblcountry", "CountryName", "CountryId");
               if (TempData["ActiontoAction"] != null)  //checking model is valid or not               
                {
                    //ViewData["result3"] = TempData.Peek("result2").ToString();
                  if (Convert.ToInt32(TempData["ActiontoAction"]) > 0)
                   {
                       ViewData["Status"] = "Success";           
                   }                            
                }
                else
                {
                    ViewData["Status"] = null; //TempData.Peek("result2").ToString();
                }
                //ViewData["result3"] = TempData.Peek("result2").ToString();
                // string data = TempData.Peek("result2").ToString();
                return View(model); 
        } 
        [HttpPost]
        public ActionResult Signup(UserModels Objuser)
        { 
            if (ModelState.IsValid)  //checking model is valid or not
            {                
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Objuser.User_pic = "~/Uploads/" + Path.GetFileName(Objuser.User_pic); 
                }
                else if (Directory.Exists(path)) 
                {
                    Objuser.User_pic = "~/Uploads/" + Path.GetFileName(Objuser.User_pic); 
                }              
                // Objuser.User_pic = Convert.ToString(TempData["fileRoute"]); 
                DataAccessLayer.DBdata objDB = new DataAccessLayer.DBdata(); //calling class DBdata
                string result = objDB.UserRegister(Objuser); // passing Value to DBClass from model
                TempData["ActiontoAction"] = result; //"Successfully updated";
                ModelState.Clear(); //clearing model
                return RedirectToAction("Signup");
                //return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]           
        public ActionResult Login()
        {
            //UserLogin user = new UserLogin();
            //ViewData["PersonName"] = "Test Name";
            //ViewBag.PersonName = "Test Name";
            //return View(user);           
            //UserLogin data = new UserLogin()
            // {
            //     Emailid = "jitendranoida22@gmail.com",
            //     Password = "123"               
            // };
            // TempData["mydata"] = data;
             //string url=string.Format("/Home/Index?EmailId={0}&Password={1}",data.Emailid,data.Password);
             //return Redirect(url);
             //return RedirectToAction("Index", "Home", new { userId = "jitendranoida22@gmail.com" ,password="123"});
             //return RedirectToAction("Index", "Home");
             return View();
        }
        
        [HttpPost]
        public ActionResult Login(UserLogin SignUser)//(string username)//(FormCollection frm)//UserLogin SignUser)
        {

           // return View();
            //return Content(user.Emailid.ToString());
            //string strName = Convert.ToString(username);
            //FormCollection frm = new FormCollection();
            //string strName = Request["username"].ToString();
            //string str = frm["username"].ToString();
            //string strName = frms["username"].ToString();
            //return View();
            string result = "";
            if (ModelState.IsValid)
            {
                DataAccessLayer.DBdata objDB = new DataAccessLayer.DBdata(); //calling class DBdata
                result = objDB.UserLogin(SignUser);
            }
            if (result == "Validuser")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        //public EmptyResult FileUploading(HttpPostedFileBase postedFile)
        //{
        //    if (postedFile != null)
        //    {
        //        string path = Server.MapPath("~/Uploads/");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
        //        TempData["fileRoute"] = path + Path.GetFileName(postedFile.FileName);
        //    }
        //    //return RedirectToAction("Signup");  
        //    return new EmptyResult();
        //}

        private static List<SelectListItem> PopulateDropDown(string query, string textColumn, string valueColumn)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr[textColumn].ToString(),
                                Value = sdr[valueColumn].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }

        [HttpPost]
        public JsonResult AjaxMethod(string type, int value)
        {
            UserModels model = new UserModels();
            switch (type)
            {
                case "CountryId":
                    model.tblState = PopulateDropDown("SELECT StateId, StateName FROM tblState WHERE CountryId = " + value, "StateName", "StateId");
                    break;
                case "StateId":
                    model.tblcity = PopulateDropDown("SELECT CityId, CityName FROM tblcity WHERE StateId = " + value, "CityName", "CityId");
                    break;
            }
            return Json(model);
        }

        [HttpPost]
        [ActionName("FillDropDown")]
        public ActionResult Signup(int countryId, int stateId, int cityId)
        {
            UserModels model = new UserModels();
            model.tblcountry = PopulateDropDown("SELECT CountryId, CountryName FROM tblcountry", "CountryName", "CountryId");
            model.tblState = PopulateDropDown("SELECT StateId, StateName FROM tblState WHERE CountryId = " + countryId, "StateName", "StateId");
            model.tblcity = PopulateDropDown("SELECT CityId, CityName FROM tblcity WHERE StateId = " + stateId, "CityName", "CityID");
            return View(model);
        }       
	}
}