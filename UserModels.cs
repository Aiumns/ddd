using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.WebPages.Html;
namespace AdminPannel.Models
{
    public partial class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
    public partial class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
    }
    public partial class City
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int StateID { get; set; }
        public int Countryid { get; set; }
    }  
    public class UserModels
    {
        public UserModels()
        {
            this.tblcountry = new List<SelectListItem>();
            this.tblState = new List<SelectListItem>();
            this.tblcity = new List<SelectListItem>();
        }

        public List<SelectListItem> tblcountry { get; set; }
        public List<SelectListItem> tblState { get; set; }
        public List<SelectListItem> tblcity { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        //public string CountryName { get; set; }
        //public string StateName { get; set; }
        //public string CityName { get; set; }


        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "User Address is required.")]        
        //public string User_Address { get; set; }

        [Required(ErrorMessage = "Email Id is required.")]
        [DataType(DataType.EmailAddress)]        
        public string User_Email { get; set; }

        //[Required(ErrorMessage = "Mobile No is required.")]
        //[StringLength(10, ErrorMessage = "Mobile No Must Be 10th Digit", MinimumLength = 10)]
        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile No")]
        public string User_MobileNo { get; set; }

        public UserType UserTypes { get; set; }

        public string  TypeOfUsers { get; set; }      


        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        //[Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }


        public string User_pic { get; set; }

        public bool IsActive { get; set; }

        public DataSet StoreAllUserData { get; set; }     
    }
    public class UserLogin
    {
        public string Emailid { get; set; }
        public string Password { get; set; }        
    }
    public enum UserType
    {
        Admin,
        Manager,
        Sales
    }
}