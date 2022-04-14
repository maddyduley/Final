using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class EditInfo : System.Web.UI.Page
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
        }


        protected void EventEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditEvent.aspx");
        }
        protected void EditMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("MembersEdit.aspx");
        }





        protected void CompanyEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyEdit.aspx");
        }
        protected void ContactEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactEdit.aspx");
        }

    }
}