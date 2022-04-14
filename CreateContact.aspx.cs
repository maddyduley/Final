using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class CreateContact : System.Web.UI.Page
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

        protected void AddContact_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                    {




                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sc;
                        cmd.CommandText = "INSERT INTO Contact VALUES (@Named,@Phone,@Email," + CompanyList.SelectedValue + ")";

                        cmd.Parameters.Add(new SqlParameter("@Named", HttpUtility.HtmlEncode(Named.Text)));
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
        }
    }
}