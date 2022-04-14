using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class OppStudentSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {//dont allow anyone that isn't signed in to view the page
                if (Session["Username"] != null)
                {//make sure the person is a student
                    if (Session["Typed"].ToString() == "Student")
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

                String sqlQuery = "Select StudentID, Files From Student WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                //get the studentID by using the username of the Student that is logged in
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                sqlConnect.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Session["Student"] = reader["StudentID"].ToString();
                }
                sqlConnect.Close();


            }

        }
        protected void ApplyJobs_Click(object sender, EventArgs e)
        {
            {
                string Date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQuery = "INSERT INTO OpportunityStudent VALUES ('" + Date + "',@Desc," + Session["Student"].ToString() + "," + Session["OppSelect"].ToString() + ")";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
                command.Parameters.AddWithValue("@Desc", HttpUtility.HtmlEncode(Description.Text.ToString()));
                try
                {
                    sqlConnect.Open();
                    command.ExecuteNonQuery();
                    Results.Text = ("Success");
                }
                catch (SqlException)
                {
                    Results.Text = ("Error Generated");
                }
                finally
                {
                    sqlConnect.Close();
                }

            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}