using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace DECXML_Assignment
{
    public partial class ContactUs : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select TOP 1 Feedback_ID FROM Feedback ORDER BY convert(int,right(Feedback_ID, charindex('k', reverse(Feedback_ID)) -1 )) DESC", con);

                string LastCode = (string)cmd.ExecuteScalar();
                string getID = LastCode.Split('k')[1];
                int getIntID = Convert.ToInt32(getID);
                string date = DateTime.Today.ToString("d");

                string feedbackid = "Feedback" + (getIntID + 1).ToString();


                Feedbacks feedbackManager = new Feedbacks();
                if (feedbackManager.addfeedback(feedbackid, txtName.Text.Trim(), txtEmail.Text.Trim(), txtSubject.Text.Trim(), txtMessage.Text.Trim(), date))
                {
                    XmlDocument xDoc = feedbackManager.getXmlDocument();
                    xDoc.Save(MapPath("~\\xml\\Feedbacks.xml"));
                    this.lblStatus.Text = "Thank for your feedback! ";
                }
                else
                {
                    this.lblStatus.Text = "Error! Can't send your feedback";
                }

                //upload the content to table Ads
                string query1 = " insert into Feedback (Feedback_ID, Name, Email, Subject, Message, Date) values (@id, @name, @email, @subject, @message, @date) ";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@id", feedbackid);
                cmd1.Parameters.AddWithValue("@name", txtName.Text);
                cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd1.Parameters.AddWithValue("@subject", txtSubject.Text);
                cmd1.Parameters.AddWithValue("@message", txtMessage.Text);
                cmd1.Parameters.AddWithValue("@date", DateTime.Today);
                cmd1.ExecuteNonQuery();
                con.Close();

                txtName.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtSubject.Text = string.Empty;
                txtMessage.Text = string.Empty;

                Response.Write("<script type=\"text/javascript\">alert('Feedback Submitted');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}