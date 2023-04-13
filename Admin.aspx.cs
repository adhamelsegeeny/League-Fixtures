using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Services.Description;
using System.Windows;
using System.Windows.Documents;

namespace Sports
{
    public partial class Admin : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //add/delete club
        protected void addClub(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkC = new SqlCommand("checkClub", conn);
            checkC.CommandType = CommandType.StoredProcedure;

            checkC.Parameters.Add(new SqlParameter("@name", club_name.Text));

            SqlParameter success = checkC.Parameters.Add("found", SqlDbType.Int);

            success.Direction = ParameterDirection.Output;

            conn.Open();

            checkC.ExecuteNonQuery();

            if (addc.Text.Equals("Add Club"))
            {

                SqlCommand acc = new SqlCommand("addClub", conn);
                acc.CommandType = CommandType.StoredProcedure;

                acc.Parameters.Add(new SqlParameter("@name", club_name.Text));
                acc.Parameters.Add(new SqlParameter("@location", location.Text));





                if (location.Text.Equals("") 
                || club_name.Text.Equals(""))

                {
                    MessageBox.Show("Enter data correctly");
                    
                }


                else if (success.Value.ToString().Equals("1"))
                {
                    MessageBox.Show("Try a different club name");
                    
                }

                else
                {

                    acc.ExecuteNonQuery();
                    MessageBox.Show("Club was added successfully");
                    

                    conn.Close();



                }
                conn.Close();
            }
            else
            {

                SqlCommand acc = new SqlCommand("deleteClub", conn);
                acc.CommandType = CommandType.StoredProcedure;

                acc.Parameters.Add(new SqlParameter("@name", club_name.Text));


                if (success.Value.ToString().Equals("1"))
                {
                    acc.ExecuteNonQuery();
                    MessageBox.Show("Club was deleted successfully");
                    
                }
                else
                {
                    MessageBox.Show("Club with than name was not found");
                    
                }
                conn.Close();
            }


        }

        //toggle club
        protected void check_CheckedChanged(object sender, EventArgs e)
        {
            if (addc.Text.Equals("Delete Club"))
            {
                location.Visible = true;
                addc.Text = "Add Club";
            }
            else
            {
                location.Visible = false;
                addc.Text = "Delete Club";
            }




        }

        //toggle stadium
        protected void toggle_Click(object sender, EventArgs e)
        {
            if (adds.Text.Equals("Delete Stadium"))
            {
                stad_location.Visible = true;
                cap.Visible = true;
                adds.Text = "Add Stadium";
            }
            else
            {
                stad_location.Visible = false;
                cap.Visible = false;
                adds.Text = "Delete Stadium";
            }
        }



        //add/delete stadium
        protected void adds_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkC = new SqlCommand("checkStadium", conn);
            checkC.CommandType = CommandType.StoredProcedure;

            checkC.Parameters.Add(new SqlParameter("@name", stadium_name.Text));

            SqlParameter success = checkC.Parameters.Add("found", SqlDbType.Int);

            success.Direction = ParameterDirection.Output;

            conn.Open();

            checkC.ExecuteNonQuery();

            if (adds.Text.Equals("Add Stadium"))
            {

                SqlCommand acc = new SqlCommand("addStadium", conn);
                acc.CommandType = CommandType.StoredProcedure;
                int capa = 0;

                try
                {
                    capa = Int16.Parse(cap.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Enter data correctly");
                    Response.Redirect("Admin.aspx");
                }


                acc.Parameters.Add(new SqlParameter("@StadiumName", stadium_name.Text));
                acc.Parameters.Add(new SqlParameter("@location", stad_location.Text));
                acc.Parameters.Add(new SqlParameter("@capacity", capa));

                if (stad_location.Text.Equals("") || club_name.Text.Equals("") || cap.Text.Equals("") )

                {
                    MessageBox.Show("Enter data correctly");
                    
                }


                else if (success.Value.ToString().Equals("1"))
                {
                    MessageBox.Show("Try a different stadium name");
                   
                }
                 
                else
                {

                    acc.ExecuteNonQuery();
                    MessageBox.Show("Stadium was added successfully");
                    

                    conn.Close();



                }
                conn.Close();
            }
            else
            {

                SqlCommand acc = new SqlCommand("deleteStadium", conn);
                acc.CommandType = CommandType.StoredProcedure;

                acc.Parameters.Add(new SqlParameter("@Stadium", stadium_name.Text));


                if (success.Value.ToString().Equals("1"))
                {
                    acc.ExecuteNonQuery();
                    MessageBox.Show("Stadium was deleted successfully");
                    
                }
                else
                {
                    MessageBox.Show("Stadium with than name was not found");
                   
                }
                conn.Close();
            }


        }

        protected void block_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand blck = new SqlCommand("blockFan", conn);
            blck.CommandType = CommandType.StoredProcedure;

            blck.Parameters.Add(new SqlParameter("@national_id", nat_id.Text));

            SqlCommand check = new SqlCommand("checkBlock", conn);
            check.CommandType = CommandType.StoredProcedure;

            check.Parameters.Add(new SqlParameter("id", nat_id.Text));

            SqlParameter found = check.Parameters.Add("found", SqlDbType.Int);
            found.Direction = ParameterDirection.Output;



            conn.Open();
            check.ExecuteNonQuery();

            if (found.Value.ToString().Equals("0"))
            {
                MessageBox.Show("Fan with this national id was not found");
                
            }
            else
            {
                blck.ExecuteNonQuery();
                MessageBox.Show("Fan was blocked successfully");
                
            }

            conn.Close();

        }

        protected void unblock_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand unblck = new SqlCommand("unblockFan", conn);

            unblck.Parameters.Add(new SqlParameter("@national_id", nat_id.Text));
            unblck.CommandType = CommandType.StoredProcedure;

            SqlCommand check = new SqlCommand("checkBlock", conn);
            check.CommandType = CommandType.StoredProcedure;

            check.Parameters.Add(new SqlParameter("id", nat_id.Text));

            SqlParameter found = check.Parameters.Add("found", SqlDbType.Int);
            found.Direction = ParameterDirection.Output;



            conn.Open();
            check.ExecuteNonQuery();

            if (found.Value.ToString().Equals("0"))
            {
                MessageBox.Show("Fan with this national id was not found");
                
            }

            else
            {
                unblck.ExecuteNonQuery();
                MessageBox.Show("Fan was unblocked successfully");

            }

            conn.Close();



        }



    }
}
