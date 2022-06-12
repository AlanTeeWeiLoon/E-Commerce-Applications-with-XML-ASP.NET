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
    public partial class ViewCategory : System.Web.UI.Page
    {
        public string strCategories = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _strquery = "Select * from Category";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataSet ds = new DataSet("Categories");
            SqlDataAdapter da = new SqlDataAdapter(_strquery, con);
            da.Fill(ds,"category");
            //Get theXML From DataSet
            string strXML = ds.GetXml();

            strCategories = GetHtml(Server.MapPath("~/xsl/viewcategory.xsl"), strXML);
            
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