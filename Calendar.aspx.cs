using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                
                if (Session["Username"] != null)
                {//if the student is already signed in, take them to the logged in page
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
            {
                {
                    string CurrentDate = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
                    String sqlQuery = "Select EventID,EventTitle,EventDescription,EventDate,EventLocation from Event Where EventDate>='"+ CurrentDate+ "' Order by EventDate ASC";
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        GridView1.DataSource = dtForGridView;
                        GridView1.DataBind();
                    }
                }

                {


                    string CurrentDate = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
                    String sqlQuery = "Select OpportunityID,OpportunityTitle,OpportunityDesc,OppLocation,Date FROM Opportunities where Date>='"+ CurrentDate+ "' Order by Date ASC";
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        GridView2.DataSource = dtForGridView;
                        GridView2.DataBind();
                    }



                }








            }




        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                String full = Calendar1.SelectedDate.ToString();
                string[] dateset = full.Split(' ');
                string date = dateset[0].ToString();

                {

                    String sqlQuery = "Select EventID,EventTitle,EventDescription,EventDate,EventLocation from Event WHERE EventDate='" + date + "'";
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        GridView1.DataSource = dtForGridView;
                        GridView1.DataBind();
                    }
                }

            }
            catch
            {
                EventLabel.Text = "No Events Scheduled";
            }
            try
            {
                String full = Calendar1.SelectedDate.ToString();
                string[] dateset = full.Split(' ');
                string date = dateset[0].ToString();

                {



                    String sqlQuery = "Select OpportunityID,OpportunityTitle,OpportunityDesc,OppLocation,Date FROM Opportunities WHERE Date='" + date + "'";
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                        DataTable dtForGridView = new DataTable();
                        sqlAdapter.Fill(dtForGridView);

                        GridView2.DataSource = dtForGridView;
                        GridView2.DataBind();
                    }



                }
            }
            catch
            {
                OpportunityLabel.Text = "No Opportunities Scheduled";
            }
        }
    }
}