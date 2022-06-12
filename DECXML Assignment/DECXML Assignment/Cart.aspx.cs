using System;
using System.Collections;
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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                ClientScriptManager CSM = Page.ClientScript;
                if (!ReturnValue())
                {
                    string strconfirm = "<script>if(!window.confirm('Please LOGIN to active this function!')){window.location.href='MainPage.aspx'}else{window.location.href='Login.aspx'}</script>";
                    CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
                }
            }
        }
        public string fetchCart()
        {
            if (Request.QueryString["id"] == null)
            {
                return "Error";
            }
            else
            {
                string id = Request.QueryString["id"].ToString();
                string htmlStr = "";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string query = "select Orders.*, Product.* from Orders INNER JOIN Product on Orders.Prod_ID = Product.Prod_ID where Cust_ID = '" + id + "' and Status = 'UnPaid'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Order_ID = reader.GetString(0);
                        string Cust_ID = reader.GetString(1);
                        string Prod_ID = reader.GetString(2);
                        string Status = reader.GetString(3);
                        int Quantity = reader.GetInt32(4);
                        int Total_Price = reader.GetInt32(5);
                        string Prod_Name = reader.GetString(7);
                        string Prod_Description = reader.GetString(8);
                        string Prod_Category = reader.GetString(9);
                        int Prod_Price = reader.GetInt32(10);
                        int Prod_Stock = reader.GetInt32(11);
                        string Prod_Image = reader.GetString(12);
                        htmlStr += "<tr><td class='cart_product_img'> " +
                            "<a href = '#' ><img src='" + Prod_Image + "' height='100px' width='100px' alt=''></a></td>" +
                            "<td class='cart_product_desc'>" +
                            "<a href=EditCart.aspx?order_id=" + Order_ID + "&id=" + id + "&prod_id=" + Prod_ID + " class='tm - product - edit - link'><i style='align-items:inherit;font-size:24px;color: #0645ad;' class='fas fa-edit tm-product-edit-icon'></i></a><span> " + Prod_Name + " </span></td>" +
                            "<td class='price'>" +
                            "<span>RM " + Prod_Price + "</span></td>" +
                            "<td>" +
                            "<span>" + Quantity + "</span></td>" +
                            "</td></tr>";
                    }
                }
                else
                {
                    htmlStr += "<tr><td><h5 style='padding:5px;font-weight:bold'>Your Cart Are Empty!</h5></td></tr>";
                }

                con.Close();
                return htmlStr;
            }
            
        }
        public string fetchItem()
        {
            if (Request.QueryString["id"] == null)
            {
                return "Error";
            }
            else
            {
                string id = Request.QueryString["id"].ToString();
                string htmlStr = "";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string query = "select Orders.*, Product.* from Orders INNER JOIN Product on Orders.Prod_ID = Product.Prod_ID where Cust_ID = '" + id + "' and Status = 'UnPaid'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string Order_ID = reader.GetString(0);
                    string Cust_ID = reader.GetString(1);
                    string Prod_ID = reader.GetString(2);
                    string Status = reader.GetString(3);
                    int Quantity = reader.GetInt32(4);
                    int Total_Price = reader.GetInt32(5);
                    string Prod_Name = reader.GetString(7);
                    string Prod_Description = reader.GetString(8);
                    string Prod_Category = reader.GetString(9);
                    int Prod_Price = reader.GetInt32(10);
                    int Prod_Stock = reader.GetInt32(11);
                    string Prod_Image = reader.GetString(12);
                    htmlStr += "<span> " +  Prod_Name + " - RM " + Prod_Price + "&emsp;x" + Quantity + "&emsp;<span style='font-weight:bold;float:right; '>RM " + Total_Price + "</span></span></span><br />";
                }
                con.Close();
                return htmlStr;
            }
        }

        public string fetchTotal()
        {
            if (Request.QueryString["id"] == null)
            {
                return "Error";
            }
            else
            {
                string id = Request.QueryString["id"].ToString();
                string htmlStr = "";
                int total = 0;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string query = "select Orders.Total_Price from Orders where Cust_ID = '" + id + "' and Status = 'UnPaid'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    total = total + reader.GetInt32(0);      
                }
                htmlStr += "<span style='font-weight:bold'>RM " + total + "</span>";
                con.Close();
                return htmlStr;
            }
        }
        bool ReturnValue()
        {
            return false;
        }

        protected void btncheckout_click(object sender, EventArgs e)
        {
            try
            {
                string cid = Server.UrlDecode(Request.QueryString["id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string query1 = "select Order_ID from Orders where Cust_ID = '" + cid + "' and Status = 'UnPaid'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataReader reader = cmd1.ExecuteReader();
                ArrayList al = new ArrayList();
                while (reader.Read())
                {
                    Object[] values = new Object[reader.FieldCount];

                    reader.GetValues(values);

                    al.Add(values);
                }
                con.Close();

                List<string> columnValues = new List<string>();
                con.Open();
                foreach (Object[] row in al)
                {
                    foreach (object column in row)
                    {
                        SqlCommand cmd2 = new SqlCommand("Select TOP 1 Record_ID FROM OrderRecord ORDER BY convert(int,right(Record_ID, charindex('c', reverse(Record_ID)) -1 )) DESC", con);

                        string LastCode = (string)cmd2.ExecuteScalar();
                        string getID = LastCode.Split('c')[1];
                        int getIntID = Convert.ToInt32(getID);

                        string recid = "Rec" + (getIntID + 1).ToString();

                        string query3 = " insert into OrderRecord (Record_ID, Ord_ID, Cust_ID, Payment_Method, Date) values (@id, @ord_id, @cust_id, @payment_method, @date) ";
                        SqlCommand cmd3 = new SqlCommand(query3, con);
                        cmd3.Parameters.AddWithValue("@id", recid);
                        cmd3.Parameters.AddWithValue("@ord_id", column);
                        cmd3.Parameters.AddWithValue("@cust_id", cid);
                        cmd3.Parameters.AddWithValue("@payment_method", ddlpaymentmethod.SelectedItem.ToString());
                        cmd3.Parameters.AddWithValue("@date", DateTime.Today);
                        cmd3.ExecuteNonQuery();
                    }
                }
                con.Close();

                con.Open();
                string query = "update Orders set Status = 'Paid' where Cust_ID = '" + cid + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                string strSQL = "SELECT * FROM Orders";

                SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

                XmlDocument doc = new XmlDocument();

                DataSet ds = new DataSet("Orders");

                dt.Fill(ds, "Order");

                ds.WriteXml(Server.MapPath(@".\xml\orders.xml"));

                ClientScriptManager CSM = Page.ClientScript;
                if (!ReturnValue()) {
                    string strconfirm = "<script>if(!window.confirm('Payment Successful!')){window.location.href='MainPage.aspx?id=" + cid + "'}else{window.location.href='MainPage.aspx?id=" + cid + "'}</script>";
                    CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
                }
                    
                //Response.Redirect("MainPage.?id=" + cid);

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }

        }

    }
}