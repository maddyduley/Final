using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class InternAnalytics : System.Web.UI.Page
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
                String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS StudentFullName FROM InternshipView Int, Student Stu, Internship Ind WHERE Int.StudentID=Stu.StudentID AND Ind.InternshipID=Int.InternshipID AND Int.LikeBttn = 'True' AND Ind.InternshipID=" + Session["InternSelect"].ToString();
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
                String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS StudentFullName FROM InternshipView Int, Student Stu, Internship Ind WHERE Int.StudentID=Stu.StudentID AND Ind.InternshipID=Int.InternshipID AND Int.Viewed = 'True' AND Ind.InternshipID=" + Session["InternSelect"].ToString();

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
                String sqlQuery = "SELECT ViewCount From Internship WHERE InternshipID=" + Session["InternSelect"].ToString();
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
                String sqlQuery = "SELECT COUNT(Viewed) as ViewCount From InternshipView WHERE Viewed ='True' AND InternshipID=" + Session["InternSelect"].ToString();
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
                String sqlQuery = "SELECT COUNT(LikeBttn) as LikeCount From InternshipView WHERE LikeBttn='True' AND InternshipID=" + Session["InternSelect"].ToString();
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
                String sqlQuery = "SELECT InternshipTitle from Internship WHERE InternshipID=" + Session["InternSelect"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["Name"] = reader["InternshipTitle"].ToString();

                }
                sqlConnected.Close();

                InternLabel.Text = Session["Name"].ToString();
            }

        }
    }
}