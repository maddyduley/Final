using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class EditEvent : System.Web.UI.Page
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
                String sqlFirst = "Select EventTitle,EventDate,EventDescription,EventLocation from Event WHERE EventID='" + EventList.SelectedValue + "'";
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    EvenName.Text = reader["EventTitle"].ToString();
                    EvenDate.Text = reader["EventDate"].ToString();
                    EvenDesc.Text = reader["EventDescription"].ToString();
                    Location.Text = reader["EventLocation"].ToString();

                }
                sqlConnected.Close();
            }
            {

            }
        }

        protected void CreateJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateContact.aspx");
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
                    cmd.CommandText = "UPDATE Event SET EventTitle=@Title,EventDate=@Date,EventDescription=@Desc,EventLocation=@Loc WHERE EventID =" + EventList.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@Title", HttpUtility.HtmlEncode(EvenName.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Date", HttpUtility.HtmlEncode(EvenDate.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Desc", HttpUtility.HtmlEncode(EvenDesc.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Loc", HttpUtility.HtmlEncode(Location.Text)));

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

        protected void CreateEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEvent.aspx");
        }

        protected void DeleteEvent_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnectd = new
           SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            String sqlQuerysd = "Delete FROM Event WHERE EventID =" + EventList.SelectedValue;

            SqlCommand commandds = new SqlCommand(sqlQuerysd, sqlConnectd);
            sqlConnectd.Open();
            commandds.ExecuteNonQuery();
            sqlConnectd.Close();
        }
    }
}