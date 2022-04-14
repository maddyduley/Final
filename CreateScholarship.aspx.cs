using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace Lab3
{
    public partial class CreateScholarship : System.Web.UI.Page
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

        protected void CreateJobs_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString()))
                    {




                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sc;
                        cmd.CommandText = "INSERT INTO Scholarship VALUES (@Named,@Yeared,@Amounted,'" + DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt") + "'," + MemberList.SelectedValue + ",0,'Open')";

                        cmd.Parameters.Add(new SqlParameter("@Named", HttpUtility.HtmlEncode(scholarnametxt.Text)));
                        cmd.Parameters.Add(new SqlParameter("@Yeared", HttpUtility.HtmlEncode(yeartxt.Text)));
                        cmd.Parameters.Add(new SqlParameter("@Amounted", HttpUtility.HtmlEncode(amounttxt.Text)));


                        sc.Open();
                        cmd.ExecuteNonQuery();
                        sc.Close();


                        lblStatus.Text = "Successful";


                        {
                            {
                                {
                                    String sqlQuery = "Select Count(StudentID) From Student WHERE EmailStat='True'";
                                    SqlConnection sqlConnect = new
                                       SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                                    sqlConnect.Open();
                                    Int32 count = (Int32)sqlCommand.ExecuteScalar();
                                    Session["CountingStudents"] = count;
                                    sqlConnect.Close();

                                }



                                for (int i = 1; i <= Convert.ToInt32(Session["CountingStudents"]) + 1; i++)
                                {
                                    {
                                        {
                                            String sqlQuery2 = "Select EmailStat From Student WHERE StudentID=" + i;
                                            SqlConnection sqlConnect2 = new
                                               SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                            SqlCommand sqlCommand2 = new SqlCommand(sqlQuery2, sqlConnect2);
                                            sqlConnect2.Open();
                                            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                                            while (reader2.Read())
                                            {
                                                Session["resulted"] = reader2["EmailStat"].ToString();
                                            }
                                            sqlConnect2.Close();
                                        }


                                        if (Session["resulted"].ToString() == "True")
                                        {
                                            String sqlQuery2 = "Select EmailStat From Student WHERE StudentID=" + i;
                                            SqlConnection sqlConnect2 = new
                                               SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                            SqlCommand sqlCommand2 = new SqlCommand(sqlQuery2, sqlConnect2);
                                            sqlConnect2.Open();
                                            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                                            while (reader2.Read())
                                            {
                                                Session["resulted"] = reader2["EmailStat"].ToString();
                                            }
                                            sqlConnect2.Close();
                                        }


                                        if (Session["resulted"].ToString() == "True")
                                        {

                                            String sqlQuery = "Select StudentID, FirstName,LastName,Email From Student WHERE EmailStat='True' AND StudentID=" + i;
                                            //get the studentID by using the username of the Student that is logged in
                                            try
                                            {
                                                SqlConnection sqlConnect = new
                                                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                                                sqlConnect.Open();
                                                SqlDataReader reader = sqlCommand.ExecuteReader();
                                                while (reader.Read())
                                                {
                                                    Session["Firstss"] = reader["FirstName"].ToString();
                                                    Session["Lastss"] = reader["LastName"].ToString();
                                                    Session["Emailss"] = reader["Email"].ToString();
                                                }
                                                sqlConnect.Close();




                                                MailMessage mail = new MailMessage();
                                                string fromemail = "OleSchoolJMU@gmail.com";
                                                String Password = "OleSchoolJMU2022!";
                                                String toemail = Session["Emailss"].ToString();
                                                String subject = "New Scholarship";
                                                String contentbody = "Dear " + Session["Firstss"].ToString() + " " + Session["Lastss"].ToString() + System.Environment.NewLine + "A new scholarship has been added." + System.Environment.NewLine + "Name:" + scholarnametxt.Text + System.Environment.NewLine + "Year:" + yeartxt.Text + System.Environment.NewLine + "Amount:" + amounttxt.Text + System.Environment.NewLine;
                                                mail.From = new MailAddress(fromemail);
                                                mail.To.Add(toemail);
                                                mail.Subject = subject;
                                                mail.Body = contentbody;
                                                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                                                smtp.Credentials = new NetworkCredential(fromemail, Password);
                                                smtp.EnableSsl = true;
                                                smtp.Send(mail);

                                            }
                                            catch
                                            {

                                            }

                                        }
                                    }
                                }


                            }
                        }





                    }
                }
                catch
                {
                    lblStatus.Text = "Error Occured";
                }
            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}