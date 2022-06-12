<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="selectedProduct.aspx.cs" Inherits="DECXML_Assignment.selectedProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="shop_top">
            <div class="container">
                <div class="row">
                    <asp:DataList ID="DataList1" Width="100%" runat="server" DataSourceID="SqlDataSource1" DataKeyField="Prod_ID">
                        <ItemTemplate>
                            <div class="col-md-9 single_left">
                                <div class="single_image">
                                    <a href='<%# Eval("Prod_Image") %>'>
                                        <img width="220" height="220" src="<%# Eval("Prod_Image") %>" />
                                    </a>
                                </div>
                                <div class="single_right">
                                    <h3><%# Eval("Prod_Name") %></h3>
                                    <p class="m_10"><%# Eval("Prod_Description") %></p>
                                    <ul class="options">
                                        <h4 class="m_12">Category</h4>
                                        <li><a href="#"><%# Eval("Prod_Category") %></a></li>
                                    </ul>
<%--                                    <div class="btn_form">
                                        <form>
                                            <input type="submit" value="buy now" title="">
                                        </form>
                                    </div>--%>
                                    <div class="social_buttons">
                                        <h4>Stock Left : <%# Eval("Prod_Stock") %></h4>
                                        <button id="btn_twitter" type="button" class="btn1 btn1-default1 btn1-twitter" onclick="location.href = 'https://twitter.com/';">
                                            <i class="icon-twitter"></i>Tweet
                                        </button>
                                        <button id="btn_facebook" type="button" class="btn1 btn1-default1 btn1-facebook" onclick="location.href = 'https://www.facebook.com/';">
                                            <i class="icon-facebook"></i>Share
                                        </button>
                                        <button id="btn_google" type="button" class="btn1 btn1-default1 btn1-google" onclick="location.href = 'https://www.google.com/';">
                                            <i class="icon-google"></i>Google+
                                        </button>
                                        <button id="btn_pinterest" type="button" class="btn1 btn1-default1 btn1-pinterest" onclick="location.href = 'https://www.pinterest.com/';">
                                            <i class="icon-pinterest"></i>Pinterest
                                        </button>
                                    </div>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="col-md-3-spe">
                                <div class="box-info-product">
                                    <p class="price2">RM<%# Eval("Prod_Price") %></p>
                                    <ul class="prosuct-qty">
                                        <span>Quantity:</span>
                                        <p style="color: red"><%# Eval("Prod_Stock") %> left!</p>
                                        <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" Text="1"></asp:TextBox>
                                        <asp:RangeValidator runat="server" ControlToValidate="txtQuantity" ErrorMessage="Not Enough Stock!" Type="Integer" MinimumValue="1" MaximumValue='<%# Eval("Prod_Stock") %>' ForeColor="Red"></asp:RangeValidator>
                                    </ul>
                                    <asp:LinkButton ID="btnAddtoCart" class="exclusive" runat="server" OnClick="btnAddtoCart_Click"><span>Add to cart</span></asp:LinkButton>
                                </div>
                            </div>
                            </div>	
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Product] WHERE ([Prod_ID] = @Prod_ID)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="Prod_ID" QueryStringField="prod_id" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/xml/products.xml" XPath='/Products/Product/[contains(Prod_ID,"<%=Request.QueryString["prod_id"] %>")]'></asp:XmlDataSource>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
