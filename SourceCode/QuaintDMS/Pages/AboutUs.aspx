<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="QuaintDMS.Pages.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <section id="about_page" class="about_page common-page">
        <div class="container">
            <div class="row">
                <div class="col-md-12 dot">
                    <h2 class="section-title">About Us</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="about_page_text">
                        <p>Q care is the first ever child daycare mangement system in our country. 
                            We are trying to provide more satisfying care of ur child when you are in office or working.
                            Because your child we care.We provide safely and hygenic environment for your child which we ensure to you.
                            We are comitted to you provide the best care for every child.We have a 
                            fourteen thousend square fit floor with highly sesurities,fully AC facilities with one children park.
                        </p>
                    </div>
                </div> 
                <div class="col-md-6">
                    <div class="about_page_img wow fadeIn">
                        <img runat="server" src="~/Theme/img/about/about_img.jpg" alt="" />
                    </div>
                    
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
