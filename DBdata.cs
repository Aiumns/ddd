using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AdminPannel.Models;
using System.Web.Mvc;
namespace AdminPannel.DataAccessLayer
{
    public class DBdata
    {       
        //SqlCommand cmd = null;
        #region UserModule
        public string UserRegister(UserModels objuser)
        {
           SqlConnection con = null;
           string result = "";
           try
            {               
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Register", con);
                //cmd = new SqlCommand("Usp_Register", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", 0);
                cmd.Parameters.AddWithValue("@Username", objuser.UserName);
                cmd.Parameters.AddWithValue("@CountryId", objuser.CountryId);
                cmd.Parameters.AddWithValue("@StateId", objuser.StateId);
                cmd.Parameters.AddWithValue("@CityId", objuser.CityId);               
                cmd.Parameters.AddWithValue("@EmailId", objuser.User_Email);
                cmd.Parameters.AddWithValue("@MobileNo", objuser.User_MobileNo);
                cmd.Parameters.AddWithValue("@UserType", objuser.UserTypes);
                cmd.Parameters.AddWithValue("@Password", objuser.Password);
                cmd.Parameters.AddWithValue("@Userpic", objuser.User_pic);
                cmd.Parameters.AddWithValue("@IsActive",false);
                cmd.Parameters.AddWithValue("@Query",1);
                con.Open();
                result = Convert.ToString(cmd.ExecuteScalar());
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }        
        }

        public string UserLogin(UserLogin objuserlogin)
        {
            SqlConnection con = null;
            string result = "";
            try 
	        {              
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", objuserlogin.Emailid);
                cmd.Parameters.AddWithValue("@Password", objuserlogin.Password);               
                con.Open();
                result = Convert.ToString(cmd.ExecuteScalar());
                return result;
	        }
	        catch (Exception)
	        {		
		       throw;
	        }
        }

        #endregion

        //#region Mobile Data

        //public string InsertData(Mobiledata MD)
        //{
        //    SqlConnection con = null;
        //    string result = "";
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MobileID", 0); //i will pass zero to MobileID beacause its Primary .
        //        cmd.Parameters.AddWithValue("@MobileName", MD.MobileName);
        //        cmd.Parameters.AddWithValue("@MobileIMEno", MD.MobileIMEno);
        //        cmd.Parameters.AddWithValue("@mobileprice", MD.mobileprice);
        //        cmd.Parameters.AddWithValue("@mobileManufacured", MD.mobileManufacured);
        //        cmd.Parameters.AddWithValue("@Query",1);
        //        con.Open();
        //        result = cmd.ExecuteScalar().ToString();
        //        return result;
        //    }
        //    catch
        //    {
        //        return result = "";
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //public string UpdateData(Mobiledata MD)
        //{
        //    SqlConnection con = null;
        //    string result = "";
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MobileID", MD.MobileID);
        //        cmd.Parameters.AddWithValue("@MobileName", MD.MobileName);
        //        cmd.Parameters.AddWithValue("@MobileIMEno", MD.MobileIMEno);
        //        cmd.Parameters.AddWithValue("@mobileprice", MD.mobileprice);
        //        cmd.Parameters.AddWithValue("@mobileManufacured", MD.mobileManufacured);
        //        cmd.Parameters.AddWithValue("@Query", 2);
        //        con.Open();
        //        result = cmd.ExecuteScalar().ToString();
        //        return result;

