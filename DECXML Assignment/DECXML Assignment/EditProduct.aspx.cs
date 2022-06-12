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
    public partial class EditProduct : System.Web.UI.Page
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
                SqlDataAdapter da = new SqlDataAdapter("select * from Product where Prod_ID = '" + id + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtProductName.Text = dt.Rows[0][1].ToString();
                txtProductDescription.Text = dt.Rows[0][2].ToString();
                ddlCategory.Text = dt.Rows[0][3].ToString();
                txtPrice.Text = dt.Rows[0][4].ToString();
                txtStock.Text = dt.Rows[0][5].ToString();

                UploadedImage.ImageUrl = dt.Rows[0][6].ToString();
            }
        }

        protected void btnEditProduct_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "";
            if (fuAdsImg.HasFile)
            {
                string fileName = fuAdsImg.PostedFile.FileName; //get file name
                fuAdsImg.SaveAs(Server.MapPath("ProductImage/" + fileName)); //upload to folder Images
                UploadedImage.ImageUrl = "ProductImage/" + fileName;
                query = "update Product set Prod_Name = '" + txtProductName.Text + "', Prod_Description = '" + txtProductDescription.Text + "', " + "Prod_Category = '" + ddlCategory.Text + "',Prod_Price = '" + txtPrice.Text + "', Prod_Stock = '" + txtStock.Text + "', Prod_Image = 'ProductImage/" + fileName + "' where Prod_ID = '" + id + "'";
            }
            else
            {
                query = "update Product set Prod_Name = '" + txtProductName.Text + "', Prod_Description = '" + txtProductDescription.Text + "', " + "Prod_Category = '" + ddlCategory.Text + "',Prod_Price = '" + txtPrice.Text + "', Prod_Stock = '" + txtStock.Text + "' where Prod_ID = '" + id + "'";
            }

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            lblMessage.Text = "Product Edited Successfully";
            con.Close();

            string strSQL = "SELECT * FROM Product";

            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

            XmlDocument doc = new XmlDocument();

            DataSet ds = new DataSet("Products");

            dt.Fill(ds, "Product");

            ds.WriteXml(Server.MapPath(@".\xml\products.xml"));
        }

        protected void btn_deleteProduct_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from Product where Prod_ID ='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            lblMessage.Text = "Product Deleted";
            con.Close();

            string strSQL = "SELECT * FROM Product";

            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

            XmlDocument doc = new XmlDocument();

            DataSet ds = new DataSet("Products");

            dt.Fill(ds, "Product");

            ds.WriteXml(Server.MapPath(@".\xml\products.xml"));

            Response.Redirect("ManageProduct.aspx");
        }
    }
}