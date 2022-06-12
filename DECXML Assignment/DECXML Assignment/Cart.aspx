<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="DECXML_Assignment.Cart" %>
<asp:content contentplaceholderid="head" runat="server">

    <link rel="stylesheet" href="cartcss/core-style.css">
    <link rel="stylesheet" href="cartcss/style.css">
    <script src="cartjs/jquery/jquery-2.2.4.min.js"></script>
    <!-- Popper js -->
    <script src="cartjs/popper.min.js"></script>
    <!-- Bootstrap js -->
    <script src="cartjs/bootstrap.min.js"></script>
    <!-- Plugins js -->
    <script src="cartjs/plugins.js"></script>
    <!-- Active js -->
    <script src="cartjs/active.js"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
</asp:content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- ##### Main Content Wrapper Start ##### -->
    <div class="main-content-wrapper d-flex clearfix">
        <div class="cart-table-area " style="padding-bottom:30px">
            <div class="container-fluid" style="margin-left:20%;margin-right:20%">
                <div class="row">
                    <div class="col-12 col-lg-8">
                        <div class="cart-title mt-50">
                            <h2 style="font-weight:bold">Shopping Cart</h2>
                        </div>

                        <div class="cart-table clearfix">
                            <table class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th style="font-weight:bold">Name</th>
                                        <th style="font-weight:bold">Price</th>
                                        <th style="font-weight:bold">Quantity</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%=fetchCart()%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="col-12 col-lg-4">
                        <div class="cart-summary">
                            <h5>Cart Total</h5>
                            <ul class="summary-table">
                                <div><span>Items:</span><br /> <%=fetchItem()%><br /></div>
                                <li><span>delivery:</span> <span>Free</span></li>
                                <li><span>Total:</span> <span><%=fetchTotal()%></span></li>     
                            </ul>
                            <div>
                                <h6>Choose Payment Method:</h6>
                                <asp:DropDownList ID="ddlpaymentmethod" runat="server">
                                    <asp:ListItem>E-wallet</asp:ListItem>
                                    <asp:ListItem>Debit/Credit Card</asp:ListItem>
                                    <asp:ListItem>Online Banking</asp:ListItem>
                                 </asp:DropDownList>
                            </div>
                           
                            <div class="cart-btn mt-100">
                                <asp:LinkButton ID="btnCheckOut" class="btn amado-btn w-100" runat="server" OnClick="btncheckout_click"><span>Checkout</span></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ##### Main Content Wrapper End ##### -->
</asp:Content>
