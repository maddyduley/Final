using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class JobVIew : System.Web.UI.Page
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
                    String sqlQuery = "SELECT Jo.JobID, Jo.JobTitle, Com.Image, Jo.JobDescription,Jo.DateStart,Com.CompanyName from Job Jo,Contact Con, Company Com WHERE Com.CompanyID=Con.CompanyID AND Con.ContactID=Jo.ContactID AND Jo.JobStatus='Open'";
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
        protected void RefreshResults(object sender, EventArgs e)
        {
            try
            {
                String sqlQuery = "SELECT Jo.JobID, Jo.JobTitle,Com.Image, Jo.JobDescription,Jo.DateStart,Com.CompanyName from Job Jo,Contact Con, Company Com WHERE Com.CompanyID=Con.CompanyID AND Con.ContactID=Jo.ContactID AND Jo.JobStatus='Open' ORDER BY";
                sqlQuery += TypeList.SelectedValue;
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
        protected void NavigateClick(object sender, EventArgs e)
        {



            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["JobSelect"] = (row);

            String sqlQuery = "Select ViewCount From Job WHERE JobID=" + "'" + row + "'";
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
            String sqlQuerys = "UPDATE Job SET ViewCount = " + newInt + "WHERE JobID='" + row + "'";
            SqlCommand commands = new SqlCommand(sqlQuerys, sqlConnects);

            sqlConnects.Open();
            commands.ExecuteNonQuery();

            Response.Redirect("JobInvestigate.aspx");

        }


    }
}