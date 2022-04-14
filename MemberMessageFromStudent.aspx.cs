using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class MemberMessageFromStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {//only allow people that are logged in to use the page
                if (Session["Username"] != null)
                {//only allow students to use the page
                    if (Session["Typed"].ToString() == "Admin")
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
                String sqlQuery = "SELECT Header from MessagesStudToMem Where MessageID=" + Session["Message"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Headerlbl.Text = reader["Header"].ToString();

                }
                sqlConnected.Close();



            }

            {
                String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS Sender from MessagesStudToMem Men, Student Stu Where Men.StudentID=Stu.StudentID AND MessageID=" + Session["Message"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Senderlbl.Text = reader["Sender"].ToString();

                }
                sqlConnected.Close();



            }
            {
                String sqlQuery = "SELECT DateSent from MessagesStudToMem Where MessageID=" + Session["Message"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Datelbl.Text = reader["DateSent"].ToString();

                }
                sqlConnected.Close();



            }
            {
                String sqlQuery = "SELECT Information from MessagesStudToMem Where MessageID=" + Session["Message"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Infolbl.Text = reader["Information"].ToString();

                }
                sqlConnected.Close();



            }
        }


        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection sqlConnectd = new
               SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQuerysd = "Delete FROM MessagesStudToMem WHERE MessageID =" + Session["Message"].ToString();

                SqlCommand commandds = new SqlCommand(sqlQuerysd, sqlConnectd);
                sqlConnectd.Open();
                commandds.ExecuteNonQuery();
                sqlConnectd.Close();
                Response.Redirect("MemberInbox.aspx");
            }
            catch
            {

            }
        }

    }
}