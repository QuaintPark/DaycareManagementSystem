<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="DonorDonation.aspx.cs" Inherits="QuaintDMS.Account.DonorDonation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Donor Donation" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
             <section class="content-header">
                <h1>Donor Donation</h1>
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
                                    Donor Donation</h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-primary btn-sm" data-widget="collapse" data-toggle="tooltip" title="Toggle">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body user-form">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtDonorDonationCode">Donor Donation Code:<span>*</span></label>
                                        <asp:TextBox ID="txtDonorDonationCode" runat="server" CssClass="form-control" placeholder="Donor Donation Code"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtDonationAmount">Donation Amount:<span>*</span></label>
                                        <asp:TextBox ID="txtDonationAmount" runat="server" CssClass="form-control" TextMode="Number"  placeholder="Donation Amount"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtDonationDate">Donation Date:<span>*</span></label>
                                        <asp:TextBox ID="txtDonationDate" runat="server" CssClass="form-control" TextMode="Date"  placeholder="Donation Date"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="ddlDonor">Donor:<span>*</span></label>
                                        <asp:DropDownList ID="ddlDonor" runat="server" CssClass="form-control"/>
                                    </div>
                                </div>
                            </div>                            
                            <div class="box-footer text-right">
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="btnClear_Click"  />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click"  />
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
</asp:Content>
