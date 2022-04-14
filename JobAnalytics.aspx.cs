using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class JobAnalytics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {//only allow people that are logged in to use the page
                if (Session["Username"] != null)
                {//only allow students to use the page
                    if (Session["Typed"].ToString() == "Member")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Leader")
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


            {
                String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS StudentFullName FROM Jobview J, Student Stu, Job Jo WHERE J.StudentID=Stu.StudentID AND Jo.JobID=J.JobID AND J.LikeBttn = 'True' AND Jo.JobID=" + Session["JobSelect"].ToString();
                {
                    SqlConnection sqlConnect = new
                    SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dtForGridView = new DataTable();
                    sqlAdapter.Fill(dtForGridView);

                    DropLiked.DataSource = dtForGridView;
                    DropLiked.DataBind();
                }
            }
            {
                String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS StudentFullName FROM Jobview J, Student Stu, Job Jo WHERE J.StudentID=Stu.StudentID AND Jo.JobID=J.JobID AND J.Viewed = 'True' AND Jo.JobID=" + Session["JobSelect"].ToString();

                {
                    SqlConnection sqlConnect = new
                    SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dtForGridView = new DataTable();
                    sqlAdapter.Fill(dtForGridView);

                    DropViews.DataSource = dtForGridView;
                    DropViews.DataBind();
                }
            }
            {
                String sqlQuery = "SELECT ViewCount From Job WHERE JobID=" + Session["JobSelect"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["TotalCount"] = reader["ViewCount"].ToString();

                }
                sqlConnected.Close();

                ScholarCount.Text = Session["TotalCount"].ToString();
            }


            {
                String sqlQuery = "SELECT COUNT(Viewed) as ViewCount From JobView WHERE Viewed ='True' AND JobID=" + Session["JobSelect"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    int myint = reader.GetInt32(0);
                    IndividualViewCount.Text = myint.ToString();

                }
                sqlConnected.Close();

            }

            {
                String sqlQuery = "SELECT COUNT(LikeBttn) as LikeCount From JobView WHERE LikeBttn='True' AND JobID=" + Session["JobSelect"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    int myint = reader.GetInt32(0);
                    LikeCounter.Text = myint.ToString();

                }
                sqlConnected.Close();
            }

            {
                String sqlQuery = "SELECT JobTitle from Job WHERE JobID=" + Session["JobSelect"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["Name"] = reader["JobTitle"].ToString();

                }
                sqlConnected.Close();

                JobLable.Text = Session["Name"].ToString();
            }

        }
    }
}