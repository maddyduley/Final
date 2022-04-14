// File: AssignJob.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Show students that have applied for a job and award them with the job
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;

namespace Lab3
{
    public partial class AssignJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people that are logged in to view the page
                if (Session["Username"] != null)
                {//only allow members to use the page
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

        protected void AwardJob_Click(object sender, EventArgs e)
        {
            {//insert new entries if the job has not already been given out or the student doesn;t have a job
                SqlConnection sqlConnectss = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQueryss = "INSERT INTO StudentJob VALUES (" + StudentNamedList.SelectedValue + "," + JobNameList.SelectedValue + ")";

                SqlCommand commandss = new SqlCommand(sqlQueryss, sqlConnectss);
                try
                {
                    sqlConnectss.Open();
                    commandss.ExecuteNonQuery();
                    JobResult.Text = "Success";
                    SqlConnection sqlConnectd = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    String sqlQuerysd = "Update Job Set JobStatus='Closed' WHERE JobID =" + JobNameList.SelectedValue;

                    SqlCommand commandds = new SqlCommand(sqlQuerysd, sqlConnectd);
                    sqlConnectd.Open();
                    commandds.ExecuteNonQuery();
                    sqlConnectd.Close();

                    try
                    {
                        {
                            {
                                String sqlQuery = "Select StudentID, FirstName,LastName,Email From Student WHERE StudentID=" + StudentNamedList.SelectedValue;
                                //get the studentID by using the username of the Student that is logged in
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

                            }

                            {
                                String sqlQuery = "Select JobID, JobTitle,JobDescription,DateStart From Job WHERE JobID=" + JobNameList.SelectedValue;
                                //get the studentID by using the username of the Student that is logged in
                                SqlConnection sqlConnect = new
                                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                                sqlConnect.Open();
                                SqlDataReader reader = sqlCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    Session["Jobname"] = reader["JobTitle"].ToString();
                                    Session["Descrpts"] = reader["JobDescription"].ToString();
                                    Session["Startingss"] = reader["DateStart"].ToString();
                                }
                                sqlConnect.Close();

                            }

                        }

                        MailMessage mail = new MailMessage();
                        string fromemail = "OleSchoolJMU@gmail.com";
                        String Password = "OleSchoolJMU2022!";
                        String toemail = Session["Emailss"].ToString();
                        String subject = "Congrats";
                        String contentbody = "Dear " + Session["Firstss"].ToString() + " " + Session["Lastss"].ToString() + System.Environment.NewLine + "Congrats on getting the " + Session["Jobname"].ToString() + "." + System.Environment.NewLine + "Your job will start on " + Session["Startingss"].ToString() + System.Environment.NewLine + "Here are the details: " + Session["Descrpts"].ToString();
                        mail.From = new MailAddress(fromemail);
                        mail.To.Add(toemail);
                        mail.Subject = subject;
                        mail.Body = contentbody;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.Credentials = new NetworkCredential(fromemail, Password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        Emailsend.Text = "Email sent";
                    }

                    catch
                    {
                        Emailsend.Text = "Problem with email";
                    }


                }
                catch (SqlException)
                {
                    JobResult.Text = "Record Already Exists ";
                }
                finally
                {
                    sqlConnectss.Close();
                }



            }



        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}