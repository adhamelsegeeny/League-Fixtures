using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Sports
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string user = Username.Text;
            string pass = Password.Text;

            SqlCommand loginproc = new SqlCommand("userLogin", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@username", user));
            loginproc.Parameters.Add(new SqlParameter("@password", pass));

            SqlParameter success= loginproc.Parameters.Add(new SqlParameter("@success", SqlDbType.Int));
            SqlParameter type = loginproc.Parameters.Add(new SqlParameter("@userType", SqlDbType.VarChar,20));

            SqlCommand check = new SqlCommand("checkFan", conn);
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@username", user));
            SqlParameter blocked = check.Parameters.Add(new SqlParameter("@blocked", SqlDbType.Int));
            blocked.Direction = ParameterDirection.Output;



            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;

            conn.Open();
            loginproc.ExecuteNonQuery();
           

            if (success.Value.ToString().Equals("1"))
            {
                Session["user"] = user;

                if (type.Value.ToString().Equals("fan"))
                {
                    check.ExecuteNonQuery();
                    if (blocked.Value.ToString().Equals("0"))
                    {
                        Response.Redirect("Fan.aspx");
                    }
                    else
                    {
                        MessageBox.Show("You are blocked from our system");
                        Response.Redirect("Login.aspx");

                    }
                }
                else if (type.Value.ToString().Equals("stadium_manager"))
                    Response.Redirect("Stadium.aspx");
                else if (type.Value.ToString().Equals("representative"))
                    Response.Redirect("Representative.aspx");
                else if (type.Value.ToString().Equals("admin"))
                    Response.Redirect("Admin.aspx");
                else
                    Response.Redirect("Association.aspx");


            }
            else
            {
                MessageBox.Show("Credentials are incorrect");
                Response.Redirect("Login.aspx");
            }
            conn.Close();

        }
    }
}