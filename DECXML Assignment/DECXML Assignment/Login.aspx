<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DECXML_Assignment.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
      <div class="shop_top">
		<div class="container">
			<div class="col-md-6">
				 <div class="login-page">
					<h4 class="title">New Customers</h4>
					<p>DECXML is an online e-commerce that mainly sells sports shoes. Our platform is reliable and secure, providing you with a quality browsing experience. We provide hundreds of sports shoes, including men's, women's and kids. If you want to experience more discounts and browsing experience, please click the button below to create a new account and let us lead you. Thank you!</p>
					<div class="button1">
						<asp:Button ID="btnRegister" runat="server" Text="Create an Account" class="button" OnClick="btnRegister_Click" />
					 </div>
					 <div class="clear"></div>
				  </div>
				</div>
				<div class="col-md-6">
				 <div class="login-title">
	           		<h4 class="title">Registered Customers</h4>
					<div id="loginbox" class="loginbox">
						<form action="" method="post" name="login" id="login-form">
						  <fieldset class="input">
						    <p id="login-form-username">
						      <label for="modlgn_username">Email</label>
                               <asp:TextBox ID="txtEmail" runat="server" class="inputbox" autocomplete="off" TextMode="Email" requireed="required"></asp:TextBox>
						    </p>
						    <p id="login-form-password">
						      <label for="modlgn_passwd">Password</label>
								<asp:TextBox ID="txtPassword" runat="server" class="inputbox" TextMode="Password" requireed="required"></asp:TextBox>
						    </p>
						    <div class="remember">
							    <%--<p id="login-form-remember">
									<asp:LinkButton ID="btnForget" runat="server" OnClick="btnForget_Click" style="font-size: medium">Forget Password?</asp:LinkButton>
							   </p>--%>
								<asp:Button ID="btnLogin" runat="server" Text="Login" class="button" OnClick="btnLogin_Click" />
								<asp:Label ID="lblStatus" runat="server"></asp:Label>
							 </div>
						  </fieldset>
						 </form>
					</div>
			      </div>
				 <div class="clear"></div>
			  </div>
			</div>
		  </div>
	  </div>
</asp:Content>
