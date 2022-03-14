<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="Donor.aspx.cs" Inherits="QuaintDMS.Account.Donor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Donor" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Donor</h1>
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
                                    Donor</h3>
                                <div class="box-tools pull-right">
                                    <button type="button" class="btn btn-primary btn-sm" data-widget="collapse" data-toggle="tooltip" title="Toggle">
                                        <i class="fa fa-plus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body user-form">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtDonorCode">Donor Code:<span>*</span></label>
                                        <asp:TextBox ID="txtDonorCode" runat="server" CssClass="form-control" placeholder="Donor Code"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtFirstName">First Name:<span>*</span></label>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtLastName">Last Name:</label>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtdateOfBirth">Date Of Birth</label>
                                        <asp:TextBox ID="txtdateOfBirth" runat="server" CssClass="form-control" TextMode="Date" placeholder="Date Of Birth"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtEmail">Email:</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtContactNumber">Contact Number:</label>
                                        <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" placeholder="Contact Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtAddressLine1">Address Line 1:<span>*</span></label>
                                        <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Address Line 1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtAddressLine2">Address Line 2:</label>
                                        <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Address Line 2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtCity">City:</label>
                                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtZipCode">Zip Code:</label>
                                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" placeholder="Zip Code"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtCountry">Country:<span>*</span></label>
                                        <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" placeholder="Country"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtNationalIdNumber">National Id Number:</label>
                                        <asp:TextBox ID="txtNationalIdNumber" runat="server" CssClass="form-control" placeholder="National Id Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtPassportNumber">Passport Number:</label>
                                        <asp:TextBox ID="txtPassportNumber" runat="server" CssClass="form-control" placeholder="Passport Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtDrivingLicenseNumber">Driving License Number:</label>
                                        <asp:TextBox ID="txtDrivingLicenseNumber" runat="server" CssClass="form-control" placeholder="Driving License umber"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtProfilePhoto">Profile Photo:</label>
                                        <asp:TextBox ID="txtProfilePhoto" runat="server" CssClass="form-control" placeholder="Profile Photo"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtPassword">Password:<span>*</span> </label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtConfirmPassword">Confirm Password:<span>*</span></label>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="ddlDesignation">Donor:<span>*</span></label>
                                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" placeholder="Designation" />
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer text-right">
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="btnClear_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
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
