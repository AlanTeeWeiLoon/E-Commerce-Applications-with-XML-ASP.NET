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
    public partial class AddAds : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAds_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select TOP 1 Ads_ID FROM Ads ORDER  BY convert(int,right(Ads_ID, charindex('s', reverse(Ads_ID)) -1 )) DESC", con);

                string LastCode = (string)cmd.ExecuteScalar();
                string getID = LastCode.Split('s')[1];
                int getIntID = Convert.ToInt32(getID);


                string adsid = "Ads" + (getIntID + 1).ToString();

                string fileName = fileInput.PostedFile.FileName; //get file name
                fileInput.SaveAs(Server.MapPath("AdsImages/" + fileName)); //upload to folder Images

                //upload the content to table Ads
                string query1 = " insert into Ads (Ads_ID, ImageURL, NavigateUrl, AlternateText, Keyword, Caption) values (@id, @imageurl, @navigateurl, @alternatetext, @keyword, @caption) ";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@id", adsid);
                cmd1.Parameters.AddWithValue("@navigateurl", txtNavigateUrl.Text);
                cmd1.Parameters.AddWithValue("@alternatetext", txtAlternateText.Text);
                cmd1.Parameters.AddWithValue("@keyword", txtKeyWord.Text);
                cmd1.Parameters.AddWithValue("@caption", txtCaption.Text);
                cmd1.Parameters.AddWithValue("@imageurl", "../AdsImages/" + fileName);
                cmd1.ExecuteNonQuery();
                con.Close();

                string strSQL = "SELECT * FROM Ads";

                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

                XmlDocument doc = new XmlDocument();

                DataSet ds = new DataSet("Advertisements");

                dt.Fill(ds, "Ad");

                ds.WriteXml(Server.MapPath(@".\xml\ads.xml"));

                txtNavigateUrl.Text = string.Empty;
                txtAlternateText.Text = string.Empty;
                txtKeyWord.Text = string.Empty;
                txtCaption.Text = string.Empty;
                fileInput.PostedFile.InputStream.Dispose();

                lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
                lblMessage.Text = "Ads Added Successfully";

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}