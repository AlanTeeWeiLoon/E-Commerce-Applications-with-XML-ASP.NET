<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="DECXML_Assignment.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery.magnific-popup.js" type="text/javascript"></script>
    <link href="css/magnific-popup.css" rel="stylesheet" type="text/css">
    <script>
        $(document).ready(function () {
            $('.popup-with-zoom-anim').magnificPopup({
                type: 'inline',
                fixedContentPos: false,
                fixedBgPos: true,
                overflowY: 'auto',
                closeBtnInside: true,
                preloader: false,
                midClick: true,
                removalDelay: 300,
                mainClass: 'my-mfp-zoom-in'
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="shop_top">
            <div class="container">
                <div class="row team_box">
                    <h3 class="m_2">Our Teams</h3>
                    <div class="col-md-3 team1">
                        <a class="popup-with-zoom-anim" href="#small-dialog3">
                            <img src="images/teamimage1.png" class="img-responsive" title="continue" alt="" /></a>
                        <div id="small-dialog3" class="mfp-hide">
                            <div class="pop_up2">
                                <h2>DECXML</h2>
                                <p>XML designed to store and transport data. It was released in late 90’s. it was created to provide an easy to use and store self-describing data and became a W3C Recommendation on February 10, 1998. It is not a replacement for HTML. It designed to be self-descriptive. XML designed to carry data, not to display data. XML tags are not predefined. You must define your own tags. XML platform independent and language independent.</p>
                                <p>You can use it to take data from a program like Microsoft SQL, convert it into XML then share that XML with other programs and platforms. (Used to simplify data storage and data sharing.) You can communicate between two platforms which are generally very difficult. Many corporations use XML interfaces for databases, programming, office application mobile phones and more</p>
                            </div>
                        </div>
                        <h4 class="m_5"><a href="#">DECXML</a></h4>
                        <p>XML (Extensible Markup Language) is a Technology (rules) for creating markup languages.</p>
                    </div>
                    <div class="col-md-3 team1">
                        <a class="popup-with-zoom-anim" href="#small-dialog3">
                            <img src="images/teamimage2.jpg" class="img-responsive" title="continue" alt="" style="width: 262.5px; height: 220.21px" /></a>
                        <div id="small-dialog3" class="mfp-hide">
                            <div class="pop_up2">
                                <h2>Alan</h2>
                                <p>I am a degree year 2 student in Asia Pacific University (APU). I am expected to complete my studies in Bachelor of Information Technology (IT) with specialism of Business Information System in June of 2022.</p>
                                <p>DECXML Sport Shoe is an online e-commerce platform that focus on selling various sport shoes. I found this company and built this platform is to provide customer a user-friendly and secure online shoping platform.</p>
                            </div>
                        </div>
                        <h4 class="m_5"><a href="#">Founder: Alan</a></h4>
                        <p class="m_6">TEE WEI LOON - TP054897</p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 team_bottom">
                        <ul class="team_list">
                            <h4>Advantages</h4>
                            <li><a href="#">Fast</a><p>Go fast enough to get there, but slow enough to see.</p>
                            </li>
                            <li><a href="#">Soft</a><p>If you look for truth, you may find comfort in the end.</p>
                            </li>
                            <li><a href="#">Long Distance</a><p>Run through your life with you.</p>
                            </li>
                            <li><a href="#">Balance</a><p>Never underestimate the power of a shoe.</p>
                            </li>
                        </ul>
                    </div>
                    <div class="col-md-8">
                        <ul class="team_list">
                            <h4>Our Partners</h4>
                            <p class="m_7">Creative organizations that excel in producing first-class interactive content</p>
                            <div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Timer ID="Timer1" Interval="1000" runat="server"></asp:Timer>
                                        <asp:AdRotator ID="AdRotator1" runat="server"
                                            AdvertisementFile="~/xml/ads.xml" Height="300px"
                                            Width="500px" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
