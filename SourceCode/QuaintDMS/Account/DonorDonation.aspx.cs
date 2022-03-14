using QuaintDMS.Code.BLL;
using QuaintDMS.Code.Global;
using QuaintDMS.Code.Model;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintDMS.Account
{
    public partial class DonorDonation : System.Web.UI.Page
    {

        //Message Box
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
            ClearFields();
        }

        private void ClearFields()
        {
            txtDonorDonationCode.Text = string.Empty;
            txtDonationAmount.Text = string.Empty;
            txtDonationDate.Text = string.Empty;
            ddlDonor.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDonorDonationCode.Text))
                {
                    Alert(AlertType.Warning, "Enter donor donation code.");
                    txtDonorDonationCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtDonationAmount.Text))
                {
                    Alert(AlertType.Warning, "Enter donation amount.");
                    txtDonationAmount.Focus();
                }
                else if (string.IsNullOrEmpty(txtDonationDate.Text))
                {
                    Alert(AlertType.Warning, "Enter donation date.");
                    txtDonationDate.Focus();
                }
                else if (string.IsNullOrEmpty(ddlDonor.SelectedValue))
                {
                    Alert(AlertType.Warning, "Select donor.");
                    ddlDonor.Focus();
                }

                else
                {
                    DonorDonations donorDonation = new DonorDonations();
                    donorDonation.DonorDonationCode = txtDonorDonationCode.Text.ToString();
                    donorDonation.DonationAmount = Convert.ToInt32(txtDonationAmount);
                    donorDonation.DonationDate = Convert.ToDateTime(txtDonationDate);
                    donorDonation.DonorId = Convert.ToInt32(ddlDonor.SelectedValue);

                    DonorDonationBLL donorDonationBLL = new DonorDonationBLL();
                    if (true)
                    {
                        Alert(AlertType.Success, "Updated successfully.");
                    }
                    else
                    {
                        Alert(AlertType.Success, "Saved successfully.");
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