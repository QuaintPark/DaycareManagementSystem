using QuaintDMS.Code.BLL;
using QuaintDMS.Code.Global;
using QuaintDMS.Code.Model;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintDMS.Account
{
    public partial class Child : System.Web.UI.Page
    {
        // Message Box Method(s)
        private void Alert(AlertType alertType, string message)
        {
            alertMessage.InnerHtml = Core.AlertBox(alertType, message);
            tmrAlertMessage.Enabled = true;
            tmrAlertMessage.Interval = Core.AlertBoxInternal;
        }

        protected void tmrAlertMessage_Tick(object sender, EventArgs e)
        {
            if (tmrAlertMessage.Interval == Core.AlertBoxInternal)
            {
                alertMessage.InnerHtml = string.Empty;
                tmrAlertMessage.Enabled = false;

                if (this.MultiEntryDisallow)
                {
                    Response.Redirect("~/Account/ChildList.aspx");
                }
            }
        }



        // View State(s)
        private string UserInfo
        {
            set { ViewState["UserInfo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["UserInfo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private string StationInfo
        {
            set { ViewState["StationInfo"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["StationInfo"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        public int ModelId
        {
            set { ViewState["Id"] = value; }
            get
            {
                try
                {
                    return Convert.ToInt32(Convert.ToString(ViewState["Id"]));
                }
                catch
                {
                    return 0;
                }
            }
        }
        private string ModelCode
        {
            set { ViewState["Code"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["Code"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        private bool MultiEntryDisallow
        {
            set { ViewState["MultiEntryDisallow"] = value; }
            get
            {
                try
                {
                    return Convert.ToBoolean(Convert.ToString(ViewState["MultiEntryDisallow"]));
                }
                catch
                {
                    return false;
                }
            }
        }
        private string ModelProfilePhoto
        {
            set { ViewState["ProfilePhoto"] = value; }
            get
            {
                try
                {
                    return Convert.ToString(ViewState["ProfilePhoto"]);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiEntryDisallow = false;
                //QuaintSessionManager session = new QuaintSessionManager();
                //UserInfo = Convert.ToString(session.ActiveUserInformation);
                //StationInfo = Convert.ToString(session.ActiveStationInformation);
                LoadMember();
                LoadProgram();

                if (Request.QueryString["Id"] != null)
                {
                    this.ModelId = Convert.ToInt32(QuaintSecurityManager.DecryptUrl(Convert.ToString(Request.QueryString["Id"])));
                    Edit(this.ModelId);
                    lblTitleStatus.Text = "Update";
                    btnSave.Text = "Update";
                    btnSaveAndContinue.Text = "Update & Continue";
                    btnSaveAndContinue.Visible = false;
                }
                else
                {
                    GenerateCode();
                }
            }
        }

        private void LoadMember()
        {
            try
            {
                MemberBLL memberBLL = new MemberBLL();
                DataTable dt = memberBLL.GetAll();
                ddlMember.DataSource = dt;
                ddlMember.DataTextField = "FullName";
                ddlMember.DataValueField = "MemberId";
                ddlMember.DataBind();

                ddlMember.Items.Insert(0, "--- Please Select ---");
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LoadProgram()
        {
            try
            {
                ProgramBLL programBLL = new ProgramBLL();
                DataTable dt = programBLL.GetAll();
                ddlProgram.DataSource = dt;
                ddlProgram.DataTextField = "TitleWithTotalAmount";
                ddlProgram.DataValueField = "ProgramId";
                ddlProgram.DataBind();

                ddlProgram.Items.Insert(0, "--- Please Select ---");
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void Edit(int id)
        {
            try
            {
                ChildBLL childBLL = new ChildBLL();
                DataTable dt = childBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ChildId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["ChildCode"]);
                        txtFirstName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
                        txtLastName.Text = Convert.ToString(dt.Rows[0]["LastName"]);
                        txtDateOfBirth.Text = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfBirth"]))) ? string.Empty : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["DateOfBirth"])).ToString("MM/dd/yyyy"));
                        txtAddressLine1.Text = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                        txtAddressLine2.Text = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                        txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
                        txtZipCode.Text = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ZipCode"]))) ? string.Empty : Convert.ToString(dt.Rows[0]["ZipCode"]));
                        txtCountry.Text = Convert.ToString(dt.Rows[0]["Country"]);
                        imgProfilePhoto.Src = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProfilePhoto"]))) ? "~/Assets/images/avater-public.png" : FilePath.Child + Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                        this.ModelProfilePhoto = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProfilePhoto"]))) ? string.Empty : Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                        txtFatherName.Text = Convert.ToString(dt.Rows[0]["FatherName"]);
                        txtFatherProfession.Text = Convert.ToString(dt.Rows[0]["FatherProfession"]);
                        txtFatherContactNumber.Text = Convert.ToString(dt.Rows[0]["FatherContactNumber"]);
                        txtMotherName.Text = Convert.ToString(dt.Rows[0]["MotherName"]);
                        txtMotherProfession.Text = Convert.ToString(dt.Rows[0]["MotherProfession"]); ;
                        txtMotherContactNumber.Text = Convert.ToString(dt.Rows[0]["MotherContactNumber"]);
                        txtLocalGuardianName.Text = Convert.ToString(dt.Rows[0]["LocalGuardianName"]);
                        txtLocalGuardianProfession.Text = Convert.ToString(dt.Rows[0]["LocalGuardianProfession"]);
                        txtLocalGuardianContactNumber.Text = Convert.ToString(dt.Rows[0]["LocalGuardianContactNumber"]);
                        txtLocalGuardianAddressLine1.Text = Convert.ToString(dt.Rows[0]["LocalGuardianAddressLine1"]);
                        txtLocalGuardianAddressLine2.Text = Convert.ToString(dt.Rows[0]["LocalGuardianAddressLine2"]);
                        ddlMember.SelectedValue = Convert.ToString(dt.Rows[0]["MemberId"]);
                        ddlProgram.SelectedValue = Convert.ToString(dt.Rows[0]["ProgramId"]);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to edit.");
            }
        }

        private void GenerateCode()
        {
            try
            {
                QuaintLibraryManager lib = new QuaintLibraryManager();
                ModelCode = CodePrefix.Child + "-" + lib.GetSixDigitNumber(1);
                ChildBLL childBLL = new ChildBLL();
                DataTable dt = childBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["ChildCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Child + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to load.");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtCountry.Text = string.Empty;
            imgProfilePhoto.Src = "~/Assets/images/avater-public.png";
            txtFatherName.Text = string.Empty;
            txtFatherProfession.Text = string.Empty;
            txtFatherContactNumber.Text = string.Empty;
            txtMotherName.Text = string.Empty;
            txtMotherProfession.Text = string.Empty;
            txtMotherContactNumber.Text = string.Empty;
            txtLocalGuardianName.Text = string.Empty;
            txtLocalGuardianProfession.Text = string.Empty;
            txtLocalGuardianContactNumber.Text = string.Empty;
            txtLocalGuardianAddressLine1.Text = string.Empty;
            txtLocalGuardianAddressLine2.Text = string.Empty;
            ddlMember.SelectedIndex = 0;
            ddlProgram.SelectedIndex = 0;

            txtFirstName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = true;
            SaveAndUpdate();
        }

        private void SaveAndUpdate()
        {
            try
            {
                if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    Alert(AlertType.Warning, "Enter first name.");
                    txtFirstName.Focus();
                }
                else if (string.IsNullOrEmpty(txtDateOfBirth.Text))
                {
                    Alert(AlertType.Warning, "Enter date of birth name.");
                    txtDateOfBirth.Focus();
                }
                else if (string.IsNullOrEmpty(txtFatherName.Text))
                {
                    Alert(AlertType.Warning, "Enter father name.");
                    txtFatherName.Focus();
                }
                else if (string.IsNullOrEmpty(txtMotherName.Text))
                {
                    Alert(AlertType.Warning, "Enter mother name.");
                    txtMotherName.Focus();
                }
                else if (ddlMember.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select member.");
                    ddlMember.Focus();
                }
                else if (ddlProgram.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select program.");
                    ddlProgram.Focus();
                }
                else
                {
                    QuaintLibraryManager lib = new QuaintLibraryManager();
                    string firstName = Convert.ToString(txtFirstName.Text);
                    string lastName = Convert.ToString(txtLastName.Text);
                    DateTime? dateOfBirth = (string.IsNullOrEmpty(txtDateOfBirth.Text)) ? (DateTime?)null : lib.ParseAppDateTime(Convert.ToString(txtDateOfBirth.Text), lib.GetAppDateTimeFormat());
                    string addressLine1 = Convert.ToString(txtAddressLine1.Text);
                    string addressLine2 = Convert.ToString(txtAddressLine2.Text);
                    string city = Convert.ToString(txtCity.Text);
                    int? zipCode = (string.IsNullOrEmpty(txtZipCode.Text)) ? (int?)null : Convert.ToInt32(txtZipCode.Text);
                    string country = Convert.ToString(txtCountry.Text);
                    string fatherName = Convert.ToString(txtFatherName.Text);
                    string fatherProfession = Convert.ToString(txtFatherProfession.Text);
                    string fatherContactNumber = Convert.ToString(txtFatherContactNumber.Text);
                    string motherName = Convert.ToString(txtMotherName.Text);
                    string motherProfession = Convert.ToString(txtMotherProfession.Text);
                    string motherContactNumber = Convert.ToString(txtMotherContactNumber.Text);
                    string localGuardianName = Convert.ToString(txtLocalGuardianName.Text);
                    string localGuardianProfession = Convert.ToString(txtLocalGuardianProfession.Text);
                    string localGuardianContactNumber = Convert.ToString(txtLocalGuardianContactNumber.Text);
                    string localGuardianAddress1 = Convert.ToString(txtLocalGuardianAddressLine1.Text);
                    string localGuardianAddress2 = Convert.ToString(txtLocalGuardianAddressLine2.Text);
                    int memberId = Convert.ToInt32(ddlMember.SelectedValue);
                    int programId = Convert.ToInt32(ddlProgram.SelectedValue);
                    string profilePhoto = string.Empty;
                    if (fuProfilePhoto.HasFile)
                        profilePhoto = UploadProfilePhoto();
                    else
                        profilePhoto = this.ModelProfilePhoto;

                    ChildBLL childBLL = new ChildBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = childBLL.GetById(this.ModelId);
                        Childs child = new Childs();
                        child.ChildId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ChildId"]));
                        child.ChildCode = Convert.ToString(dt.Rows[0]["ChildCode"]);
                        child.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                        child.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                        child.DateOfBirth = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfBirth"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["DateOfBirth"]));
                        child.AddressLine1 = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                        child.AddressLine2 = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                        child.City = Convert.ToString(dt.Rows[0]["City"]);
                        child.ZipCode = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ZipCode"]))) ? (int?)null : Convert.ToInt32(Convert.ToString(dt.Rows[0]["ZipCode"])));
                        child.Country = Convert.ToString(dt.Rows[0]["Country"]);
                        child.ProfilePhoto = Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                        child.FatherName = Convert.ToString(dt.Rows[0]["FatherName"]);
                        child.FatherProfession = Convert.ToString(dt.Rows[0]["FatherProfession"]);
                        child.FatherContactNumber = Convert.ToString(dt.Rows[0]["FatherContactNumber"]);
                        child.MotherName = Convert.ToString(dt.Rows[0]["MotherName"]);
                        child.MotherProfession = Convert.ToString(dt.Rows[0]["MotherProfession"]);
                        child.MotherContactNumber = Convert.ToString(dt.Rows[0]["MotherContactNumber"]);
                        child.LocalGuardianName = Convert.ToString(dt.Rows[0]["LocalGuardianName"]);
                        child.LocalGuardianProfession = Convert.ToString(dt.Rows[0]["LocalGuardianProfession"]);
                        child.LocalGuardianContactNumber = Convert.ToString(dt.Rows[0]["LocalGuardianContactNumber"]);
                        child.LocalGuardianAddressLine1 = Convert.ToString(dt.Rows[0]["LocalGuardianAddressLine1"]);
                        child.LocalGuardianAddressLine2 = Convert.ToString(dt.Rows[0]["LocalGuardianAddressLine2"]);
                        child.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        child.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        child.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        child.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);
                        child.MemberId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["MemberId"]));
                        child.ProgramId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ProgramId"]));

                        child.FirstName = firstName;
                        child.LastName = lastName;
                        child.DateOfBirth = dateOfBirth;
                        child.AddressLine1 = addressLine1;
                        child.AddressLine2 = addressLine2;
                        child.City = city;
                        child.ZipCode = zipCode;
                        child.Country = country;
                        child.ProfilePhoto = profilePhoto;
                        child.FatherName = fatherName;
                        child.FatherProfession = fatherProfession;
                        child.FatherContactNumber = fatherContactNumber;
                        child.MotherName = motherName;
                        child.MotherProfession = motherProfession;
                        child.MotherContactNumber = motherContactNumber;
                        child.LocalGuardianName = localGuardianName;
                        child.LocalGuardianProfession = localGuardianProfession;
                        child.LocalGuardianContactNumber = localGuardianContactNumber;
                        child.LocalGuardianAddressLine1 = localGuardianAddress1;
                        child.LocalGuardianAddressLine2 = localGuardianAddress2;
                        child.MemberId = memberId;
                        child.ProgramId = programId;

                        child.UpdatedDate = DateTime.Now;
                        child.UpdatedBy = this.UserInfo;
                        child.UpdatedFrom = this.StationInfo;

                        if (childBLL.Update(child))
                        {
                            this.MultiEntryDisallow = true;
                            Alert(AlertType.Success, "Updated successfully.");
                            ClearFields();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to update.");
                        }
                    }
                    else
                    {
                        Childs child = new Childs();
                        child.ChildCode = this.ModelCode;
                        child.FirstName = firstName;
                        child.LastName = lastName;
                        child.DateOfBirth = dateOfBirth;
                        child.AddressLine1 = addressLine1;
                        child.AddressLine2 = addressLine2;
                        child.City = city;
                        child.ZipCode = zipCode;
                        child.Country = country;
                        child.ProfilePhoto = profilePhoto;
                        child.FatherName = fatherName;
                        child.FatherProfession = fatherProfession;
                        child.FatherContactNumber = fatherContactNumber;
                        child.MotherName = motherName;
                        child.MotherProfession = motherProfession;
                        child.MotherContactNumber = motherContactNumber;
                        child.LocalGuardianName = localGuardianName;
                        child.LocalGuardianProfession = localGuardianProfession;
                        child.LocalGuardianContactNumber = localGuardianContactNumber;
                        child.LocalGuardianAddressLine1 = localGuardianAddress1;
                        child.LocalGuardianAddressLine2 = localGuardianAddress2;
                        child.IsActive = true;
                        child.CreatedDate = DateTime.Now;
                        child.CreatedBy = this.UserInfo;
                        child.CreatedFrom = this.StationInfo;
                        child.MemberId = memberId;
                        child.ProgramId = programId;

                        if (childBLL.Save(child))
                        {
                            Alert(AlertType.Success, "Saved successfully.");
                            ClearFields();
                            GenerateCode();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to save.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(AlertType.Error, ex.Message.ToString());
            }
        }

        private string UploadProfilePhoto()
        {
            try
            {
                if (fuProfilePhoto.HasFile)
                {
                    string filExtention = Path.GetExtension(fuProfilePhoto.FileName).ToLower();
                    this.ModelProfilePhoto = this.ModelCode + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + filExtention;

                    if (filExtention == ".jpg" || filExtention == ".jpeg" || filExtention == ".png" || filExtention == ".gif")
                    {
                        fuProfilePhoto.SaveAs(Server.MapPath(FilePath.Child + this.ModelProfilePhoto));
                    }
                }

                return this.ModelProfilePhoto;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = false;
            SaveAndUpdate();
        }
    }
}