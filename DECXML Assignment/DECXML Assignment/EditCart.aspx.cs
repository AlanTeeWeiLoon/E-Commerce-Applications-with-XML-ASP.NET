using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace DECXML_Assignment
{
    public partial class EditCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Server.UrlDecode(Request.QueryString["order_id"]) == null)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                string ord_id = Request.QueryString["order_id"].ToString();                
            }
        }

        protected void btnEditCart_Click(object sender, EventArgs e)
        {
            try
            {
                string ord_id = Server.UrlDecode(Request.QueryString["order_id"]);
                string cid = Server.UrlDecode(Request.QueryString["id"]);
                string prod_id = Server.UrlDecode(Request.QueryString["prod_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string query1 = "select Product.Prod_Price from Product where Prod_ID = '" + prod_id + "'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataReader reader = cmd1.ExecuteReader();
                int Prod_Price = 0;

                while (reader.Read())
                {
                    Prod_Price = reader.GetInt32(0);
                }
                con.Close();

                LinkButton btn = (LinkButton)sender;
                DataListItem item = (DataListItem)btn.NamingContainer;
                TextBox txt = (TextBox)item.FindControl("txtQuantity");
                int qty = Int32.Parse(txt.Text);

                int total = Prod_Price * qty;

                con.Open();
                string query = "update Orders set Quantity = "+ qty + ", Total_Price = " + total + " where Order_ID = '" + ord_id + "'" ;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();        
                con.Close();

                string strSQL = "SELECT * FROM Orders";

                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

                XmlDocument doc = new XmlDocument();

                DataSet ds = new DataSet("Orders");

                dt.Fill(ds, "Order");

                ds.WriteXml(Server.MapPath(@".\xml\orders.xml"));

                Response.Write("<script LANGUAGE='JavaScript' >alert('Cart Update Successful')</script>");
                Response.Redirect("Cart.aspx?id=" + cid);

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }

        protected void btn_deleteCart_Click(object sender, EventArgs e)
        {
            string ord_id = Server.UrlDecode(Request.QueryString["order_id"]);
            string cid = Server.UrlDecode(Request.QueryString["id"]);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "delete from Orders where Order_ID ='" + ord_id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            string strSQL = "SELECT * FROM Orders";

            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

            XmlDocument doc = new XmlDocument();

            DataSet ds = new DataSet("Orders");

            dt.Fill(ds, "Order");

            ds.WriteXml(Server.MapPath(@".\xml\orders.xml"));

            Response.Redirect("Cart.aspx?id=" + cid);

        }
        bool ReturnValue()
        {
            return false;
        }
    }
}