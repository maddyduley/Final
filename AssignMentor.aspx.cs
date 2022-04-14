using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;

namespace Lab3
{
    public partial class AssignMentor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//don't allow people that aren't logged in to view the page
                if (Session["Username"] != null)
                {//only allow members to view the page
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

        protected void AssignMentor_Click(object sender, EventArgs e)
        {
            {//assign members as mentors to students
                SqlConnection sqlConnect = new
                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQuery = "INSERT INTO Mentor VALUES (";
                sqlQuery += MentorNameList.SelectedValue + "," + MentorNameList.SelectedValue + "," + StudentNameList.SelectedValue + ")";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnect);
                try
                {
                    sqlConnect.Open();
                    command.ExecuteNonQuery();
                    MentorResult.Text = "Success";
                    //try
                    {
                        {
                            {
                                String sqlQuerys = "Select StudentID, FirstName,LastName,Email From Student WHERE StudentID=" + StudentNameList.SelectedValue;
                                //get the studentID by using the username of the Student that is logged in
                                SqlConnection sqlConnects = new
                                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                SqlCommand sqlCommands = new SqlCommand(sqlQuerys, sqlConnects);
                                sqlConnects.Open();
                                SqlDataReader readers = sqlCommands.ExecuteReader();
                                while (readers.Read())
                                {
                                    Session["Firstss"] = readers["FirstName"].ToString();
                                    Session["Lastss"] = readers["LastName"].ToString();
                                    Session["Emailss"] = readers["Email"].ToString();
                                }
                                sqlConnects.Close();

                            }

                            {
                                String sqlQueryss = "Select MemberID, FirstName,LastName,Email From Member WHERE MemberID=" + MentorNameList.SelectedValue;
                                //get the studentID by using the username of the Student that is logged in
                                SqlConnection sqlConnectss = new
                                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                SqlCommand sqlCommandss = new SqlCommand(sqlQueryss, sqlConnectss);
                                sqlConnectss.Open();
                                SqlDataReader readerss = sqlCommandss.ExecuteReader();
                                while (readerss.Read())
                                {
                                    Session["Firstsss"] = readerss["FirstName"].ToString();
                                    Session["Lastsss"] = readerss["LastName"].ToString();
                                    Session["Emailsss"] = readerss["Email"].ToString();
                                }
                                sqlConnectss.Close();

                            }

                        }

                        {
                            MailMessage mails = new MailMessage();
                            string fromemails = "OleSchoolJMU@gmail.com";
                            String Passwords = "OleSchoolJMU2022!";
                            String toemails = Session["Emailsss"].ToString();
                            String subjects = "Congrats";
                            String contentbodys = "Dear " + Session["Firstsss"].ToString() + " " + Session["Lastsss"].ToString() + System.Environment.NewLine + "You have been assigned " + Session["Firstss"].ToString() + " " + Session["Lastss"].ToString() + " as a new mentee." + System.Environment.NewLine + "Please contact your new mentee through the Ole School App or using this email " + Session["Emailsss"].ToString();
                            mails.From = new MailAddress(fromemails);
                            mails.To.Add(toemails);
                            mails.Subject = subjects;
                            mails.Body = contentbodys;
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            smtp.Credentials = new NetworkCredential(fromemails, Passwords);
                            smtp.EnableSsl = true;
                            smtp.Send(mails);
                            Emailsend.Text = "Email sent";
                        }
                        {
                            MailMessage mail = new MailMessage();
                            string fromemail = "OleSchoolJMU@gmail.com";
                            String Password = "OleSchoolJMU2022!";
                            String toemail = Session["Emailss"].ToString();
                            String subject = "Congrats";
                            String contentbody = "Dear " + Session["Firstss"].ToString() + " " + Session["Lastss"].ToString() + System.Environment.NewLine + "You have been assigned " + Session["Firstsss"].ToString() + " " + Session["Lastsss"].ToString() + " as your new mentor." + System.Environment.NewLine + "Please contact your new mentor through the Ole School App or using this email " + Session["Emailss"].ToString();
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
                    }

                    //catch
                    {
                        //Emailsend.Text = "Problem with email";
                    }





                }
                catch (SqlException)
                {//Student can only have one mentor
                    MentorResult.Text = "Student Already Assigned to Mentor";
                }
                finally
                {
                    sqlConnect.Close();
                }

            }
        }

        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}