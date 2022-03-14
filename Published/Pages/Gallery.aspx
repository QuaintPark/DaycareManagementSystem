<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="QuaintDMS.Pages.Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <section id="portfolio" class="portfolio text-center section common-page">
        <div class="container">
            <div class="row">
                <div class="col-md-12 dot">
                    <h2 class="section-title">Gallery</h2>
                </div>
            </div>
            <div class="row">
                <ul class="filter">
                    <li class="active"><a href="#" data-filter="*">All</a></li>
                    <li><a href="#" data-filter=".drawing">Drawing</a></li>
                    <li><a href="#" data-filter=".events">Events</a></li>
                    <li><a href="#" data-filter=".reading">Reading</a></li>
                    <li><a href="#" data-filter=".photo">Photo</a></li>
                    <li><a href="#" data-filter=".songs">Songs</a></li>
                </ul>
            </div>
        </div>
        <div class="portfolio_grid">
            <div class="photo events drawing col-portfolio col-xs-12 col-sm-6 col-md-4 col-lg-3 portfolio_grid_item wow fadeInUp">
                <figure class="hover-line">
                    <div class="image-holder">
                        <img runat="server" src="~/Theme/img/portfolio/1-thumb.jpg" />
                    </div>
                    <figcaption>
                        <div class="portfolio-lead">
                            <div class="gallery_full_screen">
                                <a title="<h4>Photo title</h4><p>Short description - Kindergarten and elementary school teachers prepare younger students for future schooling by teaching them basic subjects such as math and reading. Consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>" class="link" href="img/portfolio/1.jpg">
                                    <img runat="server" src="~/Theme/img/icons/search_gallery.png" /></a>
                            </div>
                            <div class="gallery_description">
                                <p><span>Photo Title</span></p>
                                <p>Short Description - ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p>
                            </div>
                        </div>
                    </figcaption>
                </figure>
            </div>
            <div class="songs photo events col-portfolio col-xs-12 col-sm-6 col-md-4 col-lg-3 portfolio_grid_item wow fadeInUp" data-wow-delay="0.1s">
                <figure class="hover-line">
                    <div class="image-holder">
                        <img runat="server" src="~/Theme/img/portfolio/2-thumb.jpg" />
                    </div>
                    <figcaption>
                        <div class="portfolio-lead">
                            <div class="gallery_full_screen">
                                <a title="<h4>Photo title</h4><p>Short description - Kindergarten and elementary school teachers prepare younger students for future schooling by teaching them basic subjects such as math and reading. Consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>" class="link" href="img/portfolio/2.jpg">
                                    <img runat="server" src="~/Theme/img/icons/search_gallery.png" /></a>
                            </div>
                            <div class="gallery_description">
                                <p><span>Photo Title</span></p>
                                <p>Short Description - ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p>
                            </div>
                        </div>
                    </figcaption>
                </figure>
            </div>
            <div class="drawing events col-portfolio col-xs-12 col-sm-6 col-md-4 col-lg-3 portfolio_grid_item wow fadeInUp" data-wow-delay="0.2s">
                <figure class="hover-line">
                    <div class="image-holder">
                        <img runat="server" src="~/Theme/img/portfolio/3-thumb.jpg" />
                    </div>
                    <figcaption>
                        <div class="portfolio-lead">
                            <div class="gallery_full_screen">
                                <a title="<h4>Photo title</h4><p>Short description - Kindergarten and elementary school teachers prepare younger students for future schooling by teaching them basic subjects such as math and reading. Consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>" class="link" href="img/portfolio/3.jpg">
                                    <img runat="server" src="~/Theme/img/icons/search_gallery.png" /></a>
                            </div>
                            <div class="gallery_description">
                                <p><span>Photo Title</span></p>
                                <p>Short Description - ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p>
                            </div>
                        </div>
                    </figcaption>
                </figure>
            </div>
            <div class="drawing events col-portfolio col-xs-12 col-sm-6 col-md-4 col-lg-3 portfolio_grid_item wow fadeInUp" data-wow-delay="0.4s">
                <figure class="hover-line">
                    <div class="image-holder">
                        <img runat="server" src="~/Theme/img/portfolio/4-thumb.jpg" />
                    </div>
                    <figcaption>
                        <div class="portfolio-lead">
                            <div class="gallery_full_screen">
                                <a class="popup-youtube" href="https://www.youtube.com/watch?v=jNY_8oXniKA">
                                    <img runat="server" src="~/Theme/img/icons/video_gallery.png" /></a>
                            </div>
                            <div class="gallery_description">
                                <p><span>Video Title</span></p>
                                <p>Short Description - ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p>
                            </div>
                        </div>
                    </figcaption>
                </figure>
            </div>
            <div class="songs drawing reading col-portfolio col-xs-12 col-sm-6 col-md-4 col-lg-3 portfolio_grid_item wow fadeInUp" data-wow-delay="0.5s">
                <figure class="hover-line">
                    <div class="image-holder">
                        <img runat="server" src="~/Theme/img/portfolio/5-thumb.jpg" />
                    </div>
                    <figcaption>
                        <div class="portfolio-lead">
                            <div class="gallery_full_screen">
                                <a title="<h4>Photo title</h4><p>Short description - Kindergarten and elementary school teachers prepare younger students for future schooling by teaching them basic subjects such as math and reading. Consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>" class="link" href="img/portfolio/5.jpg">
                                    <img runat="server" src="img/icons/search_gallery.png" /></a>
                            </div>
                            <div class="gallery_description">
                                <p><span>Photo Title</span></p>
                                <p>Short Description - ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p>
                            </div>
                        </div>
                    </figcaption>
                </figure>
            </div>
            <div class="photo reading col-portfolio col-xs-12 col-sm-6 col-md-4 col-lg-3 portfolio_grid_item wow fadeInUp" data-wow-delay="0.6s">
                <figure class="hover-line">
                    <div class="image-holder">
                        <img runat="server" src="~/Theme/img/portfolio/6-thumb.jpg" />
                    </div>
                    <figcaption>
                        <div class="portfolio-lead">
                            <div class="gallery_full_screen">
                                <a title="<h4>Photo title</h4><p>Short description - Kindergarten and elementary school teachers prepare younger students for future schooling by teaching them basic subjects such as math and reading. Consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>" class="link" href="img/portfolio/6.jpg">
                                    <img runat="server" src="~/Theme/img/icons/search_gallery.png" /></a>
                            </div>
                            <div class="gallery_description">
                                <p><span>Photo Title</span></p>
                                <p>Short Description - ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p>
                            </div>
                        </div>
                    </figcaption>
                </figure>
            </div>
            <div class="songs reading photo col-portfolio col-xs-12 col-sm-6 col-md-4 col-lg-3 portfolio_grid_item wow fadeInUp" data-wow-delay="0.7s">
                <figure class="hover-line">
                    <div class="image-holder">
                        <img runat="server" src="~/Theme/img/portfolio/7-thumb.jpg" />
                    </div>
                    <figcaption>
                        <div class="portfolio-lead">
                            <div class="gallery_full_screen">
                                <a title="<h4>Photo title</h4><p>Short description - Kindergarten and elementary school teachers prepare younger students for future schooling by teaching them basic subjects such as math and reading. Consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>" class="link" href="img/portfolio/7.jpg">
                                    <img runat="server" src="~/Theme/img/icons/search_gallery.png" /></a>
                            </div>
                            <div class="gallery_description">
                                <p><span>Photo Title</span></p>
                                <p>Short Description - ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p>
                            </div>
                        </div>
                    </figcaption>
                </figure>
            </div>
            <div class="reading songs col-portfolio col-xs-12 col-sm-6 col-md-4 col-lg-3 portfolio_grid_item wow fadeInUp" data-wow-delay="0.8s">
                <figure class="hover-line">
                    <div class="image-holder">
                        <img runat="server" src="~/Theme/img/portfolio/8-thumb.jpg" />
                    </div>
                    <figcaption>
                        <div class="portfolio-lead">
                            <div class="gallery_full_screen">
                                <a class="popup-youtube" href="https://www.youtube.com/watch?v=jNY_8oXniKA">
                                    <img runat="server" src="~/Theme/img/icons/video_gallery.png" /></a>
                            </div>
                            <div class="gallery_description">
                                <p><span>Video Title</span></p>
                                <p>Short Description - ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p>
                            </div>
                        </div>
                    </figcaption>
                </figure>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
