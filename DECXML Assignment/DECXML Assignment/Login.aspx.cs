using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECXML_Assignment
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text == "admin@gmail.com" & txtPassword.Text == "admin")
            {
                Session["ID"] = "admin";
                Session["Name"] = "admin";
                if (txtEmail.Text.Trim() != String.Empty && txtPassword.Text.Trim() != String.Empty)
                {
                    Users u = new Users();

                    if (u.userVerification(txtEmail.Text.Trim(), txtPassword.Text.Trim()))
                    {
                        this.Session["Username"] = txtEmail.Text.Trim();

                        positionEnum userPosition = u.getUserPosition(txtEmail.Text.Trim());
                        if (userPosition == positionEnum.Admin)
                        {
                            this.Session["Position"] = "Admin";
                            Response.Redirect("AdminHome.aspx", false);
                        }
                        else
                        {
                            this.Session["Position"] = "none";
                            Response.Redirect("Login.aspx", false);
                        }
                    }
                    else
                    {
                        lblStatus.Text = "Invalid Username or Password!";
                    }
                }
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from Customer where Cust_Email = '" +
                    txtEmail.Text + "' and Cust_Password ='" + txtPassword.Text + "'", con);
                int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (count > 0)
                {
                    if (txtEmail.Text.Trim() != String.Empty && txtPassword.Text.Trim() != String.Empty)
                    {
                        Users u = new Users();

                        if (u.userVerification(txtEmail.Text.Trim(), txtPassword.Text.Trim()))
                        {
                            this.Session["Username"] = txtEmail.Text.Trim();

                            positionEnum userPosition = u.getUserPosition(txtEmail.Text.Trim());
                            if (userPosition == positionEnum.User)
                            {
                                this.Session["Position"] = "User";
                                string query = "select * from Customer where Cust_Email ='" + txtEmail.Text + "'";
                                SqlCommand cmd1 = new SqlCommand(query, con);
                                SqlDataReader reader = cmd1.ExecuteReader();
                                while (reader.Read())
                                {
                                    Session["ID"] = reader.GetString(0);
                                    Session["Name"] = reader.GetString(1);

                                    Response.Redirect("MainPage.aspx?id=" + reader.GetString(0));
                                }
                            }
                            else
                            {
                                this.Session["Position"] = "none";
                                Response.Redirect("Login.aspx", false);
                            }
                        }
                        else
                        {
                            lblStatus.Text = "Invalid Username or Password!";
                        }
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Login Failed.');</script>");
                }

                con.Close();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}