<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="Program.aspx.cs" Inherits="QuaintDMS.Account.Program" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Program"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Program</h1>
                <ol class="breadcrumb">
                    <li>
                        <span id="workingBar" runat="server" visible="false" class="working-bar"><i class="fa fa-spinner fa-pulse fa-fw"></i>Working...</span>
                        <a runat="server" href="~/Account/ProgramList.aspx" class="btn btn-default"><i class="fa fa-list-alt"></i>List</a>
                    </li>
                </ol>
            </section>

            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-header with-border">
                                <i class="fa fa-users"></i>
                                <h3 class="box-title">
                                    <asp:Label ID="lblTitleStatus" runat="server" Text="Add"></asp:Label>
                                    Program</h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-primary btn-sm" data-widget="collapse" data-toggle="tooltip" title="Toggle">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body user-form">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtTitle">Title:<span>*</span></label>
                                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Title" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtDescription">Description:</label>
                                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtAgeRange">Age Range:</label>
                                                <asp:TextBox ID="txtAgeRange" runat="server" CssClass="form-control" placeholder="Age Range"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtPeriod">Period:</label>
                                                <asp:TextBox ID="txtPeriod" runat="server" CssClass="form-control" placeholder="Period"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtTotalAmount">Total Amount:<span>*</span></label>
                                                <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control" TextMode="Number" placeholder="Total Amount" required="required" ReadOnly="true" Text="0.00"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <hr />
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h4 class="box-title"><u>Service(s) of Program</u></h4>
                                        </div>
                                        <div class="col-md-10">
                                            <div class="form-group">
                                                <label for="ddlService">Service:<span>*</span></label>
                                                <asp:DropDownList ID="ddlService" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlService" ErrorMessage="Select service" CssClass="msgError" InitialValue="--- Please Select ---"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="col-md-2 text-center">
                                            <div class="form-group" style="margin-top: 23px;">
                                                <asp:Button ID="btnAdd" runat="server" Text="+ Add Service" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:GridView ID="gvList" runat="server" CssClass="table table-responsive table-bordered table-striped table-hover table-service" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                                <Columns>
                                                    <asp:BoundField DataField="Serial" HeaderText="Serial">
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TitleWithAmountAndCode" HeaderText="Service(s)">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Remove">
                                                        <ItemTemplate>
                                                            <%--<asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn btn-sm btn-danger" OnCommand="btnRemove_Command"
                                                                OnClientClick="return confirm('Record will be removed.')" CommandArgument='<%# Eval("Serial") + "," + Eval("ServiceId") %>' />--%>
                                                            <asp:LinkButton ID="btnRemove" runat="server" CssClass="btn btn-sm btn-danger" OnCommand="btnRemove_Command" OnClientClick="return confirm('Item will be removed.')" 
                                                                CommandArgument='<%# Eval("Serial") + "," + Eval("ServiceId") %>'><i class="fa fa-trash"></i> Remove</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ServiceId" HeaderText="Service Id">
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer" id="alertMessage" runat="server"></div>
                            <div class="box-footer text-right">
                                <p class="pull-left conditions">* Mandatory field</p>
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="btnClear_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSaveAndContinue" runat="server" Text="Save & Continue" CssClass="btn btn-primary" OnClick="btnSaveAndContinue_Click" />
                            </div>
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
