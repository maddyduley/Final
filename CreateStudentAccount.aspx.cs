using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class CreateStudentAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx", false);
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {

                // COMMIT VALUES
                try
                {
                    string emailstat;
                    if (CheckBox2.Checked)
                    {
                        emailstat = "True";
                    }
                    else
                    {
                        emailstat = "False";
                    }
                    System.Data.SqlClient.SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

                    sc.Open();

                    System.Data.SqlClient.SqlCommand createUser = new System.Data.SqlClient.SqlCommand();
                    createUser.Connection = sc;
                    //INSERT USER RECORD
                    createUser.CommandText = "INSERT INTO StudentAccountApplication  (FirstName, LastName, Email,PhoneNumber,UniversityYear,Major,GradYear,EmailStat,UserName,Password) " +
                        "VALUES (@FName, @LName,@Email,@PhoneNum,@Univers,@maj,@Grad,'" + emailstat + "', @Username,@Password)";
                    createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtFirstName.Text)));
                    createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtLastName.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Email", HttpUtility.HtmlEncode(txtEmail.Text)));
                    createUser.Parameters.Add(new SqlParameter("@PhoneNum", HttpUtility.HtmlEncode(txtPhone.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Univers", HttpUtility.HtmlEncode(txtUniversityYear.Text)));
                    createUser.Parameters.Add(new SqlParameter("@maj", HttpUtility.HtmlEncode(txtMajor.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Grad", HttpUtility.HtmlEncode(txtGradYear.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));
                    createUser.Parameters.Add(new SqlParameter("@Password", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text))));
                    createUser.ExecuteNonQuery();
                    sc.Close();

                    Response.Redirect("StudentLogIn.aspx");


                    lblStatus.Text = "User committed!";
                }
                catch
                {
                    lblStatus.Text = "Database Error - User not committed.";
                }
            }
            else
            {
                Label3.Text = "Required to Acknowledge field";
            }
        }


    }
}