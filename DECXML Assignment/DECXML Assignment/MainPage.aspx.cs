using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Assignment
{
    public partial class MainPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                lblName.Text = Session["Name"].ToString();
            }
            else
            {
                lblName.Text = "Valued Guest";
            }
            
        }
    }
}