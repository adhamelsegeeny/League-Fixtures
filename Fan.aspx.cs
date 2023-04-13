using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Sports
{
    public partial class Fan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            //Response.Write(Session["users"]);

            



        }

        protected void Mat_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string dtt = Date.Text;
            SqlCommand availablematches = new SqlCommand("select* from availableMatchesToAttend(@date)", conn);
            //availablematches.CommandType = CommandType.Text;

            Label1.Text = "";
            conn.Open();
            availablematches.Parameters.AddWithValue("@date", dtt);
            SqlDataAdapter da = new SqlDataAdapter(availablematches);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            string str = "";

            if (DateTime.Parse(dtt) < DateTime.Now)
            {
                MessageBox.Show("Date should be at least today's date");
            }

            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += i + 1 + ") " + dt.Rows[i]["hostclubname"].ToString() + " " + dt.Rows[i]["guestclubname"] +
                        " " + dt.Rows[i]["startTime"] + " " + dt.Rows[i]["stadiumName"] + "<br/> <br/>";



                }

                if (str.Equals(""))
                {
                    Label1.Text = "No matches available staring from this date";
                }
                else
                {
                    Label1.Text = str;
                    {
                    }
                }
            }
            
            //Label1.Text = str;
            

            conn.Close();


        }
        protected void ticketPurchase(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string curr = Session["user"].ToString();
            

            SqlCommand nat = new SqlCommand("getNationalId", conn);
            nat.CommandType = CommandType.StoredProcedure;

            nat.Parameters.Add(new SqlParameter("@username", curr));

            SqlParameter natID = nat.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));

            natID.Direction = ParameterDirection.Output;

            string host = Host.Text;
            string guest = Guest.Text;
            string dt2 = StartTime.Text;
            


            conn.Open();
            nat.ExecuteNonQuery();
            

            SqlCommand purchase = new SqlCommand("purchaseTicket", conn);
            purchase.CommandType = CommandType.StoredProcedure;
            purchase.Parameters.Add(new SqlParameter("@national_id",natID.Value.ToString()));
            purchase.Parameters.Add(new SqlParameter("@host_name", host));
            purchase.Parameters.Add(new SqlParameter("@guest_name", guest));
            purchase.Parameters.Add(new SqlParameter("@date", dt2));

            SqlCommand check = new SqlCommand("checkMatch", conn);
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@host_name", host));
            check.Parameters.Add(new SqlParameter("@guest_name", guest));
            check.Parameters.Add(new SqlParameter("@date", dt2));

            SqlParameter found = check.Parameters.Add("@found", SqlDbType.Int);
            found.Direction = ParameterDirection.Output;

            check.ExecuteNonQuery();

            if (found.Value.ToString().Equals("0"))
            {
                MessageBox.Show("There is no match with these entries or the match may have been played already");
            }

            else
            {
                purchase.ExecuteNonQuery();
                MessageBox.Show("Ticket Purchased Successfully");
            }

            conn.Close();
            Host.Text = "";
            Guest.Text = "";
            StartTime.Text = "";



            //SqlCommand pt = new SqlCommand("purchaseTicket", conn);

            //conn.Close();


        }
    }
}