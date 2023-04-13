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

namespace Sports
{
    public partial class Association : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from clubsNeverMatched", conn);
            String selectQuery = "select * from clubsNeverMatched";
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dataGridView1.DataSource = table;
            conn.Close();
            string str = "";

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                str += i + 1 + ")" + dt.Rows[i]["First_Club"] + "  " + dt.Rows[i]["Second_Club"] + "<br> <br>";

            }

            never.Text = str;
            never.Font.Italic = true;
            never.Font.Bold = true;

        }

        protected void addm_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);


            if (addm.Text.Equals("Add Match"))
            {
                SqlCommand addMatch = new SqlCommand("addNewMatch", conn);
                addMatch.CommandType = CommandType.StoredProcedure;
                addMatch.Parameters.Add(new SqlParameter("@host", host.Text));
                addMatch.Parameters.Add(new SqlParameter("@guest", guest.Text));
                try
                {
                    addMatch.Parameters.Add(new SqlParameter("@start", DateTime.Parse(start.Text)));
                    addMatch.Parameters.Add(new SqlParameter("@end", DateTime.Parse(end.Text)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter a valid date");
                    Response.Redirect("Association.aspx");
                }


                SqlCommand check = new SqlCommand("checkClubs", conn);
                check.CommandType = CommandType.StoredProcedure;
                check.Parameters.Add(new SqlParameter("@host", host.Text));
                check.Parameters.Add(new SqlParameter("@guest", guest.Text));

                SqlParameter found = check.Parameters.Add("@found", SqlDbType.Int);
                found.Direction = ParameterDirection.Output;

                conn.Open();
                check.ExecuteNonQuery();

                if (found.Value.ToString().Equals("1"))
                {
                    try
                    {
                        addMatch.ExecuteNonQuery();
                        MessageBox.Show("Match Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                 
                }
                else
                {
                    MessageBox.Show("One or both of the clubs are not registered");
                    
                }
                conn.Close();

                
            }

            else
            {
                SqlCommand deleteMatch = new SqlCommand("deleteMatch", conn);
                deleteMatch.CommandType = CommandType.StoredProcedure;
                deleteMatch.Parameters.Add(new SqlParameter("@host", host.Text));
                deleteMatch.Parameters.Add(new SqlParameter("@guest", guest.Text));
                deleteMatch.Parameters.Add(new SqlParameter("@start", DateTime.Parse(start.Text)));
                deleteMatch.Parameters.Add(new SqlParameter("@end", DateTime.Parse(end.Text)));

                SqlCommand check = new SqlCommand("checkClubs", conn);
                check.CommandType = CommandType.StoredProcedure;
                check.Parameters.Add(new SqlParameter("@host", host.Text));
                check.Parameters.Add(new SqlParameter("@guest", guest.Text));

                SqlParameter found = check.Parameters.Add("@found", SqlDbType.Int);
                found.Direction = ParameterDirection.Output;

                conn.Open();
                check.ExecuteNonQuery();

                if (found.Value.ToString().Equals("1"))
                {
                    try
                    {
                        deleteMatch.ExecuteNonQuery();
                        MessageBox.Show("Match Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Data");
                    }
                 
                }
                else
                {
                    MessageBox.Show("One or both of the clubs are not registered");
                }
                conn.Close();

            }
            

        }

        protected void check_Click(object sender, EventArgs e)
        {
            if(addm.Text.Equals("Add Match"))
            {
                addm.Text = "Delete Match";
            }
            else
            {
                addm.Text = "Add Match";
            }
        }

        protected void matches_Click(object sender, EventArgs e)
        {

            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            conn.Open();
            //SqlCommand cmd = new SqlCommand("Select * from matchesPlayed", conn);
            String selectQuery = "select * from matchesPlayed";

            //SqlCommand cmd2 = new SqlCommand("Select * from allUpcomingMatches", conn);
            String selectQuery2 = "Select * from allUpcomingMatches";

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            string str = "Host  Guest  Start  End <br/> <br/>";

            //dataGridView1.DataSource = table;
            conn.Close();


            if (matches.Text.Equals("View Already Played"))
            {


                da = new SqlDataAdapter(selectQuery, conn);
                da.Fill(dt);
                matches.Text = "View All Upcoming Matches";
            }


            else
            {
                da = new SqlDataAdapter(selectQuery2, conn);
                da.Fill(dt);
                matches.Text = "View Already Played";

            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += i + 1 + ") " + dt.Rows[i]["host_club"] + "  " + dt.Rows[i]["guest_club"]+"  "
                    + dt.Rows[i]["start_time"] + "  " + dt.Rows[i]["end_time"]
                    + "<br/> <br/>";

            }
            label.Text = str;
        }
    }
}