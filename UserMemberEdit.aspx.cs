using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;


namespace Lab3
{
    public partial class UserMemberEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            {//dont allow anyone that isn't signed in to view the page
                if (Session["Username"] != null)
                {//make sure the person is a student
                    if (Session["Typed"].ToString() == "Student")
                    {
                        {//get the studentID to use when uploading the filename into sql
                            String sqlQuery = "Select StudentID From Student WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                            sqlConnect.Open();
                            SqlDataReader reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                Session["Student"] = reader["StudentID"].ToString();
                            }
                            sqlConnect.Close();

                        }
                    }
                    else if (Session["Typed"].ToString() == "Member")
                    {
                        {//get the studentID to use when uploading the filename into sql
                            String sqlQuery = "Select MemberID From Member WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                            sqlConnect.Open();
                            SqlDataReader reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                Session["Member"] = reader["MemberID"].ToString();
                            }
                            sqlConnect.Close();

                        }
                    }
                    else if (Session["Typed"].ToString() == "Admin")
                    {
                        {//get the studentID to use when uploading the filename into sql
                            String sqlQuery = "Select MemberID From Member WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                            sqlConnect.Open();
                            SqlDataReader reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                Session["Member"] = reader["MemberID"].ToString();
                            }
                            sqlConnect.Close();

                        }
                    }
                    else if (Session["Typed"].ToString() == "Leader")
                    {
                        {//get the studentID to use when uploading the filename into sql
                            String sqlQuery = "Select MemberID From Member WHERE UserName=" + "'" + Session["Username"].ToString() + "'";
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                            sqlConnect.Open();
                            SqlDataReader reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                Session["Member"] = reader["MemberID"].ToString();
                            }
                            sqlConnect.Close();

                        }
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
                String firsted = Session["First"].ToString();
                txtFirstName.Text = firsted;
                String Lasted = Session["Lasts"].ToString();
                txtLastName.Text = Lasted;
                String Emailed = Session["email"].ToString();
                txtEmail.Text = Emailed;
                String Phoned = Session["Phone"].ToString();
                txtPhone.Text = Phoned;
                String Titled = Session["TITLE"].ToString();
                txtTitle.Text = Titled;
                String Graded = Session["Grad"].ToString();
                txtGradYear.Text = Graded;
                string Emailstat = Session["Status"].ToString();
                EmailList.SelectedValue = Emailstat;
            }



        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            {
                using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                {

                    try
                    {
                        if (fileUploadText.HasFile)
                            // Call a helper method routine to save the file.
                            SaveFile(fileUploadText.PostedFile);
                    }
                    catch
                    {
                        txtDisplay.Text = "Error occured, please try a different file";
                    }


                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sc;
                    cmd.CommandText = "UPDATE Member SET FirstName=@FName,LastName=@LName,Email=@EMAIL,PhoneNumber=@PhoneNum,Title=@Title,GradYear=@Grad,EmailStat='" + EmailList.SelectedValue + "' WHERE UserName ='" + Session["Username"].ToString() + "'";

                    cmd.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    cmd.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", HttpUtility.HtmlEncode(txtEmail.Text)));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNum", HttpUtility.HtmlEncode(txtPhone.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Title", HttpUtility.HtmlEncode(txtTitle.Text)));
                    cmd.Parameters.Add(new SqlParameter("@Grad", HttpUtility.HtmlEncode(txtGradYear.Text)));


                    sc.Open();
                    cmd.ExecuteNonQuery();
                    sc.Close();



                    Response.Redirect("MemberLogedIn.aspx");
                    lblStatus.Text = "Successful";
                }
            }
            //catch
            {
                lblStatus.Text = "Error Occured";
            }
        }

        void SaveFile(HttpPostedFile file)
        {
            string filename = Server.HtmlEncode(fileUploadText.FileName);
            string extension = System.IO.Path.GetExtension(filename);

            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
            {


                try
                {

                    //save the file into the folder created
                    String fpath = Request.PhysicalApplicationPath + "Images\\" + fileUploadText.FileName;
                    fileUploadText.PostedFile.SaveAs(fpath);



                    if (Session["Typed"].ToString() == "Student")
                    {
                        SqlConnection sqlConnect = new
                     SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        String sqlQuery = "Update Student Set Image = '" + fileUploadText.FileName + "'" + " Where StudentID=" + Session["Student"];

                        SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
                        try
                        {

                            sqlConnect.Open();
                            command.ExecuteNonQuery();


                        }
                        catch (SqlException)
                        {
                            txtDisplay.Text = "Something went wrong";
                        }
                        finally
                        {
                            sqlConnect.Close();

                        }
                    }
                    else
                    {
                        SqlConnection sqlConnect = new
                        SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                        String sqlQuery = "Update Member Set Image = '" + fileUploadText.FileName + "'" + " Where MemberID=" + Session["Member"];

                        SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
                        try
                        {

                            sqlConnect.Open();
                            command.ExecuteNonQuery();


                        }
                        catch (SqlException)
                        {
                            txtDisplay.Text = "Something went wrong";
                        }
                        finally
                        {
                            sqlConnect.Close();

                        }
                    }

                    txtDisplay.Text = "Success!";

                }
                catch
                {
                    txtDisplay.Text = "File too Large";
                }
            }
            else
            {
                txtDisplay.Text = "You did not upload an acceptable format please use .jpg or .jpeg or .png";
            }
        } 




            protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }


        protected void bttnUpload_Click(object sender, EventArgs e)
        {
            
            
        }




    }
}