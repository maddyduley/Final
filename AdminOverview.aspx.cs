// File: AdminOverview.aspx.cs
// Author: Madisonsoft
// Date: 3/5/2022
// Purpose: Special window with extra options for members that are admins and not just regular members
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class AdminOverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // don't allow people that aren't signed in to view the page

            if (Session["Username"] != null)
            {//only allow members to view the page
                if (Session["Typed"].ToString() == "Admin")
                {

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

                {
                    try
                    {
                        String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS Student_Name FROM Member MEM, Mentor Men, Student Stu WHERE MEM.MemberID=MEN.MemberID AND Stu.StudentID=Men.StudentID AND MEM.MemberID=";
                        sqlQuery += Session["Member"];
                        {
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                            DataTable dtForGridView = new DataTable();
                            sqlAdapter.Fill(dtForGridView);

                            StudentGrid.DataSource = dtForGridView;
                            StudentGrid.DataBind();
                        }
                    }
                    catch
                    {

                    }
                }

            }
            else
            {
                Response.Redirect("homepage.aspx");
            }
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


        protected void Scholar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScholarMiddle.aspx");
        }

        protected void JobAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobMiddle.aspx");
        }

        protected void InternAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("InternMiddle.aspx");
        }

        protected void EditInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditInfo.aspx");
        }

        protected void StudentInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentInfo.aspx");
        }

        protected void Engagementbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Engagement.aspx");
        }

        protected void Opportunitiesbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OpportunitiesMiddle.aspx");
        }

        protected void Calandars_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }

        protected void Messages_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberInbox.aspx");
        }
    }
}