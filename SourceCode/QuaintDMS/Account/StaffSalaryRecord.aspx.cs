using QuaintDMS.Code.BLL;
using QuaintDMS.Code.Global;
using QuaintPark;
using QuaintDMS.Code.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintDMS.Account
{
    public partial class StaffSalaryRecord : System.Web.UI.Page
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
            CLearFields();
        }

        private void CLearFields()
        {
            txtStaffSalaryRecordCode.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtPreviousDue.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtPaidAmount.Text = string.Empty;
            txtDue.Text = string.Empty;
            ddlStaff.SelectedIndex = 0;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtStaffSalaryRecordCode.Text))
                {
                    Alert(AlertType.Warning, "Enter staff record code.");
                    txtStaffSalaryRecordCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtSalary.Text))
                {
                    Alert(AlertType.Warning, "Enter salary code.");
                    txtSalary.Focus();
                }
                else if (string.IsNullOrEmpty(txtPreviousDue.Text))
                {
                    Alert(AlertType.Warning, "Enter previous due.");
                    txtPreviousDue.Focus();
                }
                else if (string.IsNullOrEmpty(txtTotal.Text))
                {
                    Alert(AlertType.Warning, "Enter total.");
                    txtTotal.Focus();
                }
                else if (string.IsNullOrEmpty(txtPaidAmount.Text))
                {
                    Alert(AlertType.Warning, "Enter paid amount.");
                    txtPaidAmount.Focus();
                }
                else if (string.IsNullOrEmpty(txtDue.Text))
                {
                    Alert(AlertType.Warning, "Enter due.");
                    txtDue.Focus();
                }
                else if (string.IsNullOrEmpty(ddlStaff.SelectedValue))
                {
                    Alert(AlertType.Warning, "Select staff.");
                    ddlStaff.Focus();
                }
                else
                {
                    StaffSalaryRecords staffSalaryRecord = new StaffSalaryRecords();
                    staffSalaryRecord.StaffSalaryRecordCode = txtStaffSalaryRecordCode.Text.ToString();
                    staffSalaryRecord.Salary = Convert.ToDecimal(txtSalary);
                    staffSalaryRecord.PreviousDue = Convert.ToDecimal(txtPreviousDue);
                    staffSalaryRecord.Total = Convert.ToDecimal(txtTotal);
                    staffSalaryRecord.PaidAmount = Convert.ToDecimal(txtPaidAmount);
                    staffSalaryRecord.Due = Convert.ToDecimal(txtDue);
                    staffSalaryRecord.StaffSalaryRecordId = Convert.ToInt32(ddlStaff.SelectedValue);

                    StaffSalaryRecordBLL staffSalaryRecordBLL = new StaffSalaryRecordBLL();
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