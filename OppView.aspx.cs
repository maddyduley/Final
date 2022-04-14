using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class OppView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {//only allow people that are logged in to use the page
                if (Session["Username"] != null)
                {//only allow students to use the page
                    if (Session["Typed"].ToString() == "Student")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Member")
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


            if (!IsPostBack)
            {


                try
                {
                    String sqlQuery = "SELECT OpportunityID,OpportunityTitle FROM Opportunities WHERE Status='Open'";
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        JobView.DataSource = dtForGridView;
                        JobView.DataBind();
                    }
                }
                catch
                {

                }
            }
        }
        protected void NavigateClick(object sender, EventArgs e)
        {



            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["OppSelect"] = (row);

            String sqlQuery = "Select ViewCount From Opportunities WHERE OpportunityID=" + "'" + row + "'";
            //get the studentID by using the username of the Student that is logged in
            SqlConnection sqlConnect = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Session["Count"] = reader["ViewCount"].ToString();
            }
            sqlConnect.Close();

            int incount = (Convert.ToInt32(Session["Count"]));
            int newInt = incount += 1;
            SqlConnection sqlConnects = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuerys = "UPDATE Opportunities SET ViewCount = " + newInt + "WHERE OpportunityID='" + row + "'";
            SqlCommand commands = new SqlCommand(sqlQuerys, sqlConnects);

            sqlConnects.Open();
            commands.ExecuteNonQuery();




            Response.Redirect("OppIngestigate.aspx");

        }

    }
}