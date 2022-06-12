using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace DECXML_Assignment
{
    public class Users
    {
        XmlDocument xDoc;

        public Users()
        {
            xDoc = new XmlDocument();
            xDoc.Load(HttpContext.Current.Server.MapPath("~\\xml\\Users.xml"));
        }

        public bool userVerification(string email, string password)
        {
            XmlNodeList xNodes = xDoc.SelectNodes("Users/User");
            for (int count = 0; count < xNodes.Count; count++)
            {
                if (email == xNodes.Item(count).Attributes.GetNamedItem("email").Value && password == xNodes.Item(count).SelectSingleNode("password").InnerText)
                {
                    return true;
                }
            }
            return false;
        }

        public positionEnum getUserPosition(string email)
        {
            XmlNodeList xNodes = xDoc.SelectNodes("Users/User");

            for (int count = 0; count < xNodes.Count; count++)
            {
                if (email == xNodes.Item(count).Attributes.GetNamedItem("email").Value)
                {
                    if (xNodes.Item(count).SelectSingleNode("position").InnerText == "Admin")
                    {
                        return positionEnum.Admin;
                    }
                    else if (xNodes.Item(count).SelectSingleNode("position").InnerText == "User")
                    {
                        return positionEnum.User;
                    }
                }
            }
            return positionEnum.none;
        }

        public bool registerUser(string name, string email, string age, string address, string password, positionEnum position)
        {
            try
            {
                XmlNodeList xNodes = xDoc.SelectNodes("Users/User");
                for (int count = 0; count < xNodes.Count; count++)
                {
                    if (email == xNodes.Item(count).Attributes.GetNamedItem("email").Value)
                    {
                        return false;
                    }
                }

                XmlNode rootNode = xDoc.CreateElement("User");

                XmlAttribute userAttribute = xDoc.CreateAttribute("email");
                userAttribute.Value = email;
                rootNode.Attributes.Append(userAttribute);

                XmlNode nameNode = xDoc.CreateElement("name");
                nameNode.InnerText = name;

                XmlNode ageNode = xDoc.CreateElement("age");
                ageNode.InnerText = age;

                XmlNode addressNode = xDoc.CreateElement("address");
                addressNode.InnerText = address;

                XmlNode passNode = xDoc.CreateElement("password");
                passNode.InnerText = password;

                XmlNode positionNode = xDoc.CreateElement("position");

                if (position == positionEnum.Admin)
                {
                    positionNode.InnerText = "Admin";
                }
                else if (position == positionEnum.User)
                {
                    positionNode.InnerText = "User";
                }
                else
                {
                    positionNode.InnerText = "none";
                }

                rootNode.AppendChild(nameNode);
                rootNode.AppendChild(ageNode);
                rootNode.AppendChild(addressNode);
                rootNode.AppendChild(passNode);
                rootNode.AppendChild(positionNode);

                xDoc.SelectSingleNode("Users").AppendChild(rootNode);
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

    public enum positionEnum
    {
        Admin,
        User,
        none
    }
}