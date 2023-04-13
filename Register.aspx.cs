using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Sports
{
    public partial class Register : System.Web.UI.Page
    {
       
           
       
        protected void Page_Load(object sender, EventArgs e)
        {
          



        }
        protected void register(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            

            string name = Name.Text;
            string user = Username.Text;
            string pass = Password.Text;

            conn.Open();

            if (address.Visible)
            {
                string id = nat_id.Text;
                string db = dob.Text;
                string add=address.Text;

                
                
                
                try
                {
                    string pn = Pnumber.Text;
                    SqlCommand addfan = new SqlCommand("addFan", conn);
                    addfan.CommandType = CommandType.StoredProcedure;

                    addfan.Parameters.Add(new SqlParameter("@username", user));
                    addfan.Parameters.Add(new SqlParameter("@password", pass));
                    addfan.Parameters.Add(new SqlParameter("@name", name));
                    addfan.Parameters.Add(new SqlParameter("@birth_date", db));
                    addfan.Parameters.Add(new SqlParameter("@national_id", id));
                    addfan.Parameters.Add(new SqlParameter("@address", add));
                    addfan.Parameters.Add(new SqlParameter("@phone", pn));

                    addfan.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Invalid Data...Please check again");
                    //Response.Redirect("Register.aspx");
                   
                }
                

                

            }
            else if (stad.Text!="")
            {

                string stadium= stad.Text;

                try
                {
                    SqlCommand addstadmanager = new SqlCommand("addStadiumManager", conn);
                    addstadmanager.CommandType = CommandType.StoredProcedure;

                    addstadmanager.Parameters.Add(new SqlParameter("@username", user));
                    addstadmanager.Parameters.Add(new SqlParameter("@password", pass));
                    addstadmanager.Parameters.Add(new SqlParameter("@name", name));
                    addstadmanager.Parameters.Add(new SqlParameter("@stadium_name", stadium));

                    SqlCommand check = new SqlCommand("checkStadium", conn);
                    check.CommandType = CommandType.StoredProcedure;
                    check.Parameters.Add(new SqlParameter("@name", stadium));

                    SqlParameter found = check.Parameters.Add("@found", SqlDbType.Int);

                    found.Direction = ParameterDirection.Output;

                    check.ExecuteNonQuery();

                    if (found.Value.ToString().Equals("1"))
                    {
                        addstadmanager.ExecuteNonQuery();
                        MessageBox.Show("Registration Successful");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Stadium Name");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Data...Please check again");
                    //Response.Redirect("Register.aspx");
                }


            }

            else if (clubb.Text!="")
            {
                
                string stad = clubb.Text;
                
                try
                {
                    SqlCommand addclubrep = new SqlCommand("addRepresentative", conn);
                    addclubrep.CommandType = CommandType.StoredProcedure;

                    addclubrep.Parameters.Add(new SqlParameter("@username", user));
                    addclubrep.Parameters.Add(new SqlParameter("@password", pass));
                    addclubrep.Parameters.Add(new SqlParameter("@name", name));
                    addclubrep.Parameters.Add(new SqlParameter("@club_name", stad));

                    SqlCommand check = new SqlCommand("checkClub", conn);
                    check.CommandType = CommandType.StoredProcedure;
                    check.Parameters.Add(new SqlParameter("@name", stad));

                    SqlParameter found = check.Parameters.Add("@found", SqlDbType.Int);

                    found.Direction = ParameterDirection.Output;

                    check.ExecuteNonQuery();

                    if (found.Value.ToString().Equals("1"))
                    {
                        addclubrep.ExecuteNonQuery();
                        MessageBox.Show("Registration Successful");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Club name");
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Data...Please check again");
                    //Response.Redirect("Register.aspx");
                }


            }

            else 
            {
                
                try
                {
                    SqlCommand addassoc = new SqlCommand("addAssociationManager", conn);
                    addassoc.CommandType = CommandType.StoredProcedure;

                    addassoc.Parameters.Add(new SqlParameter("@username", user));
                    addassoc.Parameters.Add(new SqlParameter("@password", pass));
                    addassoc.Parameters.Add(new SqlParameter("@name", name));


                    addassoc.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Data...Please check again");
                    //Response.Redirect("Register.aspx");
                }
            }
            conn.Close();
        }

        protected void club_CheckedChanged(object sender, EventArgs e)
        {
            dob.Visible = false;
            dobLabel.Visible = false;
            addLabel.Visible = false;
            address.Visible = false;
            csLabel.Visible = false;
            clubb.Visible = true;
            nat_id.Visible = false;
            id_label.Visible = false;
            phone.Visible = false;
            Pnumber.Visible= false;
            label.Visible = true;
            stad.Visible = false;

        }

        protected void stadium_CheckedChanged(object sender, EventArgs e)
        {
            dob.Visible = false;
            dobLabel.Visible = false;
            addLabel.Visible = false;
            address.Visible = false;
            csLabel.Visible = true;
            stad.Visible = true;
            nat_id.Visible = false;
            id_label.Visible = false;
            phone.Visible = false;
            Pnumber.Visible = false;
            label.Visible = false;
            clubb.Visible = false;

        }

        protected void fan_CheckedChanged(object sender, EventArgs e)
        {
            stad.Visible = false;
            clubb.Visible = false;
            csLabel.Visible = false;
            dob.Visible = true;
            dobLabel.Visible = true;
            addLabel.Visible = true;
            address.Visible = true;
            nat_id.Visible = true;
            id_label.Visible = true;
            phone.Visible = true;
            Pnumber.Visible = true;
            label.Visible = false;

        }

        protected void assoc_CheckedChanged(object sender, EventArgs e)
        {
            dob.Visible = false;
            dobLabel.Visible = false;
            addLabel.Visible = false;
            address.Visible = false;
            csLabel.Visible = false;
            clubb.Visible=false;
            stad.Visible = false;
            nat_id.Visible = false;
            id_label.Visible = false;
            phone.Visible = false;
            Pnumber.Visible = false;
            label.Visible = false;
            

        }
    }
}