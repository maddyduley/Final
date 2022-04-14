using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class SendStudtoStud : System.Web.UI.Page
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
        }


        protected void Send_Click(object sender, EventArgs e)
        {


            {//insert all of the values into the login table
                string Inserting = "Insert INTO MessagesStudToStud VALUES (@Title,'" + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt") + "',@Message," + Session["Student"].ToString() + "," + MemberList.SelectedValue + ")";

                SqlConnection sqlconnected = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                SqlCommand InsertCommand = new SqlCommand(Inserting, sqlconnected);
                InsertCommand.Parameters.Add(new SqlParameter("@Title", HttpUtility.HtmlEncode(Titlelbl.Text)));
                InsertCommand.Parameters.Add(new SqlParameter("@Message", HttpUtility.HtmlEncode(Messagelbl.Text)));


                sqlconnected.Open();
                InsertCommand.ExecuteScalar();
                sqlconnected.Close();
                Response.Redirect("StudentInbox.aspx");

            }



        }


    }
}