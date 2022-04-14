using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class InternshipView : System.Web.UI.Page
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


                //try
                {
                    String sqlQuery = "SELECT Ints.InternshipID, Ints.InternshipTitle,Ints.InternshipDescription,Ints.DateStart,Ints.DateEnd,Com.CompanyName,Com.Image from Internship Ints,Contact Con, Company Com WHERE Com.CompanyID=Con.CompanyID AND Con.ContactID=Ints.ContactID AND Ints.Status='Open'";
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        IntView.DataSource = dtForGridView;
                        IntView.DataBind();
                    }
                }
                //catch
                {

                }
            }
        }
        protected void RefreshResults(object sender, EventArgs e)
        {
            //try
            {
                String sqlQuery = "SELECT Ints.InternshipID, Ints.InternshipTitle,Ints.InternshipDescription,Ints.DateStart,Ints.DateEnd,Com.CompanyName,Com.Image from Internship Ints,Contact Con, Company Com WHERE Com.CompanyID=Con.CompanyID AND Con.ContactID=Ints.ContactID AND Ints.Status='Open' ORDER BY ";
                sqlQuery += TypeList.SelectedValue;
                {
                    SqlConnection sqlConnect = new
                    SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                    DataTable dtForGridView = new DataTable();
                    sqlAdapter.Fill(dtForGridView);

                    IntView.DataSource = dtForGridView;
                    IntView.DataBind();
                }
            }
            //catch
            {

            }
        }
        protected void NavigateClick(object sender, EventArgs e)
        {



            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["InternSelect"] = (row);

            String sqlQuery = "Select ViewCount From Internship WHERE InternshipID=" + "'" + row + "'";
            //get the studentID by using the username of the Student that is logged in
            SqlConnection sqlConnect = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Session["IntCount"] = reader["ViewCount"].ToString();
            }
            sqlConnect.Close();

            int incount = (Convert.ToInt32(Session["IntCount"]));
            int newInt = incount += 1;
            SqlConnection sqlConnects = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuerys = "UPDATE Internship SET ViewCount = " + newInt + "WHERE InternshipID='" + row + "'";
            SqlCommand commands = new SqlCommand(sqlQuerys, sqlConnects);

            sqlConnects.Open();
            commands.ExecuteNonQuery();

            Response.Redirect("InternshipInvestigate.aspx");

        }
    }
}