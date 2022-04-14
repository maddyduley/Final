using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class ImageUpload : System.Web.UI.Page
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


        }

        protected void bttnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileUploadText.HasFile)
                    // Call a helper method routine to save the file.
                    SaveFile(fileUploadText.PostedFile);
                else
                    // Notify the user that a file was not uploaded.
                    txtDisplay.Text = "You did not specify a file to upload.";
                //put the file into sql
            }
            catch
            {
                txtDisplay.Text = "Error occured, please try a different file";
            }


            void SaveFile(HttpPostedFile file)
            {
                string filename = Server.HtmlEncode(fileUploadText.FileName);
                string extension = System.IO.Path.GetExtension(filename);

                if (extension == ".jpg"|| extension ==".png"|| extension ==".jpeg")               {


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
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}