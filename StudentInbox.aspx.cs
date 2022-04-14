using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class StudentInbox : System.Web.UI.Page
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

                {
                    //try
                    {
                        String sqlQuery = "SELECT Me.MessageID, Me.Header from Student Stu, MessagesMemToStudent Me WHERE Me.StudentID=Stu.StudentID AND Stu.StudentID=" + Session["Student"];
                        {
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                            DataTable dtForGridView = new DataTable();
                            sqlAdapter.Fill(dtForGridView);

                            MemberMessages.DataSource = dtForGridView;
                            MemberMessages.DataBind();
                        }
                    }
                    //catch
                    {

                    }
                }
                {
                    try
                    {
                        String sqlQuery = "SELECT Me.MessageID, Me.Header from Student Stu, MessagesStudToStud Me WHERE Me.StudIDTo=Stu.StudentID AND Stu.StudentID=" + Session["Student"];
                        {
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                            DataTable dtForGridView = new DataTable();
                            sqlAdapter.Fill(dtForGridView);

                            StudentMasseges.DataSource = dtForGridView;
                            StudentMasseges.DataBind();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        protected void MemberMessage_Click(object sender, EventArgs e)
        {

            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["Message"] = (row);


            Response.Redirect("StudentMessageFromMember.aspx");
        }

        protected void StudentMessage_Click(object sender, EventArgs e)
        {

            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["Message"] = (row);


            Response.Redirect("StudentMessageFromStudent.aspx");
        }

        protected void SendEmail_Click(object sender, EventArgs e)
        {

            Response.Redirect("SendStudtoStud.aspx");
        }

        protected void SendEmail2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendStudtoMem.aspx");
        }
    }
}