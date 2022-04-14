using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class ContactEdit : System.Web.UI.Page
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
                String sqlFirst = "Select ContactName,ContactPhone,ContactEmail from Contact WHERE ContactID='" + ContactList.SelectedValue + "'";
                SqlConnection sqlConnected = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommandFirst = new SqlCommand(sqlFirst, sqlConnected);
                sqlConnected.Open();
                SqlDataReader reader = sqlCommandFirst.ExecuteReader();
                while (reader.Read())
                {
                    ContactName.Text = reader["ContactName"].ToString();
                    ContactPhone.Text = reader["ContactPhone"].ToString();
                    ContactEmail.Text = reader["ContactEmail"].ToString();


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
                    cmd.CommandText = "UPDATE Contact SET ContactName=@Nam,ContactPhone=@Phone,ContactEmail=@Email WHERE ContactID =" + ContactList.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@Nam", HttpUtility.HtmlEncode(ContactName.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Phone", HttpUtility.HtmlEncode(ContactPhone.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Email", HttpUtility.HtmlEncode(ContactEmail.Text)));

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