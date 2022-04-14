using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class OpportunityAnalytics : System.Web.UI.Page
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
                String sqlQuery = "SELECT ViewCount From Opportunities WHERE OpportunityID=" + Session["OppSelect"].ToString();
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
                String sqlQuery = "SELECT OpportunityID, OpportunityTitle from Opportunities WHERE OpportunityID=" + Session["OppSelect"].ToString();
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlQuery, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    Session["Name"] = reader["OpportunityTitle"].ToString();

                }
                sqlConnected.Close();

                JobLable.Text = Session["Name"].ToString();
            }
            {
                String sqlQuery = "SELECT Stu.FirstName+' '+Stu.LastName AS StudentFullName FROM OpportunityStudent Opp, Student Stu WHERE Opp.StudentID=Stu.StudentID AND Opp.OpportunityID=" + Session["OppSelect"].ToString();
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
            {
                String sqlQuery = "SELECT Mem.FirstName+' '+Mem.LastName AS MemberFullName FROM OpportunityMember Opp, Member Mem WHERE Opp.MemberID=Mem.MemberID AND Opp.OpportunityID=" + Session["OppSelect"].ToString();
                {
                    SqlConnection sqlConnect = new
                    SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dtForGridView = new DataTable();
                    sqlAdapter.Fill(dtForGridView);

                    MemberGrid.DataSource = dtForGridView;
                    MemberGrid.DataBind();
                }
            }



        }

        protected void CloseOpp_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnectd = new
                    SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuerysd = "Update Opportunities Set Status='Closed' WHERE OpportunityID =" + Session["OppSelect"].ToString();

            SqlCommand commandds = new SqlCommand(sqlQuerysd, sqlConnectd);
            sqlConnectd.Open();
            commandds.ExecuteNonQuery();
            sqlConnectd.Close();
        }
    }
}