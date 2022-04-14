using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class OppMemberSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people that are logged in to view the page
                if (Session["Username"] != null)
                {//only allow members to use the page
                    if (Session["Typed"].ToString() == "Leader")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Member")
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
        protected void ApplyJobs_Click(object sender, EventArgs e)
        {
            {
                string Date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQuery = "INSERT INTO OpportunityMember VALUES ('" + Date + "',@Desc," + Session["Member"].ToString() + "," + Session["OppSelect"].ToString() + ")";

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
            Response.Redirect("JobInvestigate.aspx");
        }
    }
}