using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace DECXML_Assignment
{
    public partial class AdminHome : System.Web.UI.Page
    {
        public string strRecords = string.Empty;
        public string strFeedbacks = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _strquery = "Select OrderRecord.*, Customer.Cust_Name, Orders.Quantity, Orders.Prod_ID, Orders.Total_Price, Product.Prod_Name from OrderRecord INNER JOIN Customer ON OrderRecord.Cust_ID = Customer.Cust_ID INNER JOIN Orders ON OrderRecord.Ord_ID = Orders.Order_ID INNER JOIN Product on Orders.Prod_ID = Product.Prod_ID";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataSet ds = new DataSet("Orders");
            SqlDataAdapter da = new SqlDataAdapter(_strquery, con);
            da.Fill(ds, "Order");
            //Get theXML From DataSet
            string strXML = ds.GetXml();

            strRecords = GetHtml(Server.MapPath("~/xsl/viewrecord.xsl"), strXML);

            //Get theXML From DataSet
            DataSet ds2 = new DataSet();
            ds2.ReadXml(Server.MapPath("~/xml/Feedbacks.xml"));
            string strXML1 = ds2.GetXml();

            strFeedbacks = GetHtml(Server.MapPath("~/xsl/viewfeedback.xsl"), strXML1);
        }

        public static string GetHtml(string xsltPath, string xml)
        {
            MemoryStream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(xml));
            XPathDocument document = new XPathDocument(stream);
            StringWriter writer = new StringWriter();
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(xsltPath);
            transform.Transform(document, null, writer);
            return writer.ToString();
        }
    }
}