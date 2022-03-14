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
    public partial class Staff : System.Web.UI.Page
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
                    Response.Redirect("~/Account/StaffList.aspx");
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
                LoadDesignation();

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

        private void LoadDesignation()
        {
            try
            {
                DesignationBLL designationBLL = new DesignationBLL();
                DataTable dt = designationBLL.GetAll();
                ddlDesignation.DataSource = dt;
                ddlDesignation.DataTextField = "Name";
                ddlDesignation.DataValueField = "DesignationId";
                ddlDesignation.DataBind();

                ddlDesignation.Items.Insert(0, "--- Please Select ---");
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
                StaffBLL staffBLL = new StaffBLL();
                DataTable dt = staffBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["StaffId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["StaffCode"]);
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
                        imgProfilePhoto.Src = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProfilePhoto"]))) ? "~/Assets/images/avater-public.png" : FilePath.Employee + Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                        this.ModelProfilePhoto = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ProfilePhoto"]))) ? string.Empty : Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                        ddlDesignation.SelectedValue = Convert.ToString(dt.Rows[0]["DesignationId"]);
                        txtJoiningDate.Text = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["JoiningDate"]))) ? string.Empty : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["JoiningDate"])).ToString("MM/dd/yyyy"));
                        txtSalary.Text = Convert.ToString(dt.Rows[0]["Salary"]);
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
                ModelCode = CodePrefix.Employee + "-" + lib.GetSixDigitNumber(1);
                StaffBLL staffBLL = new StaffBLL();
                DataTable dt = staffBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["StaffCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Employee + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            ddlDesignation.SelectedIndex = 0;
            txtJoiningDate.Text = string.Empty;
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
                else if (ddlDesignation.SelectedIndex < 1)
                {
                    Alert(AlertType.Warning, "Select designation.");
                    ddlDesignation.Focus();
                }
                else if (string.IsNullOrEmpty(txtSalary.Text))
                {
                    Alert(AlertType.Warning, "Enter salary.");
                    txtSalary.Focus();
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
                        DateTime? joiningDate = (string.IsNullOrEmpty(txtJoiningDate.Text)) ? (DateTime?)null : lib.ParseAppDateTime(Convert.ToString(txtJoiningDate.Text), lib.GetAppDateTimeFormat());
                        decimal salary = Convert.ToDecimal(txtSalary.Text);
                        string password = Convert.ToString(txtPassword.Text);
                        int designationId = Convert.ToInt32(ddlDesignation.SelectedValue);
                        string profilePhoto = string.Empty;
                        if (fuProfilePhoto.HasFile)
                            profilePhoto = UploadProfilePhoto();
                        else
                            profilePhoto = this.ModelProfilePhoto;

                        StaffBLL staffBLL = new StaffBLL();
                        if (this.ModelId > 0)
                        {
                            DataTable dt = staffBLL.GetById(this.ModelId);
                            Staffs staff = new Staffs();
                            staff.StaffId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["StaffId"]));
                            staff.StaffCode = Convert.ToString(dt.Rows[0]["StaffCode"]);
                            staff.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                            staff.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                            staff.DateOfBirth = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfBirth"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["DateOfBirth"]));
                            staff.Email = Convert.ToString(dt.Rows[0]["Email"]);
                            staff.ContactNumber = Convert.ToString(dt.Rows[0]["ContactNumber"]);
                            staff.AddressLine1 = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                            staff.AddressLine2 = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                            staff.City = Convert.ToString(dt.Rows[0]["City"]);
                            staff.ZipCode = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ZipCode"]))) ? (int?)null : Convert.ToInt32(Convert.ToString(dt.Rows[0]["ZipCode"])));
                            staff.Country = Convert.ToString(dt.Rows[0]["Country"]);
                            staff.NationalIdNumber = Convert.ToString(dt.Rows[0]["NationalIdNumber"]);
                            staff.PassportNumber = Convert.ToString(dt.Rows[0]["PassportNumber"]);
                            staff.DrivingLicenseNumber = Convert.ToString(dt.Rows[0]["DrivingLicenseNumber"]);
                            staff.ProfilePhoto = Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                            staff.JoiningDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["JoiningDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["JoiningDate"]));
                            staff.Salary = Convert.ToDecimal(Convert.ToString(dt.Rows[0]["Salary"]));
                            staff.AmountStatus = Convert.ToString(dt.Rows[0]["AmountStatus"]);
                            staff.CurrentStatus = Convert.ToString(dt.Rows[0]["CurrentStatus"]);
                            staff.Password = QuaintSecurityManager.Encrypt(Convert.ToString(dt.Rows[0]["Password"]));
                            staff.PasswordStamp = Convert.ToString(dt.Rows[0]["PasswordStamp"]);
                            staff.SecurityQuestion = Convert.ToString(dt.Rows[0]["SecurityQuestion"]);
                            staff.SecurityAnswer = Convert.ToString(dt.Rows[0]["SecurityAnswer"]);
                            staff.IsVerified = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsVerified"]));
                            staff.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            staff.DesignationId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["DesignationId"]));
                            staff.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            staff.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            staff.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                            staff.FirstName = firstName;
                            staff.LastName = lastName;
                            staff.DateOfBirth = dateOfBirth;
                            staff.Email = email;
                            staff.ContactNumber = contactNumber;
                            staff.AddressLine1 = addressLine1;
                            staff.AddressLine2 = addressLine2;
                            staff.City = city;
                            staff.ZipCode = zipCode;
                            staff.Country = country;
                            staff.NationalIdNumber = nationalIdNumber;
                            staff.PassportNumber = passportNumber;
                            staff.DrivingLicenseNumber = drivingLicenseNumber;
                            staff.ProfilePhoto = profilePhoto;
                            staff.JoiningDate = joiningDate;
                            staff.Salary = salary;
                            staff.AmountStatus = "Expense";
                            staff.CurrentStatus = "Online";
                            staff.Password = QuaintSecurityManager.Encrypt(password);
                            staff.DesignationId = designationId;

                            staff.UpdatedDate = DateTime.Now;
                            staff.UpdatedBy = this.UserInfo;
                            staff.UpdatedFrom = this.StationInfo;

                            if (staffBLL.Update(staff))
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
                            Staffs staff = new Staffs();
                            staff.StaffCode = this.ModelCode;
                            staff.FirstName = firstName;
                            staff.LastName = lastName;
                            staff.DateOfBirth = dateOfBirth;
                            staff.Email = email;
                            staff.ContactNumber = contactNumber;
                            staff.AddressLine1 = addressLine1;
                            staff.AddressLine2 = addressLine2;
                            staff.City = city;
                            staff.ZipCode = zipCode;
                            staff.Country = country;
                            staff.NationalIdNumber = nationalIdNumber;
                            staff.PassportNumber = passportNumber;
                            staff.DrivingLicenseNumber = drivingLicenseNumber;
                            staff.ProfilePhoto = profilePhoto;
                            staff.JoiningDate = joiningDate;
                            staff.Salary = salary;
                            staff.Password = QuaintSecurityManager.Encrypt(password);
                            staff.DesignationId = designationId;
                            staff.IsVerified = true;
                            staff.IsActive = true;
                            staff.CreatedDate = DateTime.Now;
                            staff.CreatedBy = this.UserInfo;
                            staff.CreatedFrom = this.StationInfo;

                            if (staffBLL.Save(staff))
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
                        fuProfilePhoto.SaveAs(Server.MapPath(FilePath.Employee + this.ModelProfilePhoto));
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