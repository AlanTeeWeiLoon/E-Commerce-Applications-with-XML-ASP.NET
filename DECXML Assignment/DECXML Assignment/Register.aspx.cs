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
    public partial class Register1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "Select count(*) from Customer where Cust_Email = '" + txtEmail.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (check > 0)
                {
                    //check cannot have double same email(Response -> pop down a word)
                    Response.Write("<script type=\"text/javascript\">alert('Email already exist.');</script>");
                }
                else
                {
                    if (txtConfirmPassword.Text != txtPassword.Text)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Password and confirm password not same!');</script>");
                    }
                    else
                    {
                        Users userManager = new Users();
                        if (userManager.registerUser(txtName.Text.Trim(), txtEmail.Text.Trim(), txtAge.Text.Trim(), txtAddress.Text.Trim(), txtPassword.Text.Trim(), positionEnum.User))
                        {
                            XmlDocument xDoc = userManager.getXmlDocument();
                            xDoc.Save(MapPath("~\\xml\\Users.xml"));
                            this.lblStatus.Text = "New user register successfully!";
                        }
                        else
                        {
                            this.lblStatus.Text = "Error! User registration failed!";
                        }

                        SqlCommand cmd2 = new SqlCommand("Select TOP 1 Cust_ID FROM Customer ORDER  BY convert(int,right(Cust_ID, charindex('t', reverse(Cust_ID)) -1 )) DESC", con);

                        string LastCode = (string)cmd2.ExecuteScalar();
                        string getID = LastCode.Split('t')[1];
                        int getIntID = Convert.ToInt32(getID);


                        string custid = "Cust" + (getIntID + 1).ToString();
                        //Instantiate a new command with a query and connection
                        string query1 = "insert into Customer (Cust_ID, Cust_Name, Cust_Email,Cust_Password,Cust_Address, Cust_Age) values (@id, @name,@email,@password, @address, @age)";
                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        cmd1.Parameters.AddWithValue("@id", custid);
                        cmd1.Parameters.AddWithValue("@name", txtName.Text);
                        cmd1.Parameters.AddWithValue("@age", txtAge.Text);
                        cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd1.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd1.Parameters.AddWithValue("@address", txtAddress.Text);

                        //insert data into a database
                        cmd1.ExecuteNonQuery();

                        string strSQL = "SELECT * FROM Customer";

                        SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

                        XmlDocument doc = new XmlDocument();

                        DataSet ds = new DataSet("Customers");

                        dt.Fill(ds, "Customer");

                        ds.WriteXml(Server.MapPath(@".\xml\customers.xml"));

                        Response.Write("<script type=\"text/javascript\">alert('Registration Successful');</script>");
                        con.Close();
                        Session["ID"] = custid;
                        Response.Redirect("MainPage.aspx?id=" + custid);
                        txtName.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                    }
                    
                }

            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }
    }
}