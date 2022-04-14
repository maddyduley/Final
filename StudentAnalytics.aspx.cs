using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class StudentAnalytics : System.Web.UI.Page
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


            if (!IsPostBack)
            {

                {
                    try
                    {
                        String sqlQuery = "SELECT Jo.JobID, Jo.JobTitle, Com.CompanyName from Job Jo,Contact Con, Company Com WHERE Com.CompanyID=Con.CompanyID AND Con.ContactID=Jo.ContactID";
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
                {
                    try
                    {
                        String sqlQuery = "SELECT Int.InternshipID, Int.InternshipTitle,Com.CompanyName from Internship Int,Contact Con, Company Com WHERE Com.CompanyID=Con.CompanyID AND Con.ContactID=Int.ContactID";
                        {
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                            DataTable dtForGridView = new DataTable();
                            sqlAdapter.Fill(dtForGridView);

                            InternshipView.DataSource = dtForGridView;
                            InternshipView.DataBind();
                        }
                    }
                    catch
                    {

                    }
                }
                {
                    try
                    {
                        String sqlQuery = "SELECT ScholarshipID, ScholarshipName, ScholarshipYear from Scholarship";
                        {
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                            DataTable dtForGridView = new DataTable();
                            sqlAdapter.Fill(dtForGridView);

                            ScholarshipView.DataSource = dtForGridView;
                            ScholarshipView.DataBind();
                        }
                    }
                    catch
                    {

                    }
                }
                {
                    try
                    {
                        String sqlQuery = "SELECT OpportunityID, OpportunityTitle, Date from Opportunities";
                        {
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                            DataTable dtForGridView = new DataTable();
                            sqlAdapter.Fill(dtForGridView);

                            OppGrid.DataSource = dtForGridView;
                            OppGrid.DataBind();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        protected void NavigateJob(object sender, EventArgs e)
        {



            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["JobSelect"] = (row);


            Response.Redirect("JobAnalytics.aspx");

        }
        protected void NavigateIntern(object sender, EventArgs e)
        {



            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["InternSelect"] = (row);


            Response.Redirect("InternAnalytics.aspx");

        }
        protected void NavigateScholar(object sender, EventArgs e)
        {



            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["ScholarshipSelect"] = (row);


            Response.Redirect("ScholarAnalytics.aspx");

        }

        protected void OppNav_Click(object sender, EventArgs e)
        {

            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["OppSelect"] = (row);


            Response.Redirect("OpportunityAnalytics.aspx");
        }
    }
}