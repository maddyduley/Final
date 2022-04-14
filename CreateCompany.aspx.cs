using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class CreateCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//don't allow non users to use the page
                if (Session["Username"] != null)
                {// don't allow non members to adjust jobs
                    if (Session["Typed"].ToString() == "Leader")
                    {

                    }
                    else if (Session["Typed"].ToString() == "Admin")
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
        protected void AddCompany_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    {
                        try
                        {
                            if (fileUploadText.HasFile)
                                // Call a helper method routine to save the file.
                                SaveFile(fileUploadText.PostedFile);
                            else
                                // Notify the user that a file was not uploaded.
                                txtDisplay.Text = "You did not specify a file to upload.";
                        }
                        catch
                        {
                            txtDisplay.Text = "Error occured, please try a different file";
                        }
                    }



                    using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                    {




                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sc;
                        cmd.CommandText = "INSERT INTO Company VALUES (@Named,@Add,@Phone,'" + Session["FileName"].ToString() + "')";

                        cmd.Parameters.Add(new SqlParameter("@Named", HttpUtility.HtmlEncode(Named.Text)));
                        cmd.Parameters.Add(new SqlParameter("@Add", HttpUtility.HtmlEncode(Addressed.Text)));
                        cmd.Parameters.Add(new SqlParameter("@Phone", HttpUtility.HtmlEncode(Phoned.Text)));


                        sc.Open();
                        cmd.ExecuteNonQuery();
                        sc.Close();


                        lblStatus.Text = "Successful";
                    }
                }
                catch
                {
                    lblStatus.Text = "Forgot File";
                }
            }
        }
        void SaveFile(HttpPostedFile file)
        {
            string filename = Server.HtmlEncode(fileUploadText.FileName);
            Session["FileName"] = filename;
            string extension = System.IO.Path.GetExtension(filename);

            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
            {


                try
                {

                    //save the file into the folder created
                    String fpath = Request.PhysicalApplicationPath + "Company\\" + fileUploadText.FileName;
                    fileUploadText.PostedFile.SaveAs(fpath);

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
}