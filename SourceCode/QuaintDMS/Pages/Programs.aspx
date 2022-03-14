<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="QuaintDMS.Pages.Programs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <section id="rates" class="rates common-page">
        <div class="container">
            <div class="row">
                <div class="col-md-12 dot">
                    <h2 class="section-title">Program</h2>
                </div>
            </div>
            <div class="row">

                <asp:Repeater ID="rptrProgram" runat="server" OnItemDataBound="rptrProgram_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-4">
                            <div class="rates_block basic_block wow fadeInLeft">
                                <div class="text_block">
                                    <div class="rates_name">
                                        <p><span><%# Eval("Title") %></span></p>
                                    </div>
                                    <div class="rates_price">
                                        <p>BDT. <%# Eval("TotalAmount") %></p>
                                    </div>
                                    <p class="sr-only"><span>Program Fee</span></p>
                                    <p class="sr-only" id="pId"><%# Eval("ProgramId") %></p>
                                    <ul>
                                        <asp:Repeater ID="rptrService" runat="server">
                                            <ItemTemplate>
                                                <li><i class='fa fa-check'></i><span><%# Eval("ServiceTitle") %></span></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hfProgramId" runat="server" Value='<%# QuaintPark.QuaintSecurityManager.Encrypt(Eval("ProgramId").ToString()) %>' />
                    </ItemTemplate>
                </asp:Repeater>

                <%--<div class="col-md-4">
                    <div class="rates_block basic_block wow fadeInLeft">
                        <div class="text_block">
                            <div class="rates_name">
                                <p><span>basic</span></p>
                            </div>
                            <div class="rates_price">
                                <p>BDT. 2,000</p>
                            </div>
                            <p class="sr-only"><span>Program Fee</span></p>
                            <ul>
                                <li><i class='fa fa-check'></i><span>Lorem ipsum dolor sit amet</span></li>
                                <li><i class='fa fa-check'></i><span>consectetur adipisicing elit</span></li>
                                <li><i class='fa fa-check'></i><span>sed do eiusmod tempor incididunt</span></li>
                                <li><i class='fa fa-check'></i><span>ut labore et dolore magna aliqua</span></li>
                                <li><i class='fa fa-check'></i><span>Ut enim ad minim veniam</span></li>
                            </ul>
                            <!--<div class="rates_button">
                                <a href="#">button</a>
                            </div>-->
                        </div>
                    </div>
                </div>--%>

            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
