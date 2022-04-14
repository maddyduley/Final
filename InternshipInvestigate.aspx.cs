using System;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace Lab3
{
    public partial class InternshipInvestigate : System.Web.UI.Page
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
                    string Inserted = "Insert INTO InternshipView VALUES (" + Session["Student"].ToString() + "," + Session["InternSelect"].ToString() + ",'True','False')";
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

            String sqlQuery = "SELECT Ints.InternshipID, Ints.InternshipTitle,Ints.InternshipDescription,Ints.DateStart,Ints.Upload,Com.CompanyName, Com.CompanyAddress, Con.ContactName,Con.ContactPhone,Con.ContactEmail from Internship Ints,Contact Con, Company Com WHERE Com.CompanyID=Con.CompanyID AND Con.ContactID=Ints.ContactID AND Ints.InternshipID=" + Session["InternSelect"].ToString();
            //get the studentID by using the username of the Student that is logged in
            SqlConnection sqlConnect = new
            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            sqlConnect.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                lblTitle.Text = reader["InternshipTitle"].ToString();
                lblDDescrip.Text = reader["InternshipDescription"].ToString();
                lblDateStart.Text = reader["DateStart"].ToString();
                lblDate.Text = reader["Upload"].ToString();
                lblCompanyName.Text = reader["CompanyName"].ToString();
                lblCompanyAddress.Text = reader["CompanyAddress"].ToString();
                lblContactName.Text = reader["ContactName"].ToString();
                lblContactPhone.Text = reader["ContactPhone"].ToString();
                lblContactEmail.Text = reader["ContactEmail"].ToString();
            }
            sqlConnect.Close();



        }

        protected void Like_Click(object sender, EventArgs e)
        {
            {
                String sqlQuery = "Select LikeBttn From InternshipView WHERE StudentID=" + Session["Student"].ToString() + " AND InternshipID=" + Session["InternSelect"].ToString();
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
                    string Inserted = "Update InternshipView Set LikeBttn = 'False' WHERE StudentID=" + Session["Student"].ToString() + " AND InternshipID=" + Session["InternSelect"].ToString();

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
                    string Inserted = "Update InternshipView Set LikeBttn = 'True' WHERE StudentID=" + Session["Student"].ToString() + " AND InternshipID=" + Session["InternSelect"].ToString();

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
            Response.Redirect("ApplyIntern.aspx");
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogedIn.aspx");
        }
    }
}