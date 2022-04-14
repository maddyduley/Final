using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class StudentInfo : System.Web.UI.Page
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


        protected void EditStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentEdit.aspx");
        }
        protected void AssignMentor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignMentor.aspx");
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentSearch.aspx");
        }


    }
}