        //    }
        //    catch
        //    {
        //        return result = "";
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //public string DeleteData(Mobiledata MD)
        //{
        //    SqlConnection con = null;
        //    string result = "";
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MobileID", MD.MobileID);
        //        cmd.Parameters.AddWithValue("@MobileName", null);
        //        cmd.Parameters.AddWithValue("@MobileIMEno", null);
        //        cmd.Parameters.AddWithValue("@mobileprice", 0);
        //        cmd.Parameters.AddWithValue("@mobileManufacured", null);
        //        cmd.Parameters.AddWithValue("@Query", 3);
        //        con.Open();
        //        result = cmd.ExecuteScalar().ToString();
        //        return result;
        //    }
        //    catch
        //    {
        //        return result = "";
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //public DataSet SelectAllData()
        //{
        //    SqlConnection con = null;
        //   // string result = "";
        //    DataSet ds = null;
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MobileID", 0); // i will pass zero to MobileID beacause its Primary .
        //        cmd.Parameters.AddWithValue("@MobileName", null);
        //        cmd.Parameters.AddWithValue("@MobileIMEno", null);
        //        cmd.Parameters.AddWithValue("@mobileprice", 0);
        //        cmd.Parameters.AddWithValue("@mobileManufacured", null);
        //        cmd.Parameters.AddWithValue("@Query", 4);
        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch
        //    {
        //        return ds;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //public DataSet SelectAllDatabyID(string MobileID)
        //{
        //    SqlConnection con = null;
        //    //string result = "";
        //    DataSet ds = null;
        //    try
        //    {
        //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //        SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@MobileID", MobileID); // i will pass zero to MobileID beacause its Primary .
        //        cmd.Parameters.AddWithValue("@MobileName", null);
        //        cmd.Parameters.AddWithValue("@MobileIMEno", null);
        //        cmd.Parameters.AddWithValue("@mobileprice", 0);
        //        cmd.Parameters.AddWithValue("@mobileManufacured", null);
        //        cmd.Parameters.AddWithValue("@Query", 5);
        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        ds = new DataSet();
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch
        //    {
        //        return ds;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //#endregion
 
        //#region Crude Operation with employee data

        //public string InsertEmp(Empdata Em)
        //       {
        //            #region not valuable
        //                    //SqlConnection con = null;
        //                    //string result = "";
        //                    //try
        //                    //{
        //                    //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
        //                    //    SqlCommand cmd = new SqlCommand("Usp_CrudEmployeeSp", con);
        //                    //    cmd.CommandType = CommandType.StoredProcedure;

        //                    //    //cmd.Parameters.AddWithValue("@Id", 1);
        //                    //    //cmd.Parameters.AddWithValue("@name", ED.EmployeeName);
        //                    //    //cmd.Parameters.AddWithValue("@address", ED.Address);              
        //                    //    //cmd.Parameters.AddWithValue("@gender", ED.Gender); 
        //                    //    //cmd.Parameters.AddWithValue("@country",ED.Country);
        //                    //    //cmd.Parameters.AddWithValue("@state", ED.State);
        //                    //    //cmd.Parameters.AddWithValue("@statement", "Insert");

        //                    //    cmd.Parameters.AddWithValue("@Id", 0);
        //                    //    cmd.Parameters.AddWithValue("@name", ED.EmployeeName);

        //                    //    cmd.Parameters.AddWithValue("@address", ED.Address);
        //                    //    cmd.Parameters.AddWithValue("@gender", ED.Gender);

        //                    //    //cmd.Parameters.AddWithValue("@country", ED.Country);
        //                    //    //cmd.Parameters.AddWithValue("@state", ED.State);
        //                    //    //cmd.Parameters.AddWithValue("@city", ED.City);

        //                    //    cmd.Parameters.AddWithValue("@Query",1);
        //                    //    con.Open();
        //                    //    result= cmd.ExecuteScalar().ToString();

        //                    //    return result;
        //                    //}
        //                    //catch
        //                    //{
        //                    //    return result = "";
        //                    //}
        //                    //finally
        //                    //{
        //                    //    con.Close();
        //                    //}
        //            #endregion

        //            SqlConnection con = null;
        //            string result = "";
        //            try
        //            {
        //                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //                //SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete", con);
        //                SqlCommand cmd = new SqlCommand("Usp_EmpInsertUpdateDelete", con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ID", 0); //i will pass zero to MobileID beacause its Primary .
        //                cmd.Parameters.AddWithValue("@Name", Em.Name);
        //                cmd.Parameters.AddWithValue("@Address", Em.Address);
        //                cmd.Parameters.AddWithValue("@City", Em.CityId);
        //                cmd.Parameters.AddWithValue("@State", Em.StateId);
        //                cmd.Parameters.AddWithValue("@Country", Em.CountryId);
        //                cmd.Parameters.AddWithValue("@Query", 1);
        //                con.Open();
        //                result = cmd.ExecuteScalar().ToString();
        //                return result;
        //            }
        //            catch
        //            {
        //                return result = "";
        //            }
        //            finally
        //            {
        //                con.Close();
        //            }
        //      }

