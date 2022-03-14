<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="QuaintDMS.Pages.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <section id="contact_page" class="contact_page">
        <div class="container">
            <div class="row">
                <div class="col-md-12 dot">
                    <h2 class="section-title">Contact Us</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 contact_link">
                    <p class="contact-description">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    <div class="row pb_50">
                        <div class="col-md-6 col-sm-6 contact_block">
                            <span class="contact_icon"><i class="fa fa-phone"></i></span>
                            <ul>
                                <li class="title">Phone</li>
                                <li><a href="tel:+8801798806480">+880 1798 806480</a></li>
                            </ul>
                        </div>
                        <div class="col-md-6 col-sm-6 contact_block">
                            <span class="contact_icon"><i class="fa fa-envelope"></i></span>
                            <ul>
                                <li class="title">Email</li>
                                <li><a href="mailto:info@qcare.com">info@qcare.com</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-6 contact_block">
                            <span class="contact_icon"><i class="fa fa-share-alt"></i></span>
                            <ul class="social_icon">
                                <li class="title">Follow Us</li>
                                <li class="b_blue_dark_social"><a href="#"><i class="fa fa-facebook"></i></a></li>
                                <li class="b_blue_social"><a href="#"><i class="fa fa-twitter"></i></a></li>
                                <li class="b_red_social"><a href="#"><i class="fa fa-google-plus"></i></a></li>
                                <li class="b_linkedin"><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                <li class="b_red_social"><a href="#"><i class="fa fa-youtube-play"></i></a></li>
                            </ul>
                        </div>
                        <div class="col-md-6 col-sm-6 contact_block">
                            <span class="contact_icon"><i class="fa fa-map-marker"></i></span>
                            <ul>
                                <li class="title">Location</li>
                                <li>
                                    <p>Sukrabad,Near Daffodil Tower Dhanmondi, Dhaka.</p>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="sidebar">
                        <div class="working_hours">
                            <h4><span><i class="fa fa-clock-o"></i></span>Working Hours</h4>
                            <ul>
                                <li class="day">Saturday</li>
                                <li>6:00 AM - 8:00 PM</li>
                            </ul>
                            <ul>
                                <li class="day">Sunday</li>
                                <li>6:00 AM - 8:00 PM</li>
                            </ul>
                            <ul>
                                <li class="day">Monday</li>
                                <li>6:00 AM - 8:00 PM</li>
                            </ul>
                            <ul>
                                <li class="day">Tuesday</li>
                                <li>6:00 AM - 8:00 PM</li>
                            </ul>
                            <ul>
                                <li class="day">Wednesday</li>
                                <li>6:00 AM - 8:00 PM</li>
                            </ul>
                            <ul>
                                <li class="day">Thursday</li>
                                <li>6:00 AM - 8:00 PM</li>
                            </ul>
                            <ul>
                                <li class="day">Friday</li>
                                <li>Closed</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="contact_map">
                <div class="row">
                    <div class="col-md-12 map-container">
                        <%--<div id="map"></div>--%>
                        <iframe runat="server" id="mapSection" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7496149.559281854!2d85.84647510143783!3d23.45219283693556!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x30adaaed80e18ba7%3A0xf2d28e0c4e1fc6b!2sBangladesh!5e0!3m2!1sen!2sbd!4v1516641930341" marginwidth="0" width="100%" scrolling="no" height="500" marginheight="0" style="border: 0" allowfullscreen="" frameborder="0"></iframe>
                    </div>
                </div>
            </div>
            <div class="send_us">
                <div class="row">
                    <div class="col-md-12">
                        <div class="leave_reply">
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <h3 class="title">Send Us a Message</h3>
                                    <p class="description">Send your requisition or query.</p>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                            <div class="contact_form_blue">
                                <div>
                                    <div id="form-messages"></div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtFullName" runat="server" placeholder="Full Name" required="required"></asp:TextBox>
                                    </div>
                                    <div class="form-group m_form-group">
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" required="required"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtSubject" runat="server" placeholder="Subject" required="required"></asp:TextBox>
                                    </div>
                                    <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" placeholder="Message" TextMode="MultiLine" Rows="3" required="required"></asp:TextBox>
                                    <div id="messegeResult" class="messegeResult">
                                        <p>The message was successfully sent</p>
                                        <button runat="server" id="btnSend" class="button" type="submit">Send</button>
                                        <%--<asp:Button runat="server" class="button" type="submit" Text="Send"/>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
