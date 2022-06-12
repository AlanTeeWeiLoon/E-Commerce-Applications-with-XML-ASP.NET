<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="DECXML_Assignment.MainPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="banner">
        <!-- start slider -->
        <div id="fwslider">
            <div class="slider_container">
                <div class="slide">
                    <img src="images/slider0.jpg" class="img-responsive" alt="" />
                    <div class="slide_content">
                        <div class="slide_content_wrap" style="max-width: 800px">
                            <!-- Text title -->
                            <h3 class="title" style="color: white; text-shadow: 1px 2px 2px black; font-size: 60px">Welcome to DECXML -
                                <br>
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>
                <div class="slide">
                    <!-- Slide image -->
                    <img src="images/slider3.jpg" class="img-responsive" alt="" />
                    <!-- /Slide image -->
                    <!-- Texts container -->

                    <div class="slide_content">
                        <div class="slide_content_wrap">
                            <!-- Text title -->
                            <h1 class="title" style="color: white; text-shadow: 1px 2px 2px black;">Run Over<br>
                                Everyone</h1>
                            <!-- /Text title -->
                            <div class="button"><a href="ProductList.aspx">See Details</a></div>
                        </div>
                    </div>
                    <!-- /Texts container -->
                </div>
                <!-- /Duplicate to create more slides -->
                <div class="slide">
                    <img src="images/slider4.jpg" class="img-responsive" alt="" />
                    <div class="slide_content">
                        <div class="slide_content_wrap">
                            <h1 class="title">Run Over<br>
                                Everything</h1>
                            <div class="button"><a href="ProductList.aspx">See Details</a></div>
                        </div>
                    </div>
                </div>
                <!--/slide -->
            </div>
            <div class="timers"></div>
            <div class="slidePrev"><span></span></div>
            <div class="slideNext"><span></span></div>
        </div>
        <!--/slider -->
    </div>
    <div class="main">
        <div class="content-top">
            <h2>Sport Shoes</h2>
            <p>Best for long-running | Best for your feet | Be faster with us</p>
            <table style="width: 100%; align-items: center">
                <tr>
                    <td>
                        <img src="images/shoe1.jpg" /></td>
                    <td></td>
                    <td>
                        <img src="images/shoe2.jpg" /></td>
                    <td></td>
                    <td>
                        <img src="images/shoe3.jfif" /></td>
                </tr>
            </table>
            <h3>Sport Shoe Extreme Series</h3>
        </div>
    </div>
    <div class="content-bottom">
        <div class="container">
            <div class="row content_bottom-text">
                <div class="col-md-7">
                    <h3>Mamba Mentality<br>
                        - Kobe Bryant</h3>
                    <p class="m_1">“I want to see if I can. I don’t know if I can. I want to find out. I want to see. I’m going to do what I always do: I’m going to break it down to its smallest form, smallest detail, and go after it. Day by day, one day at a time.”</p>
                    <p class="m_2">“Have a good time. Life is too short to get bogged down and be discouraged. You have to keep moving. You have to keep going. Put one foot in front of the other, smile and just keep on rolling.”</p>
                </div>
            </div>
        </div>
    </div>
    <div class="features">
        <div class="container">
            <h3 class="m_3">Features</h3>
            <div class="row">
                <div class="col-md-3 top_box">
                    <div class="view view-ninth">
                        <a href="ProductList.aspx">
                            <img src="images/pic1.jfif" class="img-responsive" alt="" />
                            <div class="mask mask-1"></div>
                            <div class="mask mask-2"></div>
                            <div class="content">
                                <h2>Fast</h2>
                                <p>Go fast enough to get there, but slow enough to see.</p>
                            </div>
                        </a>
                    </div>
                    <h4 class="m_4"><a href="#">Fast</a></h4>
                    <p class="m_5">Go fast enough to get there, but slow enough to see.</p>
                </div>
                <div class="col-md-3 top_box">
                    <div class="view view-ninth">
                        <a href="ProductList.aspx">
                            <img src="images/pic2.jpg" class="img-responsive" alt="" />
                            <div class="mask mask-1"></div>
                            <div class="mask mask-2"></div>
                            <div class="content">
                                <h2>Soft</h2>
                                <p>If you look for truth, you may find comfort in the end.</p>
                            </div>
                        </a>
                    </div>
                    <h4 class="m_4"><a href="#">Soft Quality</a></h4>
                    <p class="m_5">If you look for truth, you may find comfort in the end</p>
                </div>
                <div class="col-md-3 top_box">
                    <div class="view view-ninth">
                        <a href="ProductList.aspx">
                            <img src="images/pic3.jpg" class="img-responsive" alt="" />
                            <div class="mask mask-1"></div>
                            <div class="mask mask-2"></div>
                            <div class="content">
                                <h2>Long Distance</h2>
                                <p>Run through your life with you.</p>
                            </div>
                        </a>
                    </div>
                    <h4 class="m_4"><a href="#">Long Distance</a></h4>
                    <p class="m_5">Run through your life with you.</p>
                </div>
                <div class="col-md-3 top_box1">
                    <div class="view view-ninth">
                        <a href="ProductList.aspx">
                            <img src="images/pic4.jpg" class="img-responsive" alt="" />
                            <div class="mask mask-1"></div>
                            <div class="mask mask-2"></div>
                            <div class="content">
                                <h2>Balance</h2>
                                <p>Never underestimate the power of a shoe.</p>
                            </div>
                        </a>
                    </div>
                    <h4 class="m_4"><a href="#">Balance</a></h4>
                    <p class="m_5">Never underestimate the power of a shoe.</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
