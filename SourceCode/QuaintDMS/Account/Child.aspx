<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="Child.aspx.cs" Inherits="QuaintDMS.Account.Child" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    <asp:Literal runat="server" Text="Child"></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="headerContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1>Child</h1>
                <ol class="breadcrumb">
                    <li>
                        <span id="workingBar" runat="server" visible="false" class="working-bar"><i class="fa fa-spinner fa-pulse fa-fw"></i>Working...</span>
                        <a runat="server" href="~/Account/ChildList.aspx" class="btn btn-default"><i class="fa fa-list-alt"></i>List</a>
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
                                    Child</h3>
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
                                                <label for="txtFirstName">First Name:<span>*</span></label>
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name" required="required"></asp:TextBox>
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
                                                <label for="txtAddressLine1">Address Line 1:<span>*</span></label>
                                                <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="form-control" placeholder="Address Line 1" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtAddressLine2">Address Line 2:</label>
                                                <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control" placeholder="Address Line 2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtDateOfBirth">Date of Birth:<span>*</span></label>
                                                <div class="input-group date">
                                                    <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control datepicker" placeholder="mm/dd/yyyy" required="required"></asp:TextBox>
                                                    <div class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </div>
                                                </div>
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
                                                <label for="txtCountry">Country:</label>
                                                <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" placeholder="Country"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtFatherName">Father Name:<span>*</span></label>
                                                <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control" placeholder="Father Name" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtFatherProfession">Father Profession:</label>
                                                <asp:TextBox ID="txtFatherProfession" runat="server" CssClass="form-control" placeholder="Father Profession"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtFatherContactNumber">Father Contact Number:</label>
                                                <asp:TextBox ID="txtFatherContactNumber" runat="server" CssClass="form-control" placeholder="Father Contact Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtMotherName">Mother Name:<span>*</span></label>
                                                <asp:TextBox ID="txtMotherName" runat="server" CssClass="form-control" placeholder="Mother Name" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtMotherProfession">Mother Profession:</label>
                                                <asp:TextBox ID="txtMotherProfession" runat="server" CssClass="form-control" placeholder="Mother Profession"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtMotherContactNumber">Mother Contact Number:</label>
                                                <asp:TextBox ID="txtMotherContactNumber" runat="server" CssClass="form-control" placeholder="Mother Contact Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLocalGuardianName">Local Guardian Name:</label>
                                                <asp:TextBox ID="txtLocalGuardianName" runat="server" CssClass="form-control" placeholder="Local Guardian Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLocalGuardianProfession">Local Guardian Profession:</label>
                                                <asp:TextBox ID="txtLocalGuardianProfession" runat="server" CssClass="form-control" placeholder="Local Guardian Profession"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLocalGuardianAddressLine1">Local Guardian Address Line 1:</label>
                                                <asp:TextBox ID="txtLocalGuardianAddressLine1" runat="server" CssClass="form-control" placeholder="Local Guardian AddressLine 1"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLocalGuardianAddressLine2">Local Guardian Address Line 2:</label>
                                                <asp:TextBox ID="txtLocalGuardianAddressLine2" runat="server" CssClass="form-control" placeholder="Local Guardian AddressLine 2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLocalGuardianContactNumber">Local Guardian Contact Number:</label>
                                                <asp:TextBox ID="txtLocalGuardianContactNumber" runat="server" CssClass="form-control" placeholder="Local Guardian Contact Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-sm-4 pull-right text-center">
                                                        <img id="imgProfilePhoto" runat="server" class="img-preview" src="~/Assets/images/avater-public.png" />
                                                    </div>
                                                    <div class="col-sm-8 section-pp">
                                                        <label for="fuProfilePhoto">Profile Photo:</label>
                                                        <asp:FileUpload ID="fuProfilePhoto" runat="server" CssClass="form-control" onchange="PreviewImage(this);" accept=".jpg, .jpeg, .png, .gif" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fuProfilePhoto" ErrorMessage="Allow: jpg, jpeg, png, gif files" CssClass="msgError" ValidationExpression="(.*\.([Gg][Ii][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([pP][nN][gG])$)"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlMember">Member:<span>*</span></label>
                                                <asp:DropDownList ID="ddlMember" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMember" ErrorMessage="Select member" CssClass="msgError" InitialValue="--- Please Select ---"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlProgram">Program:<span>*</span></label>
                                                <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control" AutoPostBack="false"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProgram" ErrorMessage="Select program" CssClass="msgError" InitialValue="--- Please Select ---"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer" id="alertMessage" runat="server">
                            </div>
                            <div class="box-footer text-right">
                                <p class="pull-left conditions">* Mandatory field</p>
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" OnClick="btnClear_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSaveAndContinue" runat="server" Text="Save & Continue" CssClass="btn btn-primary" OnClick="btnSaveAndContinue_Click" />
                            </div>
                        </div>
                    </div>
            </section>

            <asp:Timer ID="tmrAlertMessage" runat="server" Enabled="False" OnTick="tmrAlertMessage_Tick"></asp:Timer>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnSaveAndContinue" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footerContentPlaceHolder" runat="server">
    <script type="text/javascript">
        // Preview Profile Photo
        function PreviewImage(input) {
            var isValidFile = CheckFile(input);
            if (isValidFile) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%= imgProfilePhoto.ClientID %>').prop('src', e.target.result).width(110).height(140);
                    };
                    reader.readAsDataURL(input.files[0]);
                }
            }
            else {
                $('#<%= imgProfilePhoto.ClientID %>').prop('src', '../Assets/images/avater-public.png').width(110).height(140);
            }
        }
    </script>
</asp:Content>
