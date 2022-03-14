using QuaintDMS.Code.Global;
using QuaintPark;
using QuaintDMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuaintDMS.Code.BLL;

namespace QuaintDMS.Account
{
    public partial class Donor : System.Web.UI.Page
    {

        // Message Box
        private void Alert(AlertType alertType, string message)
        {
            Core.AlertBox(this.Page, this.GetType(), alertType, message);
        }

        // View State
        private string UserInfo
        {
            set { ViewState["UserInfo"] = value; }
            get
            {
                try
                {
                    return ViewState["UserInfo"].ToString();
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
                    return ViewState["StationInfo"].ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = session.ActiveUserInformation.ToString();
                StationInfo = session.ActiveStationInformation.ToString();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFileds();
        }

        private void ClearFileds()
        {
            txtDonorCode.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtdateOfBirth.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContactNumber.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtNationalIdNumber.Text = string.Empty;
            txtPassportNumber.Text = string.Empty;
            txtDrivingLicenseNumber.Text = string.Empty;
            txtProfilePhoto.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            ddlDesignation.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDonorCode.Text))
                {
                    Alert(AlertType.Warning, "Enter donor code.");
                    txtDonorCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    Alert(AlertType.Warning, "Enter first name.");
                    txtFirstName.Focus();
                }
                else if (string.IsNullOrEmpty(txtAddressLine1.Text))
                {
                    Alert(AlertType.Warning, "Enter address line 1.");
                    txtAddressLine1.Focus();
                }
                else if (string.IsNullOrEmpty(txtCountry.Text))
                {
                    Alert(AlertType.Warning, "Enter country name.");
                    txtCountry.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    Alert(AlertType.Warning, "Enter password.");
                    txtPassword.Focus();
                }
                else if (string.IsNullOrEmpty(ddlDesignation.SelectedValue))
                {
                    Alert(AlertType.Warning, "Select designation");
                    ddlDesignation.Focus();
                }

                else
                {
                    Donors donor = new Donors();
                    donor.DonorCode = txtDonorCode.Text.ToString();
                    donor.FirstName = txtFirstName.Text.ToString();
                    donor.LastName = txtLastName.Text.ToString();
                    donor.DateOfBirth = Convert.ToDateTime(txtdateOfBirth);
                    donor.Email = txtEmail.Text.ToString();
                    donor.ContactNumber = txtContactNumber.Text.ToString();
                    donor.AddressLine1 = txtAddressLine1.Text.ToString();
                    donor.AddressLine2 = txtAddressLine2.Text.ToString();
                    donor.City = txtCity.Text.ToString();
                    donor.ZipCode = Convert.ToInt32(txtZipCode);
                    donor.Country = txtCountry.Text.ToString();
                    donor.NationalIdNumber = txtNationalIdNumber.Text.ToString();
                    donor.PassportNumber = txtPassportNumber.ToString();
                    donor.DrivingLicenseNumber = txtDrivingLicenseNumber.Text.ToString();
                    donor.ProfilePhoto = txtProfilePhoto.Text.ToString();
                    donor.Password = txtPassword.Text.ToString();
                    donor.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);

                    DonorBLL donorBLL = new DonorBLL();
                    if (true)
                    {
                        Alert(AlertType.Success, "Updated Successfully.");
                    }
                    else
                    {
                        Alert(AlertType.Success, "Saved Successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(AlertType.Error, ex.Message.ToString());
            }
        }
    }
}