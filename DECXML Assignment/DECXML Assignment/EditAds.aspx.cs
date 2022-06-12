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
    public partial class EditAds : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null || !Session["ID"].Equals("admin"))
                Response.Redirect("Login.aspx");
            id = Convert.ToString(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Ads where Ads_ID = '" + id + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtNavigateUrl.Text = dt.Rows[0][2].ToString();
                txtAlternateText.Text = dt.Rows[0][3].ToString();
                txtKeyWord.Text = dt.Rows[0][4].ToString();
                txtCaption.Text = dt.Rows[0][5].ToString();

                UploadedImage.ImageUrl = dt.Rows[0][1].ToString();
            }
        }
        protected void btnEditAds_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = "";
            if (fuAdsImg.HasFile)
            {
                string fileName = fuAdsImg.PostedFile.FileName; //get file name
                fuAdsImg.SaveAs(Server.MapPath("AdsImages/" + fileName)); //upload to folder Images
                UploadedImage.ImageUrl = "AdsImages/"+ fileName;
                query = "update Ads set ImageUrl = '../AdsImages/" + fileName + "', NavigateUrl = '" + txtNavigateUrl.Text + "', " + "AlternateText = '" + txtAlternateText.Text + "',KeyWord = '" + txtKeyWord.Text + "', Caption = '" + txtCaption.Text + "' where Ads_ID = '" + id + "'";
            }
            else
            {
                query = "update Ads set NavigateUrl = '" + txtNavigateUrl.Text + "', AlternateText = '" + txtAlternateText.Text + "', " + "KeyWord = '" + txtKeyWord.Text + "',Caption = '" + txtCaption.Text + "' where Ads_ID = '" + id + "'";
            }
            

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            lblMessage.Text = "Ads Edited Successfully";
            con.Close();

            string strSQL = "SELECT * FROM Ads";

            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

            XmlDocument doc = new XmlDocument();

            DataSet ds = new DataSet("Advertisements");

            dt.Fill(ds, "Ad");

            ds.WriteXml(Server.MapPath(@".\xml\ads.xml"));
        }

        protected void btn_deleteAds_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from Ads where Ads_ID ='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            lblMessage.Text = "Ads Deleted";
            con.Close();

            string strSQL = "SELECT * FROM Ads";

            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

            XmlDocument doc = new XmlDocument();

            DataSet ds = new DataSet("Advertisements");

            dt.Fill(ds, "Ad");

            ds.WriteXml(Server.MapPath(@".\xml\ads.xml"));

            Response.Redirect("ManageAds.aspx");
        }
    }
}