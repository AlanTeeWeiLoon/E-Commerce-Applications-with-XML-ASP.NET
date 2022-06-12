<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ViewCategory.aspx.cs" Inherits="DECXML_Assignment.ViewCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding:5%">
            <table>
                <tr>
                    <td>
                        <b style="font-size:30px">Category</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="font-size:15px;color:aliceblue"><b style="font-size:15px;color:red">*</b>Category Allow You To Select While Adding Product !</p>
                        <%= strCategories %>
                    </td>
                </tr>
            </table>
        </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
</asp:Content>
