using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.EnterpriseServices.CompensatingResourceManager;

namespace Sports
{
    public partial class Representative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string representative = Session["user"].ToString();

            SqlCommand Club = new SqlCommand("select* from getClub(@representative_username)", conn);

            SqlCommand upcoming = new SqlCommand("select* from upcomingMatchesOfClub(@club)", conn);


            conn.Open();
            Club.Parameters.AddWithValue("@representative_username", representative);

           

            SqlDataAdapter da = new SqlDataAdapter(Club);


            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                string str2 = "ID: " + dt.Rows[0]["ID"] + "<br/> <br/>" + "Name: " + dt.Rows[0]["name"] +
                       "<br/> <br/>" + "Location: " + dt.Rows[0]["Location"] ;

                ClubInfo.Text = str2;
                ClubInfo.Font.Italic = true;
                ClubInfo.Font.Bold = true;



            }

            upcoming.Parameters.AddWithValue("@club", dt.Rows[0]["name"]);

            DataTable dt2 = new DataTable();

            SqlDataAdapter da2 = new SqlDataAdapter(upcoming);

            da2.Fill(dt2);

            string str = "";
            upcomingMatches.Text = str;

            if (dt2.Rows.Count > 0)
            {
                

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    str += dt2.Rows[i]["host"] + " " + dt2.Rows[i]["competitor"] 
                           + " " + dt2.Rows[i]["start_time"] + " " + dt2.Rows[i]["end_time"];


                    if (dt2.Rows[i]["stadium"] != null)
                    {
                        str += " " + dt2.Rows[i]["stadium"];
                    }
                    else
                        str += "<br/> <br/>";
                           

               
                }
                upcomingMatches.Text = str;
                upcomingMatches.Font.Italic = true;
                upcomingMatches.Font.Bold = true;



            }

            conn.Close();






        }

        protected void sendRequest(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string representative = Session["user"].ToString();

            SqlCommand addReq = new SqlCommand("addHostRequest", conn);
            addReq.CommandType = CommandType.StoredProcedure;
            addReq.Parameters.Add(new SqlParameter("@RepClubName", Host.Text));
            addReq.Parameters.Add(new SqlParameter("@StadiumName",Stadium.Text));
            addReq.Parameters.Add(new SqlParameter("@startingTime",StartTime.Text));

            SqlCommand checkR = new SqlCommand("checkReq", conn);
            checkR.CommandType = CommandType.StoredProcedure;
            checkR.Parameters.Add(new SqlParameter("@club", Host.Text));
            checkR.Parameters.Add(new SqlParameter("@stadium", Stadium.Text));
            checkR.Parameters.Add(new SqlParameter("@start", StartTime.Text));
            SqlParameter found = checkR.Parameters.Add("@found", SqlDbType.Int);
            found.Direction = ParameterDirection.Output;


            SqlCommand checkR1 = new SqlCommand("checkStadium", conn);
            checkR1.CommandType = CommandType.StoredProcedure;
            checkR1.Parameters.Add(new SqlParameter("@name", Stadium.Text));

            SqlParameter found2 = checkR1.Parameters.Add(new SqlParameter("@found", SqlDbType.Int));
            found2.Direction = ParameterDirection.Output;


            SqlCommand checkR2 = new SqlCommand("checkRep", conn);
            checkR2.CommandType = CommandType.StoredProcedure;
            checkR2.Parameters.Add(new SqlParameter("@club", Host.Text));
            checkR2.Parameters.Add(new SqlParameter("@username", representative));

            SqlParameter found3 = checkR2.Parameters.Add(new SqlParameter("@found", SqlDbType.Int));
            found3.Direction = ParameterDirection.Output;




            

            conn.Open();
            checkR2.ExecuteNonQuery();
            

            if (found3.Value.ToString().Equals("0"))
            {
                MessageBox.Show("You are not the representative of this club");
                Response.Redirect("Representative.aspx");
            }


            checkR1.ExecuteNonQuery();
            if (found2.Value.ToString().Equals("0"))
            {
                MessageBox.Show("Stadium with this name was not found");
                Response.Redirect("Representative.aspx");
            }

            checkR.ExecuteNonQuery();
            if (found.Value.ToString().Equals("0"))
            {
                addReq.ExecuteNonQuery();
                MessageBox.Show("Request is sent successfully");
               
            }
            else
            {
                MessageBox.Show("Request is already sent or you are trying to request hosting a match that is not on the system yet");
            }
            Host.Text = "";
            Stadium.Text = "";
            StartTime.Text = "";
            conn.Close();

        }


        protected void stadiums(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand AVstad = new SqlCommand("select * from viewAvailableStadiumsOn(@date)", conn);


            try
            {
                AVstad.Parameters.AddWithValue("@date", DateTime.Parse(DT.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid date");
                Response.Redirect("Representative.aspx");
            }


            SqlDataAdapter da = new SqlDataAdapter(AVstad);
            DataTable dt = new DataTable();

            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                string str = "";

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    str += i+1 + ") "+ dt.Rows[i]["stad_name"] + " " + dt.Rows[i]["location"] + " " + dt.Rows[i]["capacity"] + "<br/> <br/>";
                }

                available.Text = str;
                available.Font.Bold = true;
                available.Font.Italic = true;

            }




        }


    }
}