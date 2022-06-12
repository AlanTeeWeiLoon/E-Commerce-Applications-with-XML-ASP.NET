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
    public partial class AddProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null || !Session["ID"].Equals("admin"))
                Response.Redirect("Login.aspx");
            string xml = "xml/category.xml";
            if (!IsPostBack)
            {
                XmlDataSource1.Data = xml;
                XmlDataSource1.DataBind();
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select TOP 1 Prod_ID FROM Product ORDER  BY convert(int,right(Prod_ID, charindex('d', reverse(Prod_ID)) -1 )) DESC", con);

                string LastCode = (string)cmd.ExecuteScalar();
                string getID = LastCode.Split('d')[1];
                int getIntID = Convert.ToInt32(getID);


                string prodid = "Prod" + (getIntID + 1).ToString();

                string fileName = fileInput.PostedFile.FileName; //get file name
                fileInput.SaveAs(Server.MapPath("ProductImage/" + fileName)); //upload to folder Images

                //upload the content to table Product
                string query1 = " insert into Product (Prod_ID, Prod_Name, Prod_Description, Prod_Category, Prod_Price, Prod_Stock, Prod_Image) values (@id, @name, @description, @category, @price, @stock, @pImage) ";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@id", prodid);
                cmd1.Parameters.AddWithValue("@name", txtProductName.Text);
                cmd1.Parameters.AddWithValue("@description", txtProductDescription.Text);
                cmd1.Parameters.AddWithValue("@category", ddlCategory.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd1.Parameters.AddWithValue("@stock", txtStock.Text);
                cmd1.Parameters.AddWithValue("@pImage", "ProductImage/" + fileName);
                cmd1.ExecuteNonQuery();
                con.Close();

                string strSQL = "SELECT * FROM Product";

                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

                XmlDocument doc = new XmlDocument();

                DataSet ds = new DataSet("Products");

                dt.Fill(ds, "Product");

                ds.WriteXml(Server.MapPath(@".\xml\products.xml"));

                txtProductName.Text = string.Empty;
                txtProductDescription.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtStock.Text = string.Empty;
                fileInput.PostedFile.InputStream.Dispose();

                lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
                lblMessage.Text = "Product Added Successfully";

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}