<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staffs.aspx.cs" Inherits="QuaintDMS.Pages.Staffs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <section id="teachers_portfolio" class="teachers_portfolio text-center section">
        <div class="container">
            <div class="row">
                <div class="col-md-12 dot">
                    <h2 class="section-title">Staff</h2>
                </div>
            </div>
            <div class="row">
                <ul class="filter">
                    <li class="active"><a href="#" data-filter="*">All</a></li>
                    <asp:Repeater ID="rptrDesignation" runat="server">
                        <ItemTemplate>
                            <li><a href="#" data-filter='.<%# Eval("DesignationCode") %>'><%# Eval("Name") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<li><a href="#" data-filter=".supervisor">Supervisor</a></li>
                    <li><a href="#" data-filter=".tech">Teacher</a></li>
                    <li><a href="#" data-filter=".doctor">Doctor</a></li>
                    <li><a href="#" data-filter=".nurse">Nurse</a></li>
                    <li><a href="#" data-filter=".housekeeper">Housekeeper</a></li>
                    <li><a href="#" data-filter=".guard">Guard</a></li>--%>
                </ul>
            </div>
            <div class="row portfolio_grid">
                <asp:Repeater ID="rptrStaff" runat="server">
                    <ItemTemplate>
                        <div class='col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp <%# Eval("DesignationCode") %>'>
                            <div class="supervisor">
                                <div class="teacher_block blue_block">
                                    <div class="teacher_avatar">
                                        <img runat="server" src='<%# (string.IsNullOrEmpty(Convert.ToString(Eval("ProfilePhoto")))) ? string.Empty : string.Format(QuaintDMS.Code.Global.FilePath.Employee + Eval("ProfilePhoto")) %>' alt='<%# Eval("FirstName") + " " + Eval("LastName") %>' />
                                    </div>
                                    <div class="teacher_about staff-description-area">
                                        <h3><%# Eval("FirstName") + " " + Eval("LastName") %></h3>
                                        <span><%# Eval("DesignationName") %></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <%--<div class="supervisor col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp">
                    <div class="supervisor">
                        <div class="teacher_block grey_block">
                            <div class="teacher_avatar">
                                <img runat="server" src="~/Theme/img/teacher/teacher_1.jpg" alt="" />
                            </div>
                            <div class="teacher_about">
                                <h3><a href="teacher.html">Helen Douglas</a></h3>
                                <span><%# Eval("DesignationName") %></span>
                            </div>
                        </div>
                    </div>
                </div>--%>
                <%--<div class="tech reading col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp">
                    <div class="tech">
                        <div class="teacher_block blue_block">
                            <div class="teacher_avatar">
                                <img runat="server" src="~/Theme/img/teacher/teacher_2.jpg" alt="" />
                            </div>
                            <div class="teacher_about">
                                <h3><a href="teacher.html">John Bishop</a></h3>
                                <span>Teacher</span>
                                <div class="teacher_link social_icon">
                                    <ul>
                                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="housekeeper col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp">
                    <div class="housekeeper">
                        <div class="teacher_block yellow_block">
                            <div class="teacher_avatar">
                                <img runat="server" src="~/Theme/img/teacher/teacher_3.jpg" alt="" />
                            </div>
                            <div class="teacher_about">
                                <h3><a href="teacher.html">Bryan Barker</a></h3>
                                <span>Housekeeper</span>
                                <div class="teacher_link social_icon">
                                    <ul>
                                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="doctor col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp">
                    <div class="doctor">
                        <div class="teacher_block red_block">
                            <div class="teacher_avatar">
                                <img runat="server" src="~/Theme/img/teacher/teacher_4.jpg" alt="" />
                            </div>
                            <div class="teacher_about">
                                <h3><a href="teacher.html">Chloe Fowler</a></h3>
                                <span>Doctor</span>
                                <div class="teacher_link social_icon">
                                    <ul>
                                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="nurse col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp">
                    <div class="nurse">
                        <div class="teacher_block yellow_block">
                            <div class="teacher_avatar">
                                <img runat="server" src="~/Theme/img/teacher/teacher_5.jpg" alt="" />
                            </div>
                            <div class="teacher_about">
                                <h3><a href="teacher.html">Andra Stevens</a></h3>
                                <span>Nurse</span>
                                <div class="teacher_link social_icon">
                                    <ul>
                                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="guard col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp">
                    <div class="guard">
                        <div class="teacher_block red_block">
                            <div class="teacher_avatar">
                                <img runat="server" src="~/Theme/img/teacher/teacher_6.jpg" alt="" />
                            </div>
                            <div class="teacher_about">
                                <h3><a href="teacher.html">Peter Bailey</a></h3>
                                <span>Guard</span>
                                <div class="teacher_link social_icon">
                                    <ul>
                                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="nurse col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp">
                    <div class="nurse">
                        <div class="teacher_block grey_block">
                            <div class="teacher_avatar">
                                <img runat="server" src="~/Theme/img/teacher/teacher_7.jpg" alt="" />
                            </div>
                            <div class="teacher_about">
                                <h3><a href="teacher.html">Mariah Wilson</a></h3>
                                <span>Nurse</span>
                                <div class="teacher_link social_icon t_green_dark">
                                    <ul>
                                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tech reading col-md-3 col-sm-4 portfolio_grid_item wow fadeInUp">
                    <div class="tech">
                        <div class="teacher_block blue_block">
                            <div class="teacher_avatar">
                                <img runat="server" src="~/Theme/img/teacher/teacher_8.jpg" alt="" />
                            </div>
                            <div class="teacher_about">
                                <h3><a href="teacher.html">Shonda Bradford</a></h3>
                                <span>Teacher</span>
                                <div class="teacher_link social_icon">
                                    <ul>
                                        <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                        <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                        <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </section>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
