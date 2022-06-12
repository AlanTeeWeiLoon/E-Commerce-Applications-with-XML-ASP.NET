using System;
using System.Collections;
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
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public string fetchProduct()
        //{
        //    string htmlStr = "";
        //    int a = 0;
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    con.Open();
        //    string query = "select * from Product";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        string ID = reader.GetString(0);
        //        string ProductName = reader.GetString(1);
        //        string ProductDescription = reader.GetString(2);
        //        string ProductCategory = reader.GetString(3);
        //        int ProductPrice = reader.GetInt32(4);
        //        int ProductStock = reader.GetInt32(5);
        //        string ProductImage = reader.GetString(6);
        //        if (a == 0)
        //        {
        //            htmlStr += "<div class='row'>" +
        //            "<div class='col-md-3 shop_box'><a href = selectedProduct.aspx?id=" + ID + "> " +
        //            "<img src='" + ProductImage + "' class='img-responsive' alt=''/" +
        //            "<div class='shop_desc'> " +
        //            "<h3><a href = selectedProduct.aspx?id=" + ID + ">" + ProductName + " </a></h3>" +
        //            "<p>" + ProductDescription + "</p>" +
        //            "<span>" + "RM" + ProductPrice + "</span>" +
        //            "<ul class='buttons'>" +
        //            "<li class='cart'><a href = Cart.aspx?id=" + ID + ">" + "Add To Cart</a></li>" +
        //            "<div class='clear'> </div></ul></div></a></div>";
        //        }
        //        else if (a % 4 == 0 && a != 0 )
        //        {
        //            htmlStr += "</div><div class='row'>" +
        //            "<div class='col-md-3 shop_box'><a href = selectedProduct.aspx?id=" + ID + "> " +
        //            "<img src='" + ProductImage + "' class='img-responsive' alt=''/" +
        //            "<div class='shop_desc'> " +
        //            "<h3><a href = selectedProduct.aspx?id=" + ID + ">" + ProductName + " </a></h3>" +
        //            "<p>" + ProductDescription + "</p>" +
        //            "<span>" + "RM" + ProductPrice + "</span>" +
        //            "<ul class='buttons'>" +
        //            "<li class='cart'><a href = Cart.aspx?id=" + ID + ">" + "Add To Cart</a></li>" +
        //            "<div class='clear'> </div></ul></div></a></div>";
        //        }
        //        else
        //        {
        //            htmlStr += "<div class='col-md-3 shop_box'><a href = selectedProduct.aspx?id=" + ID + "> " +
        //            "<img src='" + ProductImage + "' class='img-responsive' alt=''/" +
        //            "<div class='shop_desc'> " +
        //            "<h3><a href = selectedProduct.aspx?id=" + ID + ">" + ProductName + " </a></h3>" +
        //            "<p>" + ProductDescription + "</p>" +
        //            "<span>" + "RM" + ProductPrice + "</span>" +
        //            "<ul class='buttons'>" +
        //            "<li class='cart'><a href = Cart.aspx?id=" + ID + ">" + "Add To Cart</a></li>" +
        //            "<div class='clear'> </div></ul></div></a></div></div>";
        //        }
        //        a++;    
      
        //    }
        //    con.Close();
        //    return htmlStr;

        //}
        protected void ProductImage_Click(object sender, EventArgs e) {

            if (Request.QueryString["id"] == null)
            {
                string Prod_ID = (sender as HtmlAnchor).Name.ToString();
                Response.Redirect("selectedProduct.aspx?prod_id=" + Prod_ID);
            }
            else
            {
                string id = Request.QueryString["id"].ToString();
                string Prod_ID = (sender as HtmlAnchor).Name.ToString();
                Response.Redirect(String.Format("selectedProduct.aspx?prod_id={0}&id={1}", Server.UrlEncode(Prod_ID), Server.UrlEncode(id)));
                //Response.Redirect("selectedProduct.aspx?prod_id=" + Prod_ID + "&?id="+ id);
            }
        }
        protected void Product_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] == null)
            {
                string Prod_ID = (sender as HtmlAnchor).Name.ToString();
                Response.Redirect("selectedProduct.aspx?prod_id=" + Prod_ID);
            }
            else
            {
                string id = Request.QueryString["id"].ToString();
                string Prod_ID = (sender as HtmlAnchor).Name.ToString();
                Response.Redirect("selectedProduct.aspx?prod_id=" + Prod_ID + "&?id=" + id);
            }
        }
        protected void AddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"]== null)
                {
                    {
                        ClientScriptManager CSM = Page.ClientScript;
                        if (!ReturnValue())
                        {
                            string strconfirm = "<script>if(!window.confirm('Please LOGIN to active this function!')){window.location.href='ProductList.aspx'}else{window.location.href='Login.aspx'}</script>";
                            CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
                        }
                    }
                }
                else {
                    string Prod_ID = (sender as HtmlAnchor).Name.ToString();

                    string cid = Request.QueryString["id"].ToString();

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    string query1 = "select Quantity from Orders where Cust_ID = '" + cid + "' and Prod_ID = '" + Prod_ID + "' and Status = 'UnPaid'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    ArrayList al = new ArrayList();
                    if (reader.Read())
                    {
                        Object[] values = new Object[reader.FieldCount];

                        reader.GetValues(values);

                        al.Add(values);
                    }
                    con.Close();

                    int qty = 0;
                    if (al.Count>0)
                    {
                        foreach (Object[] row in al)
                        {
                            foreach (object column in row)
                            {
                                 qty = Int32.Parse(column.ToString()) + 1;
                            }
                        }
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("Select Prod_Price FROM Product where Prod_ID='" + Prod_ID + "'", con);
                        SqlDataReader reader1 = cmd2.ExecuteReader();
                        int total = 0;
                        while (reader1.Read())
                        {
                            total = reader1.GetInt32(0)* qty;
                        }
                        con.Close();

                        con.Open();
                        string query4 = "update Orders set Quantity =" + qty + ", Total_Price = " + total + " where Cust_ID = '" + cid + "' and Prod_ID = '"+ Prod_ID + "' and Status = 'UnPaid'";
                        SqlCommand cmd4 = new SqlCommand(query4, con);
                        cmd4.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select TOP 1 Order_ID FROM Orders ORDER BY convert(int,right(Order_ID, charindex('d', reverse(Order_ID)) -1 )) DESC", con);

                        string LastCode = (string)cmd.ExecuteScalar();
                        string getID = LastCode.Split('d')[1];
                        int getIntID = Convert.ToInt32(getID);


                        string orderid = "Ord" + (getIntID + 1).ToString();

                        SqlCommand cmd2 = new SqlCommand("Select Prod_Price FROM Product where Prod_ID='"+ Prod_ID +"'", con);
                        SqlDataReader reader1 = cmd2.ExecuteReader();
                        int total = 0;
                        while (reader1.Read())
                        {
                            total = reader1.GetInt32(0);
                        }
                        con.Close();

                        con.Open();

                        //upload the content to table order
                        string query5 = " insert into Orders (Order_ID, Cust_ID, Prod_ID, Status, Quantity, Total_PrIce) values (@id, @cid, @pid, @status, @qty, @total) ";
                        SqlCommand cmd5 = new SqlCommand(query5, con);
                        cmd5.Parameters.AddWithValue("@id", orderid);
                        cmd5.Parameters.AddWithValue("@cid", cid);
                        cmd5.Parameters.AddWithValue("@pid", Prod_ID);
                        cmd5.Parameters.AddWithValue("@status", "UnPaid");
                        cmd5.Parameters.AddWithValue("@qty", 1);
                        cmd5.Parameters.AddWithValue("@total", total);

                        cmd5.ExecuteNonQuery();
                        con.Close();
                    }

                    string strSQL = "SELECT * FROM Orders";

                    SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

                    XmlDocument doc = new XmlDocument();

                    DataSet ds = new DataSet("Orders");

                    dt.Fill(ds, "Order");

                    ds.WriteXml(Server.MapPath(@".\xml\orders.xml"));

                    Response.Redirect("Cart.aspx?id=" + cid);
                }
               
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
            
        }

        bool ReturnValue()
        {
            return false;
        }
    }
}