        //    public string UpdateEmpData(Empdata Em)
        //    {
        //        SqlConnection con = null;
        //        string result = "";
        //        try
        //        {
        //            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //            SqlCommand cmd = new SqlCommand("Usp_EmpInsertUpdateDelete", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ID", Em.ID); //i will pass zero to MobileID beacause its Primary .
        //            cmd.Parameters.AddWithValue("@Name", Em.Name);
        //            cmd.Parameters.AddWithValue("@Address", Em.Address);
        //            //cmd.Parameters.AddWithValue("@City", MD.CityId);
        //            //cmd.Parameters.AddWithValue("@State", MD.StateId);
        //            //cmd.Parameters.AddWithValue("@Country", MD.CountryId);
        //            cmd.Parameters.AddWithValue("@City", Em.CityId);
        //            cmd.Parameters.AddWithValue("@State", Em.StateId);
        //            cmd.Parameters.AddWithValue("@Country", Em.CountryId);
        //            cmd.Parameters.AddWithValue("@Query", 2);
        //            con.Open();
        //            result = cmd.ExecuteScalar().ToString();
        //            return result;
        //        }
        //        catch
        //        {
        //            return result = "";
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }

        //    public string DELETEEmpData(Empdata EM)
        //    {
        //        SqlConnection con = null;
        //        string result = "";
        //        try
        //        {
        //            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //            SqlCommand cmd = new SqlCommand("Usp_EmpInsertUpdateDelete", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ID", EM.ID); //i will pass zero to MobileID beacause its Primary .
        //            cmd.Parameters.AddWithValue("@Name", null);
        //            cmd.Parameters.AddWithValue("@Address", null);
        //            cmd.Parameters.AddWithValue("@City", 0);
        //            cmd.Parameters.AddWithValue("@State", 0);
        //            cmd.Parameters.AddWithValue("@Country", 0);
        //            cmd.Parameters.AddWithValue("@Query", 3);
        //            con.Open();
        //            result = cmd.ExecuteScalar().ToString();
        //            return result;
        //        }
        //        catch
        //        {
        //            return result = "";
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }

        //    public DataSet SelectAllEmpbyID(string EmpID)
        //    {
        //        SqlConnection con = null;
        //        //string result = "";
        //        DataSet ds = null;
        //        try
        //        {
        //            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //            SqlCommand cmd = new SqlCommand("Usp_EmpInsertUpdateDelete", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ID", EmpID); //i will pass zero to MobileID beacause its Primary .
        //            cmd.Parameters.AddWithValue("@Name", null);
        //            cmd.Parameters.AddWithValue("@Address", null);
        //            cmd.Parameters.AddWithValue("@City", 0);
        //            cmd.Parameters.AddWithValue("@State", 0);
        //            cmd.Parameters.AddWithValue("@Country", 0);
        //            cmd.Parameters.AddWithValue("@Query", 5);
        //            con.Open();
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            da.SelectCommand = cmd;
        //            ds = new DataSet();
        //            da.Fill(ds);
        //            return ds;
        //        }
        //        catch
        //        {
        //            return ds;
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }

        //    public DataSet ShowAllEmpDetails() 
        //       {
        //            SqlConnection con = null;
        //          //  string result = "";
        //            DataSet ds = null;
        //            try
        //            {
        //                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        //                SqlCommand cmd = new SqlCommand("Usp_EmpInsertUpdateDelete", con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@id",0);
        //                cmd.Parameters.AddWithValue("@name",null);
        //                cmd.Parameters.AddWithValue("@address",null);
        //                cmd.Parameters.AddWithValue("@Country", 0);
        //                cmd.Parameters.AddWithValue("@state",0);
        //                cmd.Parameters.AddWithValue("@city",0);
        //                cmd.Parameters.AddWithValue("@Query", 4);
        //                con.Open();
        //                SqlDataAdapter da = new SqlDataAdapter();
        //                da.SelectCommand = cmd;
        //                ds = new DataSet();
        //                da.Fill(ds);
        //                return ds;
        //            }
        //            catch
        //            {
        //                return ds;
        //            }
        //            finally
        //            {
        //                con.Close();
        //            }    
        //      }

        //#endregion
     
    }    
}