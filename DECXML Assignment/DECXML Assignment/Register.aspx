<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DECXML_Assignment.Register1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
      <div class="shop_top">
	     <div class="container">
				<form> 
					<div class="register-top-grid">
						<h3>INFORMATION REQUIRED</h3>
						<div>
							<span>Name<label>*</label></span>
							<asp:TextBox ID="txtName" runat="server" class="inputbox" autocomplete="off" TextMode="SingleLine" required="required"></asp:TextBox>
						</div>
						<div>
							<span>Email Address<label>*</label></span>
							<asp:TextBox ID="txtEmail" runat="server" class="inputbox" autocomplete="off" TextMode="Email" required="required"></asp:TextBox>
						</div>
						<div>
							<span>Age<label>*</label></span>
							<asp:TextBox ID="txtAge" runat="server" class="inputbox" autocomplete="off" TextMode="SingleLine" required="required"></asp:TextBox>
						</div>
						<div>
							<span>Address<label>*</label></span>
							<asp:TextBox ID="txtAddress" runat="server" class="inputbox" autocomplete="off" TextMode="SingleLine" required="required"></asp:TextBox>
						</div>
						<div>
							<span>Password<label>*</label></span>
							<asp:TextBox ID="txtPassword" runat="server" class="inputbox" TextMode="Password" required="required"></asp:TextBox>
						</div>
						<div>
							<span>Confirm Password<label>*</label></span>
							<asp:TextBox ID="txtConfirmPassword" runat="server" class="inputbox" TextMode="Password" required="required" ></asp:TextBox>
						</div>
						<asp:CompareValidator ID="CompareValidator1" runat="server" SetFocusOnError="True" ErrorMessage="Password not same" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" EnableClientScript="False" style="font-size: xx-small; color: #FF3300"></asp:CompareValidator>
							<div class="clear"> </div>
							<asp:Button ID="btnRegister" runat="server" Text="Register" class="buttonRegister" OnClick="btnRegister_Click"/>
						<asp:Label ID="lblStatus" runat="server" ForeColor="Black"></asp:Label>
					</div>			
				</form>
			</div>
		  </div>
	  </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Customer]"></asp:SqlDataSource>
</asp:Content>
