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
    public partial class AddCategory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID"] == null || !Session["ID"].Equals("admin"))
            //    Response.Redirect("Login.aspx");
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select TOP 1 Category_ID FROM Category ORDER BY convert(int,right(Category_ID, charindex('t', reverse(Category_ID)) -1 )) DESC", con);

                string LastCode = (string)cmd.ExecuteScalar();
                string getID = LastCode.Split('t')[1];
                int getIntID = Convert.ToInt32(getID);

                string catid = "Cat" + (getIntID + 1).ToString();

                //upload the content to table Library
                string query1 = " insert into Category (Category_ID, Category_Name, Category_Description) values (@id, @name, @description) ";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@id", catid);
                cmd1.Parameters.AddWithValue("@name", txtCategoryName.Text);
                cmd1.Parameters.AddWithValue("@description", txtCategoryDescription.Text);
                cmd1.ExecuteNonQuery();
                con.Close();

                string strSQL = "SELECT * FROM Category";

                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

                XmlDocument doc = new XmlDocument();

                DataSet ds = new DataSet("Categories");

                dt.Fill(ds, "Category");

                ds.WriteXml(Server.MapPath(@".\xml\categories.xml"));

                txtCategoryName.Text = string.Empty;
                txtCategoryDescription.Text = string.Empty;


                lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
                lblMessage.Text = "Category Added Successfully";

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}