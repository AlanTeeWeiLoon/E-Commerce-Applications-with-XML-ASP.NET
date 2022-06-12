using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Assignment
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID"] == null || !Session["ID"].Equals("admin"))
            //    Response.Redirect("Login.aspx");
        }

        public string fetchProduct()
        {
            string htmlStr = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select * from Product";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ID = reader.GetString(0);
                string ProductName = reader.GetString(1);
                string ProductDescription = reader.GetString(2);
                string ProductCategory = reader.GetString(3);
                int ProductPrice = reader.GetInt32(4);
                int ProductStock = reader.GetInt32(5);
                string ProductImage = reader.GetString(6);
                htmlStr += "<tr><td>" + ID + "</td><td>" + ProductName + "</td><td>" + ProductDescription + "</td><td>" + ProductCategory + "</td><td>" + ProductPrice + "</td><td>" + ProductStock + "</td><td><a href =" + ProductImage + " > View Image </ a ></td><td><a href=EditProduct.aspx?id=" + ID + " class='tm - product - edit - link'><i class='fas fa-edit tm-product-edit-icon'></i></a></td></tr>";
            }
            con.Close();
            return htmlStr;

        }
    }
}