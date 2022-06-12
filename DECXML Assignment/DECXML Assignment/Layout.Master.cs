using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Assignment
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] == null)
            {
                string id = "guest";
            }
            else
            {
                string id = Request.QueryString["id"].ToString();
            }
        }
           
        protected void Home_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                string cid = Request.QueryString["id"].ToString();
                Response.Redirect("MainPage.aspx?id=" + cid);
            }
        }
        protected void Products_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ProductList.aspx");
            }
            else
            {
                string cid = Request.QueryString["id"].ToString();
                Response.Redirect("ProductList.aspx?id=" + cid);
            }
        }
        protected void AboutUs_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("AboutUs.aspx");
            }
            else
            {
                string cid = Request.QueryString["id"].ToString();
                Response.Redirect("AboutUs.aspx?id=" + cid);
            }
        }
        protected void ContactUs_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ContactUs.aspx");
            }
            else
            {
                string cid = Request.QueryString["id"].ToString();
                Response.Redirect("ContactUs.aspx?id=" + cid);
            }
        }
        protected void Cart_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Cart.aspx");
            }
            else
            {
                string cid = Request.QueryString["id"].ToString();
                Response.Redirect("Cart.aspx?id=" + cid);
            }
        }
        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}