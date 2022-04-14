using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class ScholarshipView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {//only allow people that are logged in to use the page
                if (Session["Username"] != null)
                {//only allow students to use the page
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
            }


            if (!IsPostBack)
            {


                try
                {
                    String sqlQuery = "SELECT Sc.ScholarshipID, Sc.ScholarshipName,Sc.ScholarshipYear,Sc.ScholarshipAmount from Scholarship Sc WHERE Sc.Status='Open'";
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        ScholarView.DataSource = dtForGridView;
                        ScholarView.DataBind();
                    }
                }
                catch
                {


                }
            }
        }
        protected void RefreshResults(object sender, EventArgs e)
        {
            try
            {
                String sqlQuery = "SELECT Sc.ScholarshipID, Sc.ScholarshipName,Sc.ScholarshipYear,Sc.ScholarshipAmount from Scholarship Sc WHERE Sc.Status='Open' ORDER BY";
                sqlQuery += TypeList.SelectedValue;
                {
                    SqlConnection sqlConnect = new
                    SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dtForGridView = new DataTable();
                    sqlAdapter.Fill(dtForGridView);

                    ScholarView.DataSource = dtForGridView;
                    ScholarView.DataBind();
                }
            }
            catch
            {

            }
        }
        protected void NavigateClick(object sender, EventArgs e)
        {



            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["ScholarshipSelect"] = (row);

            String sqlQuery = "Select ViewCount From Scholarship WHERE ScholarshipID=" + "'" + row + "'";
            //get the studentID by using the username of the Student that is logged in
            SqlConnection sqlConnect = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Session["SchoCount"] = reader["ViewCount"].ToString();
            }
            sqlConnect.Close();

            int incount = (Convert.ToInt32(Session["SchoCount"]));
            int newInt = incount += 1;
            SqlConnection sqlConnects = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuerys = "UPDATE Scholarship SET ViewCount = " + newInt + "WHERE ScholarshipID='" + row + "'";
            SqlCommand commands = new SqlCommand(sqlQuerys, sqlConnects);

            sqlConnects.Open();
            commands.ExecuteNonQuery();

            Response.Redirect("ScholarshipInvestigate.aspx");

        }
    }
}