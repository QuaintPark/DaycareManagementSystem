<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="OfficeExpenseList.aspx.cs" Inherits="QuaintDMS.Account.OfficeExpenseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Office Expense"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Office Expense</h1>
                <ol class="breadcrumb">
                    <li>
                        <span id="workingBar" runat="server" visible="false" class="working-bar"><i class="fa fa-spinner fa-pulse fa-fw"></i>Working...</span>
                        <a runat="server" href="~/Account/OfficeExpense.aspx" class="btn btn-default"><i class="fa fa-plus"></i>Add</a>
                    </li>
                </ol>
            </section>
            
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <i class="fa fa-list-alt"></i>
                                <h3 class="box-title">
                                    <asp:Label ID="lblTitleStatus" runat="server" Text="Office Expense List"></asp:Label>
                                </h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-primary btn-sm" data-widget="collapse" data-toggle="tooltip" title="Toggle">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body user-form">
                                <div class="col-md-12">
                                    <table class="table table-responsive table-bordered table-striped table-hover dataTable">
                                        <thead>
                                            <tr>
                                                <th>Serial</th>
                                                <th>Expense Code</th>
                                                <th>Reference</th>
                                                <th>Amount</th>
                                                <th>Description</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>

                                        <tbody class="text-center">
                                            <asp:Repeater ID="rptrList" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Container.ItemIndex + 1 %></td>
                                                        <td><%# Eval("OfficeExpenseCode") %></td>
                                                        <td class="text-left"><%# Eval("Reference") %></td>
                                                        <td class="text-right"><%# String.Concat(Eval("Amount"), " Tk.") %></td>
                                                        <td class="text-left"><%# Eval("Description") %></td>
                                                        
                                                        <%-- Action Controls --%>
                                                        <td>
                                                            <div class="dropdown">
                                                                <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuAction" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                                                    <i class="fa fa-bars"></i>
                                                                </button>
                                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuAction">
                                                                    <li>
                                                                        <asp:HyperLink ID="btnEdit" runat="server" NavigateUrl='<%# String.Concat("~/Account/OfficeExpense.aspx?Id=", QuaintPark.QuaintSecurityManager.EncryptUrl(Eval("OfficeExpenseId").ToString())) %>'><i class="fa fa-edit text-light-blue"></i>Edit</asp:HyperLink>
                                                                    </li>
                                                                    <li class="list-seperator"></li>
                                                                    <li>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure want to delete?')" OnCommand="btnDelete_Command" CommandArgument='<%# QuaintPark.QuaintSecurityManager.Encrypt(Eval("OfficeExpenseId").ToString()) %>'><i class="fa fa-trash text-red"></i>Delete</asp:LinkButton>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="box-footer" id="alertMessage" runat="server"></div>
                        </div>
                    </div>
                </div>
            </section>

            <asp:Timer ID="tmrAlertMessage" runat="server" Enabled="False" OnTick="tmrAlertMessage_Tick"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
