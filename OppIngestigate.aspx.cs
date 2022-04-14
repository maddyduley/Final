using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class OppIngestigate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people that are logged in to use the page
                if (Session["Username"] != null)
                {//only allow students to use the page
                    if (Session["Typed"].ToString() == "Student")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Leader")
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



            String sqlQuery = "SELECT OpportunityID, OpportunityTitle, OpportunityDesc, OppLocation, Date FROM Opportunities WHERE Status = 'Open'";
            //get the studentID by using the username of the Student that is logged in
            SqlConnection sqlConnect = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                lblTitle.Text = reader["OpportunityTitle"].ToString();
                lblDDescrip.Text = reader["OpportunityDesc"].ToString();
                lblLocation.Text = reader["OppLocation"].ToString();
                lblDate.Text = reader["Date"].ToString();
            }
            sqlConnect.Close();



        }



        protected void Apply_Click(object sender, EventArgs e)
        {
            if (Session["Typed"].ToString() == "Student")
            {
                Response.Redirect("OppStudentSignup.aspx");
            }
            else if (Session["Typed"].ToString() == "Member")
            {
                Response.Redirect("OppMemberSignup.aspx");
            }
            else if (Session["Typed"].ToString() == "Admin")
            {
                Response.Redirect("OppMemberSignup.aspx");
            }
            else if (Session["Typed"].ToString() == "Leader")
            {
                Response.Redirect("OppMemberSignup.aspx");
            }
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}