using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class EditOpportunity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//don't allow non users to use the page
                if (Session["Username"] != null)
                {// don't allow non members to adjust jobs
                    if (Session["Typed"].ToString() == "Leader")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
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
        }

        protected void bttnShowInfo_Click(object sender, EventArgs e)
        {
            {
                lblStatus.Text = "";
                String sqlFirst = "Select OpportunityTitle,OpportunityDesc,OppLocation,Date from Opportunities WHERE OpportunityID='" + OppList.SelectedValue + "'";
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    OppName.Text = reader["OpportunityTitle"].ToString();
                    OppDesc.Text = reader["OpportunityDesc"].ToString();
                    Location.Text = reader["OppLocation"].ToString();
                    OppDat.Text = reader["Date"].ToString();

                }
                sqlConnected.Close();
            }
            {

            }
        }

        protected void CreateEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateOpportunity.aspx");
        }


        protected void updateJob_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                {




                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sc;
                    cmd.CommandText = "UPDATE Opportunities SET OpportunityTitle=@Title,OpportunityDesc=@Desc,OppLocation=@Loc,Date=@Dat WHERE OpportunityID ='" + OppList.SelectedValue + "'";

                    cmd.Parameters.Add(new SqlParameter("@Title", HttpUtility.HtmlEncode(OppName.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Desc", HttpUtility.HtmlEncode(OppDesc.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Loc", HttpUtility.HtmlEncode(OppDat.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Dat", HttpUtility.HtmlEncode(Location.Text)));


                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();


                    lblStatus.Text = "Successful";
                }
            }
            catch
            {
                lblStatus.Text = "Error Occured";
            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}