using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Lab3
{
    public partial class ScholarshipInvestigate : System.Web.UI.Page
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


            {
                String sqlQuerys = "Select StudentID From Student WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                //get the studentID by using the username of the Student that is logged in
                SqlConnection sqlConnects = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommands = new SqlCommand(sqlQuerys, sqlConnects);
                sqlConnects.Open();
                SqlDataReader readers = sqlCommands.ExecuteReader();
                while (readers.Read())
                {
                    Session["Student"] = readers["StudentID"].ToString();
                }
                sqlConnects.Close();

            }

            try
            {
                {//insert the variables into the member table (Member type is automatically just a member because priveledge escalation should be done manually in case of someone get unauthorized access) 
                    string Inserted = "Insert INTO ScholarshipView VALUES (" + Session["Student"].ToString() + "," + Session["ScholarshipSelect"].ToString() + ",'True','False')";
                    SqlConnection sqlConnected = new
                    SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    SqlCommand sqlCommanded = new SqlCommand(Inserted, sqlConnected);
                    sqlConnected.Open();
                    SqlDataReader readered = sqlCommanded.ExecuteReader();
                    while (readered.Read())
                    {
                        Session["Like"] = readered["LikeBttn"].ToString();
                    }
                    sqlConnected.Close();
                }
            }
            catch
            {

            }

            String sqlQuery = "SELECT Sc.ScholarshipName,Sc.ScholarshipYear,Sc.ScholarshipAmount from Scholarship Sc WHERE Sc.ScholarshipID=" + Session["ScholarshipSelect"].ToString();
            //get the studentID by using the username of the Student that is logged in
            SqlConnection sqlConnect = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                lblName.Text = reader["ScholarshipName"].ToString();
                lblYear.Text = reader["ScholarshipYear"].ToString();
                lblAmount.Text = reader["ScholarshipAmount"].ToString();

            }
            sqlConnect.Close();



        }

        protected void Like_Click(object sender, EventArgs e)
        {
            {
                String sqlQuery = "Select LikeBttn From ScholarshipView WHERE StudentID=" + Session["Student"].ToString() + " AND ScholarshipID=" + Session["ScholarshipSelect"].ToString();
                //get the studentID by using the username of the Student that is logged in
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                sqlConnect.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Session["Like"] = reader["LikeBttn"].ToString();
                }
                sqlConnect.Close();

            }

            if (Session["Like"].ToString() == "True")
            {
                {//insert the variables into the member table (Member type is automatically just a member because priveledge escalation should be done manually in case of someone get unauthorized access) 
                    string Inserted = "Update ScholarshipView Set LikeBttn = 'False' WHERE StudentID=" + Session["Student"].ToString() + " AND ScholarshipID=" + Session["ScholarshipSelect"].ToString();

                    SqlConnection sqlconnects = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand InsertCommand = new SqlCommand(Inserted, sqlconnects);
                    sqlconnects.Open();
                    InsertCommand.ExecuteScalar();
                    sqlconnects.Close();
                }
            }
            else if (Session["Like"].ToString() == "False")
            {
                {//insert the variables into the member table (Member type is automatically just a member because priveledge escalation should be done manually in case of someone get unauthorized access) 
                    string Inserted = "Update ScholarshipView Set LikeBttn = 'True' WHERE StudentID=" + Session["Student"].ToString() + " AND ScholarshipID=" + Session["ScholarshipSelect"].ToString();

                    SqlConnection sqlconnects = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand InsertCommand = new SqlCommand(Inserted, sqlconnects);
                    sqlconnects.Open();
                    InsertCommand.ExecuteScalar();
                    sqlconnects.Close();

                }
            }




        }

        protected void Apply_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApplyScholar.aspx");
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogedIn.aspx");
        }
    }
}