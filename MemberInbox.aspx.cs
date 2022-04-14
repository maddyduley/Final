using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class MemberInbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            {//only allow people that are logged in to use the page
                if (Session["Username"] != null)
                {//only allow students to use the page
                    if (Session["Typed"].ToString() == "Admin")
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
                        String sqlQuery = "SELECT Me.MessageID, Me.Header from Member Mem, MessagesMemToMem Me WHERE Me.MemberIDTo=Mem.MemberID AND Mem.MemberID=" + Session["Member"];
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
                    catch
                    {

                    }
                }
                {
                    try
                    {
                        String sqlQuery = "SELECT Me.MessageID, Me.Header from Member Mem, MessagesStudToMem Me WHERE Me.MemberID=Mem.MemberID AND Mem.MemberID=" + Session["Member"];
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


            Response.Redirect("MemberMessageFromMember.aspx");
        }

        protected void StudentMessage_Click(object sender, EventArgs e)
        {

            String row = Convert.ToString((sender as LinkButton).CommandArgument);

            Session["Message"] = (row);


            Response.Redirect("MemberMessagefromStudent.aspx");
        }

        protected void SendEmail_Click(object sender, EventArgs e)
        {

            Response.Redirect("SendMemtoStud.aspx");
        }

        protected void SendEmail2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendMemtoMem.aspx");
        }

        protected void SendtoStud_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmailStudents.aspx");
        }

        protected void SendtoMem_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmailMembers.aspx");
        }
    }
}