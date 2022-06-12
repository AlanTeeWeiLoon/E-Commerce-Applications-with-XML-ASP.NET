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
    public partial class selectedProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["prod_id"] == null)
            {
                Response.Redirect("ProductList.aspx");
            }
            else {
                string prod_id = Request.QueryString["prod_id"].ToString();
                System.Diagnostics.Debug.WriteLine(prod_id);
            }

        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null)
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
                else
                {
                    //string ProdID = Request.QueryString["prod_id"].ToString();

                    //string cid = Request.QueryString["id"].ToString();

                    string Prod_ID = Server.UrlDecode(Request.QueryString["prod_id"]);

                    string cid = Server.UrlDecode(Request.QueryString["id"]);

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

                    LinkButton btn = (LinkButton)sender;
                    DataListItem item = (DataListItem)btn.NamingContainer;
                    TextBox txt = (TextBox)item.FindControl("txtQuantity");
                    int qty = Int32.Parse(txt.Text);
                    int total = 0;
                    if (al.Count > 0)
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("Select Prod_Price FROM Product where Prod_ID='" + Prod_ID + "'", con);
                        SqlDataReader reader1 = cmd2.ExecuteReader();
                        while (reader1.Read())
                        {
                            total = reader1.GetInt32(0) * qty;
                        }
                        con.Close();

                        con.Open();
                        string query4 = "update Orders set Quantity =" + qty + ", Total_Price = " + total + " where Cust_ID = '" + cid + "' and Prod_ID = '" + Prod_ID + "' and Status = 'UnPaid'";
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

                        SqlDataAdapter da1 = new SqlDataAdapter("select Prod_Price from Product where Prod_ID = '" + Prod_ID + "'", con);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        int prod_price = Int16.Parse(dt1.Rows[0][0].ToString());

                        total = prod_price * qty;

                        //upload the content to table order
                        string query3 = " insert into Orders (Order_ID, Cust_ID, Prod_ID, Status, Quantity, Total_PrIce) values (@id, @cid, @pid, @status, @qty, @total) ";
                        SqlCommand cmd3 = new SqlCommand(query3, con);
                        cmd3.Parameters.AddWithValue("@id", orderid);
                        cmd3.Parameters.AddWithValue("@cid", cid);
                        cmd3.Parameters.AddWithValue("@pid", Prod_ID);
                        cmd3.Parameters.AddWithValue("@status", "UnPaid");
                        cmd3.Parameters.AddWithValue("@qty", qty);
                        cmd3.Parameters.AddWithValue("@total", total);

                        cmd3.ExecuteNonQuery();
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
