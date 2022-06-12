using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace DECXML_Assignment
{
    public class Feedbacks
    {
        XmlDocument xDoc;
        public Feedbacks()
        {
            xDoc = new XmlDocument();
            xDoc.Load(HttpContext.Current.Server.MapPath("~\\xml\\Feedbacks.xml"));
        }
        public bool addfeedback(string feedback_id, string name, string email, string subject, string message, string date)
        {
            try
            {
                XmlNode rootNode = xDoc.CreateElement("Feedback");

                XmlNode idNode = xDoc.CreateElement("feedback_id");
                idNode.InnerText = feedback_id;

                XmlNode nameNode = xDoc.CreateElement("name");
                nameNode.InnerText = name;

                XmlNode emailNode = xDoc.CreateElement("email");
                emailNode.InnerText = email;

                XmlNode subjectNode = xDoc.CreateElement("subject");
                subjectNode.InnerText = subject;

                XmlNode messageNode = xDoc.CreateElement("message");
                messageNode.InnerText = message;

                XmlNode dateNode = xDoc.CreateElement("date");
                dateNode.InnerText = date;

                rootNode.AppendChild(idNode);
                rootNode.AppendChild(nameNode);
                rootNode.AppendChild(emailNode);
                rootNode.AppendChild(subjectNode);
                rootNode.AppendChild(messageNode);
                rootNode.AppendChild(dateNode);

                xDoc.SelectSingleNode("Feedbacks").AppendChild(rootNode);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public XmlDocument getXmlDocument()
        {
            return this.xDoc;
        }
    }
}