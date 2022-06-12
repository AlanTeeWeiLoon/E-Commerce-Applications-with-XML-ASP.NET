<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="DECXML_Assignment.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="shop_top">
            <div class="container">
                <div class="content-top-spe">
                    <h2>Sport Shoes</h2>
                    <p>DECXML EXTREME SERIES</p>
                </div>
                <asp:DataList ID="DataList1" runat="server" class="w-100" RepeatColumns="5" RepeatDirection="Horizontal" Style="margin-left: auto; margin-right: auto; margin-top: 10px; margin-bottom: 25px" DataSourceID="XmlDataSource2">
                    <ItemTemplate>
                        <div class="col-md-12-spe shop_box">
                            <a href="#" runat="server" onserverclick="ProductImage_Click" name='<%# XPath("Prod_ID") %>'>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# XPath("Prod_Image") %>' class="imgprod-spe" />
                                <div class="shop_desc">
                                    <p><%# XPath("Prod_ID") %></p>
                                    <h3><a href="#" runat="server" onserverclick="Product_Click" name='<%# XPath("Prod_ID") %>'><%# XPath("Prod_Name") %></a></h3>
                                    <p><%# XPath("Prod_Description") %></p>
                                    <span class="actual">RM<%# XPath("Prod_Price") %></span><br>
                                    <ul class="buttons">
                                        <li class="cart"><a href="#" runat="server" onserverclick="AddToCart_Click" name='<%# XPath("Prod_ID") %>'>Add To Cart</a></li>
                                        <div class="clear"></div>
                                    </ul>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
    <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/xml/products.xml"></asp:XmlDataSource>
</asp:Content>
