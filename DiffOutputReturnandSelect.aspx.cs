using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class DiffOutputReturnandSelect : System.Web.UI.Page
{
    //SqlConnection cnn = null;
    //SqlCommand cmd= null;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString()))
        {
            //using (SqlCommand cmd = new SqlCommand("Out_test1")) 
            //using (SqlCommand cmd = new SqlCommand("Return_test1"))
            string oUsername = "jjayswal";
            //int InOutParamValue = 17;
            object outputParam = null;
            object IntReturn = null;
            //object inoutParam = null;
            string IntReturnStr = "";
            string outputParamStr = "";
            using (SqlCommand cmd = new SqlCommand()) 
             {
                cmd.CommandText = "MyStoredProcedure";
                cmd.Connection = cnn;             
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                //cmd.Parameters.AddWithValue("@inValue", 1);
                //SqlParameter outputIdParam = new SqlParameter("@OutValue", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.InputOutput                    
                //};

                // Set Input Parameter
                SqlParameter oParam = new SqlParameter("@Username", oUsername);
                oParam.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(oParam);

                // Set Output Paramater
                SqlParameter OutputParam = new SqlParameter("@OutputParam", SqlDbType.VarChar, 50);
                OutputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(OutputParam);

                // Set Input Output Parameter
                //SqlParameter InOutParam = new SqlParameter("@InputOutputParam", InOutParamValue);
                //InOutParam.SqlDbType = SqlDbType.Int;
                //InOutParam.Direction = ParameterDirection.InputOutput;
                //cmd.Parameters.Add(InOutParam);

                //Set ReturnValue Parameter
                SqlParameter RetParam = new SqlParameter("ReturnValue", DBNull.Value);
                RetParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(RetParam);
               
                //string returnval= Convert.ToString(cmd.ExecuteNonQuery());

                Int32  scalerreturn = Convert.ToInt32(cmd.ExecuteScalar());

                cnn.Close();

                 IntReturnStr = Convert.ToString(cmd.Parameters["ReturnValue"].Value);
                 IntReturn = cmd.Parameters["ReturnValue"].Value;

                 outputParamStr = Convert.ToString(cmd.Parameters["@OutputParam"].Value);
                 outputParam = cmd.Parameters["@OutputParam"].Value;

                //if(IntReturn == 0)
                // {
                //    outputParam = cmd.Parameters["@OutputParam"].Value;
                //    //inoutParam = cmd.Parameters["@InputOutputParam"].Value;
                // }
                //if (IntReturn == 1)
                //{
                    //outputParam = cmd.Parameters["@OutputParam"].Value;
                    //inoutParam = cmd.Parameters["@InputOutputParam"].Value;
                //}
            }
        }
    }
}