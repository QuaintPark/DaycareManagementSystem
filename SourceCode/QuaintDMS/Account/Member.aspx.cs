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
    public partial class Member : System.Web.UI.Page
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
                    Response.Redirect("~/Account/MemberList.aspx");
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
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);

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

        private void Edit(int id)
        {
            try
            {
                MemberBLL memberBLL = new MemberBLL();
                DataTable dt = memberBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["MemberId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["MemberCode"]);
                        txtFirstName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
                        txtLastName.Text = Convert.ToString(dt.Rows[0]["LastName"]);
                        txtDateOfBirth.Text = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfBirth"]))) ? string.Empty : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["DateOfBirth"])).ToString("MM/dd/yyyy"));
                        txtEmail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                        txtContactNumber.Text = Convert.ToString(dt.Rows[0]["ContactNumber"]);
                        txtAddressLine1.Text = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                        txtAddressLine2.Text = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                        txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
                        txtZipCode.Text = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ZipCode"]))) ? string.Empty : Convert.ToString(dt.Rows[0]["ZipCode"]));
                        txtCountry.Text = Convert.ToString(dt.Rows[0]["Country"]);
                        txtNationalIdNumber.Text = Convert.ToString(dt.Rows[0]["NationalIdNumber"]);
                        txtPassportNumber.Text = Convert.ToString(dt.Rows[0]["PassportNumber"]);
                        txtDrivingLicenseNumber.Text = Convert.ToString(dt.Rows[0]["DrivingLicenseNumber"]);
                        imgProfilePhoto.Src = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProfilePhoto"]))) ? "~/Assets/images/avater-public.png" : FilePath.Member + Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                        this.ModelProfilePhoto = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProfilePhoto"]))) ? string.Empty : Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                        txtPassword.Text = Convert.ToString(QuaintSecurityManager.Decrypt(Convert.ToString(dt.Rows[0]["Password"])));
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
                ModelCode = CodePrefix.Member + "-" + lib.GetSixDigitNumber(1);
                MemberBLL memberBLL = new MemberBLL();
                DataTable dt = memberBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["MemberCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Member + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtEmail.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtNationalIdNumber.Text = string.Empty;
            txtPassportNumber.Text = string.Empty;
            txtDrivingLicenseNumber.Text = string.Empty;
            fuProfilePhoto.Attributes.Clear();
            imgProfilePhoto.Src = "~/Assets/images/avater-public.png";
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;

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
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    Alert(AlertType.Warning, "Enter email.");
                    txtEmail.Focus();
                }
                else if (string.IsNullOrEmpty(txtAddressLine1.Text))
                {
                    Alert(AlertType.Warning, "Enter address line 1.");
                    txtAddressLine1.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    Alert(AlertType.Warning, "Enter password.");
                    txtPassword.Focus();
                }
                else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    Alert(AlertType.Warning, "Enter confirm password.");
                    txtConfirmPassword.Focus();
                }
                else
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        Alert(AlertType.Warning, "Password does not match.");
                        txtConfirmPassword.Focus();
                    }
                    else
                    {
                        QuaintLibraryManager lib = new QuaintLibraryManager();
                        string firstName = Convert.ToString(txtFirstName.Text);
                        string lastName = Convert.ToString(txtLastName.Text);
                        DateTime? dateOfBirth = (string.IsNullOrEmpty(txtDateOfBirth.Text)) ? (DateTime?)null : lib.ParseAppDateTime(Convert.ToString(txtDateOfBirth.Text), lib.GetAppDateTimeFormat());
                        string email = Convert.ToString(txtEmail.Text);
                        string contactNumber = Convert.ToString(txtContactNumber.Text);
                        string addressLine1 = Convert.ToString(txtAddressLine1.Text);
                        string addressLine2 = Convert.ToString(txtAddressLine2.Text);
                        string city = Convert.ToString(txtCity.Text);
                        int? zipCode = (string.IsNullOrEmpty(txtZipCode.Text)) ? (int?)null : Convert.ToInt32(txtZipCode.Text);
                        string country = Convert.ToString(txtCountry.Text);
                        string nationalIdNumber = Convert.ToString(txtNationalIdNumber.Text);
                        string passportNumber = Convert.ToString(txtPassportNumber.Text);
                        string drivingLicenseNumber = Convert.ToString(txtDrivingLicenseNumber.Text);
                        string password = Convert.ToString(txtPassword.Text);
                        string profilePhoto = string.Empty;
                        if (fuProfilePhoto.HasFile)
                            profilePhoto = UploadProfilePhoto();
                        else
                            profilePhoto = this.ModelProfilePhoto;

                        MemberBLL memberBLL = new MemberBLL();
                        if (this.ModelId > 0)
                        {
                            DataTable dt = memberBLL.GetById(this.ModelId);
                            Members member = new Members();
                            member.MemberId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["MemberId"]));
                            member.MemberCode = Convert.ToString(dt.Rows[0]["MemberCode"]);
                            member.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                            member.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                            member.DateOfBirth = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfBirth"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["DateOfBirth"]));
                            member.Email = Convert.ToString(dt.Rows[0]["Email"]);
                            member.ContactNumber = Convert.ToString(dt.Rows[0]["ContactNumber"]);
                            member.AddressLine1 = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                            member.AddressLine2 = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                            member.City = Convert.ToString(dt.Rows[0]["City"]);
                            member.ZipCode = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ZipCode"]))) ? (int?)null : Convert.ToInt32(Convert.ToString(dt.Rows[0]["ZipCode"])));
                            member.Country = Convert.ToString(dt.Rows[0]["Country"]);
                            member.NationalIdNumber = Convert.ToString(dt.Rows[0]["NationalIdNumber"]);
                            member.PassportNumber = Convert.ToString(dt.Rows[0]["PassportNumber"]);
                            member.DrivingLicenseNumber = Convert.ToString(dt.Rows[0]["DrivingLicenseNumber"]);
                            member.ProfilePhoto = Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                            member.CurrentStatus = Convert.ToString(dt.Rows[0]["CurrentStatus"]);
                            member.Password = QuaintSecurityManager.Encrypt(Convert.ToString(dt.Rows[0]["Password"]));
                            member.PasswordStamp = Convert.ToString(dt.Rows[0]["PasswordStamp"]);
                            member.SecurityQuestion = Convert.ToString(dt.Rows[0]["SecurityQuestion"]);
                            member.SecurityAnswer = Convert.ToString(dt.Rows[0]["SecurityAnswer"]);
                            member.IsVerified = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsVerified"]));
                            member.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            member.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            member.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            member.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                            member.FirstName = firstName;
                            member.LastName = lastName;
                            member.DateOfBirth = dateOfBirth;
                            member.Email = email;
                            member.ContactNumber = contactNumber;
                            member.AddressLine1 = addressLine1;
                            member.AddressLine2 = addressLine2;
                            member.City = city;
                            member.ZipCode = zipCode;
                            member.Country = country;
                            member.NationalIdNumber = nationalIdNumber;
                            member.PassportNumber = passportNumber;
                            member.DrivingLicenseNumber = drivingLicenseNumber;
                            member.ProfilePhoto = profilePhoto;
                            member.CurrentStatus = "Online";
                            member.Password = QuaintSecurityManager.Encrypt(password);

                            member.UpdatedDate = DateTime.Now;
                            member.UpdatedBy = this.UserInfo;
                            member.UpdatedFrom = this.StationInfo;

                            if (memberBLL.Update(member))
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
                            Members member = new Members();
                            member.MemberCode = this.ModelCode;
                            member.FirstName = firstName;
                            member.LastName = lastName;
                            member.DateOfBirth = dateOfBirth;
                            member.Email = email;
                            member.ContactNumber = contactNumber;
                            member.AddressLine1 = addressLine1;
                            member.AddressLine2 = addressLine2;
                            member.City = city;
                            member.ZipCode = zipCode;
                            member.Country = country;
                            member.NationalIdNumber = nationalIdNumber;
                            member.PassportNumber = passportNumber;
                            member.DrivingLicenseNumber = drivingLicenseNumber;
                            member.ProfilePhoto = profilePhoto;
                            member.Password = QuaintSecurityManager.Encrypt(password);
                            member.IsVerified = true;
                            member.IsActive = true;
                            member.CreatedDate = DateTime.Now;
                            member.CreatedBy = this.UserInfo;
                            member.CreatedFrom = this.StationInfo;

                            if (memberBLL.Save(member))
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
                        fuProfilePhoto.SaveAs(Server.MapPath(FilePath.Member + this.ModelProfilePhoto));
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