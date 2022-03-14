<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="QuaintDMS.Account.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Dashboard"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>
                    Dashboard       
                    <small>Control panel</small>
                </h1>
            </section>

            <!-- Main content -->
            <section class="content">
                <!-- Small boxes (Stat box) -->
                <div class="row">
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-aqua">
                            <div class="inner">
                                <h3>
                                    <asp:Label ID="lblTotalStaff" runat="server" Text="0"></asp:Label>
                                </h3>
                                <p>Total Staff</p>
                            </div>
                            <div class="icon">
                                <i class="fa fa-users"></i>
                            </div>
                        </div>
                    </div>
                    <!-- ./col -->

                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-green">
                            <div class="inner">
                                <h3>
                                    <asp:Label ID="lblTotalChild" runat="server" Text="0"></asp:Label>
                                </h3>
                                <p>Total Child</p>
                            </div>
                            <div class="icon">
                                <i class="fa fa-child"></i>
                            </div>
                        </div>
                    </div>
                    <!-- ./col -->

                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-yellow">
                            <div class="inner">
                                <h3>
                                    <asp:Label ID="lblTotalMember" runat="server" Text="0"></asp:Label>
                                </h3>
                                <p>Total Member</p>
                            </div>
                            <div class="icon">
                                <i class="fa fa-user-secret"></i>
                            </div>
                        </div>
                    </div>
                    <!-- ./col -->

                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-red">
                            <div class="inner">
                                <h3>
                                    <asp:Label ID="lblTotalProgram" runat="server" Text="0"></asp:Label>
                                </h3>
                                <p>Total Program</p>
                            </div>
                            <div class="icon">
                                <i class="fa fa-cogs"></i>
                            </div>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>
                <!-- /.row -->

                <!-- Main row -->
                <div class="row">
                    <div class="col-md-12">
                        <!-- small box -->
                        <%--<div class="small-box bg-gray">
                            <div class="inner">
                                <h3><asp:Label ID="lblTotalIncome" runat="server" Text="0"></asp:Label><sup style="font-size: 20px">৳</sup></h3>
                                <p>Total Income</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-stats-bars"></i>
                            </div>
                        </div>--%>

                        <!-- small box -->
                        <div class="small-box bg-gray">
                            <div class="inner">
                                <h3><asp:Label ID="lblTotalExpense" runat="server" Text="0"></asp:Label><sup style="font-size: 20px">৳</sup></h3>
                                <p>Total Office Expense</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-stats-bars"></i>
                            </div>
                        </div>
                    </div>

                    <%--<div class="col-md-5">
                        <!-- Calendar -->
                        <div class="box box-solid bg-green-gradient">
                            <div class="box-header">
                                <i class="fa fa-calendar"></i>

                                <h3 class="box-title">Calendar</h3>
                                <!-- tools box -->
                                <div class="pull-right box-tools">
                                    <!-- button with a dropdown -->
                                    <button type="button" class="btn btn-success btn-sm" data-widget="collapse">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                                <!-- /. tools -->
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <!--The calendar -->
                                <div id="calendar" style="width: 100%"></div>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>--%>
                </div>
                <!-- /.row (main row) -->
            </section>
            <!-- /.content -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
