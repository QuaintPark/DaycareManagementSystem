<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuaintDMS.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <%-- Slider --%>
    <section id="slider">

        <!-- Background swither -->
        <%--<div class="swicher_section">
            <div class="color-sw" id="color-sw">
                <div id="color-sw-open" class="color-sw-open">
                    <i class="fa fa-cog"></i>
                </div>
                <div class="color-sw-header">
                    Background switcher <span class="color-sw-close" id="color-sw-close"><i class="fa fa-close"></i></span>
                </div>
                <div class="color-sw-body">
                    <p>Choose background style</p>
                    <div class="color-sw-item active" id="slider_background_v1">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v2">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v3">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v6">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v5">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v4">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v7">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v8">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v9">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v10">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v11">
                        <div></div>
                    </div>
                    <div class="color-sw-item" id="slider_background_v12">
                        <div></div>
                    </div>
                </div>
            </div>

        </div>--%>
        <!-- END Background swither -->

        <div class="parallax_bg hidden-sm hidden-xs">
            <ul id="scene" class="scene" data-scalar-x="10" data-scalar-y="4">
                <li class="layer" data-depth="0.00">
                    <img runat="server" id="sun" src="~/Theme/img/home/sun.png" /></li>
                <li class="layer" data-depth="0.20">
                    <img runat="server" id="globe" src="~/Theme/img/home/globe.png" /></li>
                <li class="layer" data-depth="0.30">
                    <img runat="server" id="cloud" src="~/Theme/img/home/clouds.png" /></li>
            </ul>
        </div>
        <div id="overlay_slider_land" class="overlay_slider_land"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div id="slider_home" class="slider-pro">
                        <div class="sp-slides">
                            <div class="sp-slide">
                                <img runat="server" class="sp-image" src="~/Theme/img/home/slider_home_2.jpg" alt="The Last of us" />
                                <div class="sp-layer slide_block_text" data-position="bottomLeft" data-horizontal="40" data-vertical="57" data-show-delay="1200" data-hide-delay="400">
                                    <h3>Welcome to Q Care</h3>
                                    <p>A perfect learning center for your kids</p>
                                </div>
                            </div>
                            <div class="sp-slide">
                                <img runat="server" class="sp-image" src="~/Theme/img/home/slider_home_3.jpg" alt="The Last of us" />
                                <div class="sp-layer slide_block_text" data-position="bottomLeft" data-horizontal="40" data-vertical="57" data-show-delay="1200" data-hide-delay="400">
                                    <h3>Amazing Illustrations</h3>
                                    <p>Customizable illustration desings</p>
                                </div>
                            </div>
                        </div>
                        <div class="sp-slide">
                            <img runat="server" class="sp-image" src="~/Theme/img/home/slider_home_1.jpg" alt="The Last of us" />
                            <div class="sp-layer slide_block_text" data-position="bottomLeft" data-horizontal="40" data-vertical="57" data-show-delay="1200" data-hide-delay="400">
                                <h3>Q Care Kindergarten</h3>
                                <p>Best Education for Kids Perfectly</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%-- End Slider --%>

    <%-- Offer --%>
    <section id="offer" class="offer">
        <div class="container">
            <div class="row">
                <h2>What we offer</h2>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <div class="offer_block offer_red wow fadeInUp">
                        <i class="fa fa-futbol-o"></i>
                        <h4>Sports</h4>
                        <p>Q care provide good playground for all children. Children can play together. They can enjoy the best moment by playing with others. Sometimes teachers are help to encourage them to play each other.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <div class="offer_block offer_blue wow fadeInUp">
                        <i class="fa fa-music"></i>
                        <h4>Music lesson</h4>
                        <p>There have such good music lesson for all children. Children can learn different music from their teachers. Teachers always help to learn by their choice.</p>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <div class="offer_block offer_green wow fadeInUp">
                        <i class="fa fa-cutlery"></i>
                        <h4>Healthy food</h4>
                        <p>They provide the nutritious food for all children. This is the first responsibility of Q care. So they always concern about children heath.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%-- End Offer --%>

    <%-- About --%>
    <section id="about">
        <div class="overlay_one">
            <div class="bg_top"></div>
            <div class="bg_bottom"></div>
        </div>
        <div class="overlay_two">
            <div class="bg_top"></div>
            <div class="bg_bottom"></div>
        </div>
        <div class="overlay_three">
            <div class="bg_top"></div>
            <div class="bg_bottom"></div>
        </div>
        <div class="container">
            <div class="row">
                <h2>About us</h2>
                <div class="about_text_block">
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <p>
                            Q care is the first ever child daycare mangement system in our country. 
                            We are trying to provide more satisfying care of ur child when you are in office or working.
                            Because your child we care.We provide safely and hygenic environment for your child which we ensure to you.
                            We are comitted to you provide the best care for every child.
                        </p>
                        <p>
                            We have a fourteen thousend square fit floor with highly sesurities,
                            fully AC facilities with one children park.
                        </p>
                    </div>
                    <div class="col-md-6 col-sm-12 col-xs-12 about_img_block wow fadeIn">
                        <img runat="server" src="~/Theme/img/home/about_img.jpg" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="about_tabs">
                        <div class="about_bear_img hidden-sm hidden-xs">
                            <img runat="server" src="~/Theme/img/home/about_bear.png" />
                        </div>
                        <ul class="nav nav-tabs">
                            <li class="active"><a class="tab_red" href="#education" data-toggle="tab">Education</a></li>
                            <li><a class="tab_blue" href="#activities" data-toggle="tab">Activities</a></li>
                            <li><a class="tab_lightgreen" href="#friendship" data-toggle="tab">Friendship</a></li>
                            <li><a class="tab_green" href="#development" data-toggle="tab">Development</a></li>
                        </ul>
                        <div class="tab-content about_tabs_content">
                            <div class="tab-pane tab_red active" id="education">
                                <h3>Education</h3>
                                <div class="col-md-7 col-sm-12 col-xs-12">
                                    <div class="hidden-lg hidden-md"></div>
                                    <p>
                                        Education is the backbone of a nation. We always concern about the best teaching.
                                        Which is needed for all children? We teach to your children Native Bengali, English, 
                                        Mathematics, Religious subjects & drawing regularly. 
                                    </p>
                                    <p>
                                        Continue education for your baby's for whom age will be 5-10 age. We just complete basic education like alphabets, learning 
                                        & writing also complete class kg 1-3. Also we teach all text books and complete total syllabus
                                        from Baby-five (standard). 
                                    </p>
                                </div>
                                <div class="col-md-5 hidden-sm hidden-xs about_img_content">
                                    <img runat="server" src="~/Theme/img/home/education.jpg" />
                                </div>
                            </div>
                            <div class="tab-pane tab_blue" id="activities">
                                <h3>Activities</h3>
                                <div class="col-md-7 col-sm-12">
                                    <div class="hidden-lg hidden-md"></div>
                                    <p>
                                        Activities are the heart of every child. We always cooperate with different 
                                            extracurricular activities. This is because it makes every child more energetic
                                            and happy. Sometimes we arrange some education program like drama, poem, reciting, 
                                            play games among the children.
                                    </p>
                                    <p>
                                        We always concern about the best care. We provide best
                                            nursing for all children. Every child can ask for anything from assign nurse or supervisor,
                                            they should fulfill the criteria of your child.
                                    </p>
                                </div>
                                <div class="col-md-5 hidden-sm hidden-xs about_img_content">
                                    <img runat="server" src="~/Theme/img/home/activities.jpg" />
                                </div>
                            </div>
                            <div class="tab-pane tab_lightgreen" id="friendship">
                                <h3>Friendship</h3>
                                <div class="col-md-7 col-sm-12">
                                    <div class="hidden-lg hidden-md"></div>
                                    <p>
                                        We have a very friendly environment for all children and their parents.
                                        Now a days we teach baby's how to react each other & share joy & sorrow 
                                        with them. Sometimes we give them various types of gifts.
                                    </p>
                                    <p>
                                        Here all childrencan play and make fun with each other, and parents
                                        are also open discuss with other parents. 
                                        They can give us advise how we would manage their children.
                                    </p>
                                </div>
                                <div class="col-md-5 hidden-sm hidden-xs about_img_content">
                                    <img runat="server" src="~/Theme/img/home/friendship.jpg" />
                                </div>
                            </div>
                            <div class="tab-pane tab_green" id="development">
                                <h3>Development</h3>
                                <div class="col-md-7 col-sm-12">
                                    <div class="hidden-lg hidden-md"></div>
                                    <p>
                                        Development is the big thing in our system. As your children is an 
                                            asset for you so we teach them how they honor elder persons and how 
                                            clean yourself. Sometime we teach them socialism to adjust themselves
                                            with the family. We are trying to give more satisfying and authentic 
                                            service for all. 
                                    </p>
                                    <p>
                                        We are developing our service system day by day. 
                                            We are trying to develop an application for parents how they could 
                                            directly connect with us and their children.
                                    </p>
                                </div>
                                <div class="col-md-5 hidden-sm hidden-xs about_img_content">
                                    <img runat="server" src="~/Theme/img/home/development.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%-- End About --%>

    <%-- Timer --%>
    <section id="timer" class="timer text-center" data-parallax="scroll" data-bleed="200" data-z-index="-100" data-speed="0.1" data-image-src="img/home/timer_bg.jpg" data-over-scroll-fix="true">
        <div class="timer_flags"></div>
        <div class="timer_overlay"></div>
        <div class="container timer_block">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <h2 class="section-title">Different &amp; Fantastic<br />
                        Learning Environment</h2>
                </div>
            </div>
        </div>
    </section>
    <%-- End Timer --%>

    <%-- Stories --%>
    <section id="stories" class="stories">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="section-title">Stories</h2>
                </div>
            </div>
            <div class="row arrows_red">
                <div id="stories_owl" class="owl-carousel owl-theme">
                    <div class="item col-md-12 wow fadeInUp">
                        <div class="s_green_block all_color">
                            <div class="top_stories">
                                <img runat="server" src="~/Theme/img/home/top_stories_green.png" />
                            </div>
                            <div class="bottom_stories">
                                <img runat="server" src="~/Theme/img/home/bottom_stories_green.png" />
                            </div>
                            <p><i class="fa fa-quote-left"></i></p>
                            <h4>Activities Improve Mind</h4>
                            <p class="mb-15">
                                They help all children to improve their mind during extracurricular activities. 
                                    They help children how to interact with other children. They provide a friendly 
                                    environment for all children. They teach all children socialism to adjust themselves
                                    with their friends & family, which is developing their mind.
                            </p>
                            <div class="stories_more">
                                <a><i class="fa fa-dot-circle-o"></i></a>
                            </div>
                        </div>
                        <div class="stories_autor">
                            <div class="stories_autor_avatar">
                                <img runat="server" src="~/Theme/img/blog/author2.jpg" />
                            </div>
                            <div class="stories_autor_text c_green">
                                <p><span>Humayan kabir Shimul</span></p>
