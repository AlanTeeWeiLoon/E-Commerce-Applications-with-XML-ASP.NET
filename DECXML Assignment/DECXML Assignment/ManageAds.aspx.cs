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
    public partial class ManageAds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string fetchAds()
        {
            string htmlStr = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select * from Ads";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ID = reader.GetString(0);
                string ImageUrl = reader.GetString(1);
                string NavigateUrl = reader.GetString(2);
                string AlternateText = reader.GetString(3);
                string KeyWord = reader.GetString(4);
                string Caption = reader.GetString(5);
                htmlStr += "<tr><td>" + ID + "</td><td><a href = '"+ImageUrl+"' ><img src ='"+ImageUrl+"' alt ='" + AlternateText  + "' style =\"width:100px; height:100px\" /></a></td><td>" + NavigateUrl + "</td><td>" + AlternateText + "</td><td>" + KeyWord + "</td><td>" + Caption + "</td><td><a href=EditAds.aspx?id=" + ID + " class='tm - product - edit - link'><i class='fas fa-edit tm-product-edit-icon'></i></a></td></tr>";
            }
            con.Close();
            return htmlStr;

        }
    }
}