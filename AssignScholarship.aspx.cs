// File: AssignScholarship.aspx.cs
// Author: Madisonsoft
// Date: 2/25/2022
// Purpose: Show students that have applied for an Scholarship and award them with the Scholarship
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;

namespace Lab3
{
    public partial class AssignScholarship : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {//don't allow people that aren't signed in to view the page
                if (Session["Username"] != null)
                {// only allow members to view the page
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

        protected void AwardScholar_Click(object sender, EventArgs e)
        {
            {//if the scholarship hasn't been given out yet, assign it to a student
                SqlConnection sqlConnectss = new
                               SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                String sqlQueryss = "INSERT INTO StudentAward VALUES (";
                sqlQueryss += StudentNameList.SelectedValue + "," + ScholarshipNameList.SelectedValue + ")";

                SqlCommand commandss = new SqlCommand(sqlQueryss, sqlConnectss);
                try
                {//tell the user if the scholarship was assigned
                    sqlConnectss.Open();
                    commandss.ExecuteNonQuery();
                    ScholarResult.Text = "Success";
                    SqlConnection sqlConnectd = new
                     SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                    String sqlQuerysd = "Update Scholarship Set Status='Closed' WHERE ScholarshipID =" + ScholarshipNameList.SelectedValue;

                    SqlCommand commandds = new SqlCommand(sqlQuerysd, sqlConnectd);
                    sqlConnectd.Open();
                    commandds.ExecuteNonQuery();
                    sqlConnectd.Close();

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
                                String sqlQuery = "Select ScholarshipID, ScholarshipName,ScholarshipYear,ScholarshipAmount From Scholarship WHERE ScholarshipID=" + ScholarshipNameList.SelectedValue;
                                //get the studentID by using the username of the Student that is logged in
                                SqlConnection sqlConnect = new
                                SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
                                sqlConnect.Open();
                                SqlDataReader reader = sqlCommand.ExecuteReader();
                                while (reader.Read())
                                {
                                    Session["Scholarnamed"] = reader["ScholarshipName"].ToString();
                                    Session["Yeared"] = reader["ScholarshipYear"].ToString();
                                    Session["Amounted"] = reader["ScholarshipAmount"].ToString();
                                }
                                sqlConnect.Close();

                            }

                        }

                        MailMessage mail = new MailMessage();
                        string fromemail = "OleSchoolJMU@gmail.com";
                        String Password = "OleSchoolJMU2022!";
                        String toemail = Session["Emailss"].ToString();
                        String subject = "Congrats";
                        String contentbody = "Dear " + Session["Firstss"].ToString() + " " + Session["Lastss"].ToString() + System.Environment.NewLine + "Congrats on receiving the " + Session["Scholarnamed"].ToString() + " for " + Session["Yeared"].ToString() + System.Environment.NewLine + "You will receive $" + Session["Amounted"].ToString() + System.Environment.NewLine;
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
                {//tell the user if the scholarship was already assigned
                    ScholarResult.Text = "Scholarship already assigned ";
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