<%--                                <p>Lorem ipsum dolor sit amet.</p>--%>
                            </div>
                        </div>
                    </div>
                    <div class="item col-md-12 wow fadeInUp" data-wow-delay="0.1s">
                        <div class="s_red_block all_color">
                            <div class="top_stories">
                                <img runat="server" src="~/Theme/img/home/top_stories_red.png" />
                            </div>
                            <div class="bottom_stories">
                                <img runat="server" src="~/Theme/img/home/bottom_stories_red.png" />
                            </div>
                            <p><i class="fa fa-quote-left"></i></p>
                            <h4>School Days</h4>
                            <p class="mb-15">They provide the nutritious food for all children. This is the first responsibility of Q care. So they always concern about children heath.</p>
                            <div class="stories_more">
                                <a><i class="fa fa-dot-circle-o"></i></a>
                            </div>
                        </div>
                        <div class="stories_autor">
                            <div class="stories_autor_avatar">
                                <img runat="server" src="~/Theme/img/blog/author1.jpg" />
                            </div>
                            <div class="stories_autor_text c_red">
                                <p><span>Selina Joseph</span></p>
                                <%--<p>Lorem ipsum dolor sit amet.</p>--%>
                            </div>
                        </div>
                    </div>
                    <div class="item col-md-12 wow fadeInUp" data-wow-delay="0.2s">
                        <div class="s_margin_block all_color">
                            <div class="top_stories">
                                <img runat="server" src="~/Theme/img/home/top_stories_blue.png" />
                            </div>
                            <div class="bottom_stories">
                                <img runat="server" src="~/Theme/img/home/bottom_stories_blue.png" />
                            </div>
                            <p><i class="fa fa-quote-left"></i></p>
                            <h4>Active Learning</h4>
                            <p class="mb-15">
                                Q care provides the best learning. They teach different types
                                    of program to their student and academic lesson
                                    like alphabet, writing, reading, and native speaking both English
                                    and Bengali.They help children how to improve their basic skill of education. Some program like drama
                                    , proem, reciting, and play games among the children which increase their learning capability.
                            </p>
                            <div class="stories_more">
                                <a><i class="fa fa-dot-circle-o"></i></a>
                            </div>
                        </div>
                        <div class="stories_autor">
                            <div class="stories_autor_avatar">
                                <img runat="server" src="~/Theme/img/blog/author5.jpg" />
                            </div>
                            <div class="stories_autor_text c_blue">
                                <p><span>Mohammad Rakib Hossain</span></p>
                                <p>Lorem ipsum dolor sit amet.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%-- End Stories --%>

    <!-- Contact -->
    <section id="contact" class="contact_v1">
        <div class="contact_overlay_ball hidden-sm hidden-xs"></div>
        <div class="contact_overlay_plain hidden-sm hidden-xs"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <h2 class="section-title">Contact Us</h2>
                    <div class="contact_form contact_form_transparent">
                        <div id="form-messages"></div>
                        <div class="form-group">
                            <asp:TextBox ID="txtFullName" runat="server" placeholder="Full Name" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtSubject" runat="server" placeholder="Subject" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtMessage" runat="server" placeholder="Message" TextMode="MultiLine" Rows="3" required="required"></asp:TextBox>
                        </div>
                        <div id="messegeResult" class="messegeResult">
                            <p>The message was successfully sent</p>
                            <button id="btnSend" runat="server">Send</button>
                            <%--<asp:Button runat="server" CssClass="ui-button ui-corner-all ui-widget"  Text="Send" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="google_maps" class="google_maps map-container">
        <iframe runat="server" id="mapSection" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7496149.559281854!2d85.84647510143783!3d23.45219283693556!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x30adaaed80e18ba7%3A0xf2d28e0c4e1fc6b!2sBangladesh!5e0!3m2!1sen!2sbd!4v1516641930341" marginwidth="0" width="100%" scrolling="no" height="500" marginheight="0" style="border: 0" allowfullscreen="" frameborder="0"></iframe>
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-sm-5 location_info">
                    <div class="location_block">
                        <div class="overlay_footer_copter hidden-sm hidden-xs"></div>
                        <p class="location">Location</p>
                        <p class="phone">+880 1798 806480</p>
                        <p class="adress">
                            Sukrabad,Near Daffodil Tower
                            Dhanmondi, Dhaka.
                        </p>
                        <p><a href="mailto:info@qcare.com">info@qcare.com</a></p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- End Contact -->
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
