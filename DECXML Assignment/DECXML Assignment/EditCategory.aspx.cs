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
    public partial class EditCategory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public static string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null || !Session["ID"].Equals("admin"))
                Response.Redirect("Login.aspx");
            id = Convert.ToString(Request.QueryString["catid"]);
            if (!IsPostBack)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Category where Category_ID = '" + id + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtCategoryName.Text = dt.Rows[0][1].ToString();
                txtCategoryDescription.Text = dt.Rows[0][2].ToString();
            }
        }
        protected void btnEditCategory_Click(object sender, EventArgs e)
        {
            con.Open();
            id = Convert.ToString(Request.QueryString["catid"]);
            string query = "update Category set Category_Name = '" + txtCategoryName.Text + "', Category_Description = '" + txtCategoryDescription.Text + "' where Category_ID = '" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            lblMessage.Text = "Category Edited Successfully";
            con.Close();

            string strSQL = "SELECT * FROM Category";

            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

            XmlDocument doc = new XmlDocument();

            DataSet ds = new DataSet("Categories");

            dt.Fill(ds, "Category");

            ds.WriteXml(Server.MapPath(@".\xml\categories.xml"));
        }

        protected void btn_deleteCategory_Click(object sender, EventArgs e)
        {
            con.Open();
            id = Convert.ToString(Request.QueryString["catid"]);
            string query = "delete from Category where Category_ID ='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            lblMessage.Text = "Category Deleted";
            con.Close();

            string strSQL = "SELECT * FROM Category";

            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

            XmlDocument doc = new XmlDocument();

            DataSet ds = new DataSet("Categories");

            dt.Fill(ds, "Category");

            ds.WriteXml(Server.MapPath(@".\xml\categories.xml"));

            Response.Redirect("ViewCategory.aspx");
        }
    }
}