// File: AssignIntern.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Show students that have applied for an internship and award them with the internship
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;

namespace Lab3
{
    public partial class AssignIntern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//only allow people who are signed in to view the page
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
        protected void AwardIntern_Click(object sender, EventArgs e)
        {
            {//insert new entries into the table
                SqlConnection sqlConnectss = new
                             SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQueryss = "INSERT INTO StudentIntern VALUES (";
                sqlQueryss += StudentNameList.SelectedValue + "," + InternNameList.SelectedValue + ")";

                SqlCommand commandss = new SqlCommand(sqlQueryss, sqlConnectss);
                try
                {
                    sqlConnectss.Open();
                    commandss.ExecuteNonQuery();
                }
                catch (SqlException)
                {//if the intern or scholarship is already being used, tell the user
                    AssignResult.Text = "Entry already Exists ";
                }
                finally
                {
                    sqlConnectss.Close();
                }

                try
                {
                    {
                        {
                            String sqlQuery = "Select StudentID, FirstName,LastName,Email From Student WHERE StudentID=" + StudentNameList.SelectedValue;
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
                            String sqlQuery = "Select InternshipID, InternshipTitle,InternshipDescription, DateStart,DateEnd From Internship WHERE InternshipID=" + InternNameList.SelectedValue;
                            //get the studentID by using the username of the Student that is logged in
                            SqlConnection sqlConnect = new
                            SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                            sqlConnect.Open();
                            SqlDataReader reader = sqlCommand.ExecuteReader();
                            while (reader.Read())
                            {
                                Session["Intname"] = reader["InternshipTitle"].ToString();
                                Session["IntDescrpts"] = reader["InternshipDescription"].ToString();
                                Session["Intstart"] = reader["DateStart"].ToString();
                                Session["Intend"] = reader["DateEnd"].ToString();
                            }
                            sqlConnect.Close();

                        }

                    }

                    MailMessage mail = new MailMessage();
                    string fromemail = "OleSchoolJMU@gmail.com";
                    String Password = "OleSchoolJMU2022!";
                    String toemail = Session["Emailss"].ToString();
                    String subject = "Congrats";
                    String contentbody = "Dear " + Session["Firstss"].ToString() + " " + Session["Lastss"].ToString() + System.Environment.NewLine + "Congrats on getting the " + Session["Intname"].ToString() + "." + System.Environment.NewLine + "Your job will start on " + Session["Intstart"].ToString() + "and go through " + Session["Intend"] + System.Environment.NewLine + "Here are the details: " + Session["IntDescrpts"].ToString();
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

        }


        protected void Goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogIn.aspx");
        }
    }
}