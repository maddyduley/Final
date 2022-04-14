using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class Engagement : System.Web.UI.Page
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


        protected void AccountApplication_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountApplications.aspx");
        }



        protected void Analytics_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentAnalytics.aspx");
        }



    }
}