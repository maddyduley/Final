using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class ScholarAnalytics : System.Web.UI.Page
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
                String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS StudentFullName FROM ScholarshipView Sc, Student Stu, Scholarship Sch WHERE Sc.StudentID=Stu.StudentID AND Sch.ScholarshipID=Sc.ScholarshipID AND Sc.LikeBttn = 'True' AND Sch.ScholarshipID=" + Session["ScholarshipSelect"].ToString();
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
                String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS StudentFullName FROM ScholarshipView Sc, Student Stu WHERE Sc.StudentID=Stu.StudentID AND Sc.Viewed = 'True' AND Sc.ScholarshipID=" + Session["ScholarshipSelect"].ToString();

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
                String sqlQuery = "SELECT ViewCount From Scholarship WHERE ScholarshipID=" + Session["ScholarshipSelect"].ToString();
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
                String sqlQuery = "SELECT COUNT(Viewed) as ViewCount From ScholarshipView WHERE Viewed ='True' AND ScholarshipID=" + Session["ScholarshipSelect"].ToString();
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
                String sqlQuery = "SELECT COUNT(LikeBttn) as LikeCount From ScholarshipView WHERE LikeBttn='True' AND ScholarshipID=" + Session["ScholarshipSelect"].ToString();
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
                String sqlQuery = "SELECT ScholarshipName from Scholarship WHERE ScholarshipID=" + Session["ScholarshipSelect"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["Name"] = reader["ScholarshipName"].ToString();

                }
                sqlConnected.Close();

                ScholarLable.Text = Session["Name"].ToString();
            }


        }
    }
}