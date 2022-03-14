<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="StaffSalaryRecord.aspx.cs" Inherits="QuaintDMS.Account.StaffSalaryRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Staff Salary Record" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Staff Salary Record</h1>
                <ol class="breadcrumb">
                    <li id="workingBar" runat="server" visible="false"><span class="working-bar"><i class="fa fa-spinner fa-pulse fa-fw"></i>Working...</span></li>
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
                                    Staff Salary Record</h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-primary btn-sm" data-widget="collapse" data-toggle="tooltip" title="Toggle">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body user-form">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtStaffSalaryRecordCode">Staff Salary RecordCode<span>*</span></label>
                                        <asp:TextBox ID="txtStaffSalaryRecordCode" runat="server" CssClass="form-control" placeholder="Staff Salary Record Code"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtSalary">Salary:<span>*</span></label>
                                        <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" TextMode="Number" placeholder="Salary"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtPreviousDue">Previous Due:<span>*</span></label>
                                        <asp:TextBox ID="txtPreviousDue" runat="server" CssClass="form-control" TextMode="Number" placeholder="Previous Due"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtTotal">Total:<span>*</span></label>
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" TextMode="Number" placeholder="Total"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtPaidAmount">Paid Amount:<span>*</span></label>
                                        <asp:TextBox ID="txtPaidAmount" runat="server" CssClass="form-control" TextMode="Number" placeholder="Paid Amount"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtDue">Due:<span>*</span></label>
                                        <asp:TextBox ID="txtDue" runat="server" CssClass="form-control" TextMode="Number" placeholder="Due"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="ddlStaff">Staff:<span>*</span></label>
                                        <asp:DropDownList ID="ddlStaff" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer text-right">
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="btnClear_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
