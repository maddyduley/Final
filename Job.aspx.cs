// File: Job.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Allow members to be able to add and adjust jobs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class Job : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//don't allow non users to use the page
                if (Session["Username"] != null)
                {// don't allow non members to adjust jobs
                    if (Session["Typed"].ToString() == "Leader")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
                    {

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
            }
        }

        protected void bttnShowInfo_Click(object sender, EventArgs e)
        {
            {
                String sqlFirst = "Select JobTitle,JobDescription,DateStart from Job WHERE JobID='" + JobList.SelectedValue + "'";
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    JobTitlebox.Text = reader["JobTitle"].ToString();
                    DescriptionBox.Text = reader["JobDescription"].ToString();
                    DateStart.Text = reader["DateStart"].ToString();

                }
                sqlConnected.Close();
            }
            {
                lblStatus.Text = "";
            }
        }

        protected void CreateJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateJob.aspx");
        }


        protected void updateJob_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                {




                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sc;
                    cmd.CommandText = "UPDATE Job SET JobTitle=@Title,JobDescription=@Desc,DateStart=@Dat WHERE JobID ='" + JobList.SelectedValue + "'";

                    cmd.Parameters.Add(new SqlParameter("@Title", HttpUtility.HtmlEncode(JobTitlebox.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Desc", HttpUtility.HtmlEncode(DescriptionBox.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Dat", HttpUtility.HtmlEncode(DateStart.Text)));


                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();


                    lblStatus.Text = "Successful";
                }
            }
            catch
            {
                lblStatus.Text = "Error Occured";
            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}