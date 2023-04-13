using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Sports
{
    public partial class Stadium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string manager = Session["user"].ToString();

            SqlCommand stad = new SqlCommand("select* from getStadium(@manager_username)", conn);

            SqlCommand req = new SqlCommand("select* from allPendingRequests(@manager_username)", conn);

            SqlCommand accreq = new SqlCommand("select* from acceptedRequests(@manager_username)", conn);

            SqlCommand rejreq = new SqlCommand("select* from rejectedRequests(@manager_username)", conn);


            conn.Open();
            stad.Parameters.AddWithValue("@manager_username", manager);

            accreq.Parameters.AddWithValue("@manager_username", manager);
            req.Parameters.AddWithValue("@manager_username", manager);
            rejreq.Parameters.AddWithValue("@manager_username", manager);

            SqlDataAdapter da = new SqlDataAdapter(stad);


            DataTable dt = new DataTable();
            DataTable dt2= new DataTable(); 

            da.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                string str = "ID: " + dt2.Rows[0]["ID"] + "<br/> <br/>"   + "Name: " + dt2.Rows[0]["name"] +
                       "<br/> <br/>" + "Location: " + dt2.Rows[0]["Location"] + "<br/> <br/>" + "Capacity: " + dt2.Rows[0]["capacity"] + "<br/> <br/>" + "Availability: " +
                      dt2.Rows[0]["availability"];

                StadiumInfo.Text = str;
                StadiumInfo.Font.Italic = true;
                StadiumInfo.Font.Bold = true;
               
                

                
            }



            SqlDataAdapter da2 = new SqlDataAdapter(req);


            //DataTable dt2 = new DataTable();

            da2.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Req.Text = i + 1 + ")" + "Representative: " + dt.Rows[i]["representative"] +
                    " " + "Host: " + dt.Rows[i]["host"] +
                    " " + "Guest: " + dt.Rows[i]["guest"] + " " +
                    "Start Time: " + dt.Rows[i]["start_time"] +
                    " " + "End time: " + dt.Rows[i]["end_time"] +
                    "<br/> <br/>";

                    
                   

                }
                Req.Font.Italic = true;
                dt.Clear();
            }

            SqlDataAdapter da3 = new SqlDataAdapter(accreq);


            //DataTable dt = new DataTable();

            da3.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Accepted.Text = i + 1 + ")" + "Representative: " + dt.Rows[i]["representative"] +
                    " " + "Host: " + dt.Rows[i]["host"] +
                    " " + "Guest: " + dt.Rows[i]["guest"] + " " +
                    "Start Time: " + dt.Rows[i]["start_time"] +
                    " " + "End time: " + dt.Rows[i]["end_time"] +
                    "<br/> <br/>";


                }
                Accepted.Font.Italic = true;
                dt.Clear();
            }

            SqlDataAdapter da4 = new SqlDataAdapter(rejreq);


            //DataTable dt = new DataTable();

            da4.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    reject.Text = i + 1 + ")" + "Representative: " + dt.Rows[i]["representative"] +
                    " " + "Host: " + dt.Rows[i]["host"] +
                    " " + "Guest: " + dt.Rows[i]["guest"] + " " +
                    "Start Time: " + dt.Rows[i]["start_time"] +
                    " " + "End time: " + dt.Rows[i]["end_time"] +
                    "<br/> <br/>";


                }
                reject.Font.Italic = true;
            }

            conn.Close();



        }

        protected void Accept(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string manager = Session["user"].ToString();

            SqlCommand acc = new SqlCommand("acceptRequest", conn);
            acc.CommandType = CommandType.StoredProcedure;

            acc.Parameters.Add(new SqlParameter("@stadium_manager_username", manager));
            acc.Parameters.Add(new SqlParameter("@host", Host.Text));
            acc.Parameters.Add(new SqlParameter("@guest", Guest.Text));
            acc.Parameters.Add(new SqlParameter("@start", StartTime.Text));


            SqlCommand check = new SqlCommand("accRej", conn);
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@stadium_manager", manager));
            check.Parameters.Add(new SqlParameter("@host", Host.Text));
            check.Parameters.Add(new SqlParameter("@guest", Guest.Text));
            check.Parameters.Add(new SqlParameter("@start", StartTime.Text));

            SqlParameter status = check.Parameters.Add("@status", SqlDbType.VarChar,20);
            status.Direction = ParameterDirection.Output;

            conn.Open();
            check.ExecuteNonQuery();

            if (status.Value.ToString().Equals("unhandled"))
            {
                
                acc.ExecuteNonQuery();
                MessageBox.Show("Request Accepted Successfully");


            }
            else if (status.Value.ToString().Equals("accepted"))
            {
                MessageBox.Show("Request already accepted");
            }
            else if (status.Value.ToString().Equals("rejected"))
            {
                MessageBox.Show("Request already rejected");
            }
            else
            {
                MessageBox.Show("Request not found");
            }

            conn.Close();
            Host.Text = "";
            Guest.Text = "";
            StartTime.Text = "";




        }

        protected void Reject(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string manager = Session["user"].ToString();

            SqlCommand acc = new SqlCommand("rejectRequest", conn);
            acc.CommandType = CommandType.StoredProcedure;

            acc.Parameters.Add(new SqlParameter("@stadium_manager_username", manager));
            acc.Parameters.Add(new SqlParameter("@host", Host.Text));
            acc.Parameters.Add(new SqlParameter("@guest", Guest.Text));
            acc.Parameters.Add(new SqlParameter("@start", StartTime.Text));


            SqlCommand check = new SqlCommand("accRej", conn);
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@stadium_manager_username", manager));
            check.Parameters.Add(new SqlParameter("@host", Host.Text));
            check.Parameters.Add(new SqlParameter("@guest", Guest.Text));
            check.Parameters.Add(new SqlParameter("@start", StartTime.Text));

            SqlParameter status = check.Parameters.Add("@status", SqlDbType.VarChar, 20);
            status.Direction = ParameterDirection.Output;

            conn.Open();
            check.ExecuteNonQuery();

            if (status.Value.ToString().Equals("unhandled"))
            {

                acc.ExecuteNonQuery();
                MessageBox.Show("Request Rejected Successfully");


            }
            else if (status.Value.ToString().Equals("accepted"))
            {
                MessageBox.Show("Request already accepted");
            }
            else if (status.Value.ToString().Equals("rejected"))
            {
                MessageBox.Show("Request already rejected");
            }
            else if (status.Value.ToString().Equals("played"))
            {
                MessageBox.Show("This Match is already played");
            }
            else
            {
                MessageBox.Show("Request not found");
            }

            conn.Close();
            Host.Text = "";
            Guest.Text = "";
            StartTime.Text = "";


        }
    }
}