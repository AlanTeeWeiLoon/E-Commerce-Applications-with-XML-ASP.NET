<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="DECXML_Assignment.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
      <div class="shop_top">
		<div class="container">
			<div class="row">
				<div class="col-md-7">
				  <div class="map">
					<iframe width="100%" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265&amp;output=embed"></iframe><br><small><a href="https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265" style="color:#666;text-align:left;font-size:12px"></a></small>
				  </div>
				</div>
				<div class="col-md-5">
					<p class="m_8">DECXML designs for and with every sport athlete of all kinds. Creators, who love to change the game. We supply teams and individuals with athletic clothing pre-match. To stay focused. We design sports apparel that get you to the finish line. We design, innovate and iterate. Testing new technologies in action. Retro workout shoes inspire new streetwear essentials. Like NMD, Ozweego and our Firebird tracksuits. Now seen on the streets and the stages.</p>
					<div class="address">
				                <p>Address: Jalan Teknologi 5, Taman Teknologi Malaysia,</p>
						   		<p>57000, Kuala Lumpur, Malaysia</p>
				   		<p>Phone:(07) 662 1234</p>
				   		<p>Fax: (60) 12 345 6789</p>
				 	 	<p>Email: <span>DECXML@offical.com</span></p>
				   		<p>Follow on: <span>Facebook</span>, <span>Twitter</span></p>
				   </div>
				</div>
			</div>
			<div class="row">
				<div class="col-md-12 contact">
				  <form method="post" action="contact-post.html">
					  <h2>Got Question?</h2>
					<div class="to">
                        <asp:TextBox class="text" ID="txtName" runat="server" required="required" placeholder="Name" ></asp:TextBox>
						<asp:TextBox class="text" ID="txtEmail" runat="server" TextMode="SingleLine" required="required" placeholder="Email"></asp:TextBox>
						<asp:TextBox class="text" ID="txtSubject" runat="server" required="required" placeholder="Subject"></asp:TextBox >
					</div>
					<div class="text">
	                   <asp:TextBox ID="txtMessage" runat="server" required="required" TextMode="MultiLine" placeholder="Message"></asp:TextBox>
	                   <div class="form-submit">
                           <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
						   <asp:Label ID="lblStatus" runat="server" ForeColor="Black"></asp:Label>
			           </div>
	                </div>
	                <div class="clear"></div>
                   </form>
			     </div>
		    </div>
	     </div>
	   </div>
	  </div>
</asp:Content>
