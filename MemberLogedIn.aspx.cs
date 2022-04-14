// File: MemberLogedIn.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow the member to adjust their own info and get to other features
using System;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace Lab3
{
    public partial class MemberLogedIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            // don't allow people that aren't signed in to view the page

            if (Session["Username"] != null)
            {//only allow members to view the page
                if (Session["Typed"].ToString() == "Member")
                {

                }
                else if (Session["Typed"].ToString() == "Admin")
                {
                    Response.Redirect("AdminOverview.aspx");
                }
                else if (Session["Typed"].ToString() == "Leader")
                {
                    Response.Redirect("LeaderLogedIn.aspx");
                }
                else
                {
                    Response.Redirect("homepage.aspx");
                }
            }
            else
            {
                Response.Redirect("homepage.aspx");
            }
            {
                String sqlQuery = "Select MemberID From Member WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                //get the studentID by using the username of the Student that is logged in
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                sqlConnect.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Session["Member"] = reader["MemberID"].ToString();
                }
                sqlConnect.Close();

            }




        }

        protected void Analytics_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentAnalytics.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSearch.aspx");
        }

        protected void MemberOverview_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberOverview.aspx");
        }
        protected void Image_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImageUpload.aspx");
        }

        protected void SignupOpp_Click(object sender, EventArgs e)
        {
            Response.Redirect("OppView.aspx");
        }

        protected void EditMemberUser_Click(object sender, EventArgs e)
        {
            {
                String sqlFirst = "Select FirstName,LastName,Email,PhoneNumber,GradYear,Title,EmailStat From Member WHERE UserName='" + Session["Username"].ToString() + "'";
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["First"] = reader["FirstName"].ToString();
                    Session["Lasts"] = reader["LastName"].ToString();
                    Session["email"] = reader["Email"].ToString();
                    Session["Phone"] = reader["PhoneNumber"].ToString();
                    Session["Grad"] = reader["GradYear"].ToString();
                    Session["TITLE"] = reader["Title"].ToString();
                    Session["Status"] = reader["EmailStat"].ToString();

                }
                sqlConnected.Close();
                Response.Redirect("UserMemberEdit.aspx");
            }
        }

        protected void Calandar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }
    }
}