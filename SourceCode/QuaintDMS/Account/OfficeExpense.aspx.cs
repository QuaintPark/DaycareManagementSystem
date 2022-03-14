using QuaintDMS.Code.BLL;
using QuaintDMS.Code.Global;
using QuaintDMS.Code.Model;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintDMS.Account
{
    public partial class OfficeExpense : System.Web.UI.Page
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
                    Response.Redirect("~/Account/OfficeExpenseList.aspx");
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
                OfficeExpensesBLL officeExpensesBLL = new OfficeExpensesBLL();
                DataTable dt = officeExpensesBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["OfficeExpenseId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["OfficeExpenseCode"]);
                        txtReference.Text = Convert.ToString(dt.Rows[0]["Reference"]);
                        txtAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
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
                ModelCode = CodePrefix.Expense + "-" + lib.GetSixDigitNumber(1);
                OfficeExpensesBLL officeExpensesBLL = new OfficeExpensesBLL();
                DataTable dt = officeExpensesBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["OfficeExpenseCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Expense + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtReference.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtDescription.Text = string.Empty;

            txtReference.Focus();
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
                if (string.IsNullOrEmpty(txtReference.Text))
                {
                    Alert(AlertType.Warning, "Enter reference.");
                    txtReference.Focus();
                }
                else if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    Alert(AlertType.Warning, "Enter amount.");
                    txtAmount.Focus();
                }
                else
                {
                    string reference = Convert.ToString(txtReference.Text);
                    decimal amount = Convert.ToDecimal(txtAmount.Text);
                    string description = Convert.ToString(txtDescription.Text);

                    OfficeExpensesBLL officeExpensesBLL = new OfficeExpensesBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = officeExpensesBLL.GetById(this.ModelId);
                        OfficeExpenses officeExpense = new OfficeExpenses();
                        officeExpense.OfficeExpenseId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["OfficeExpenseId"]));
                        officeExpense.OfficeExpenseCode = Convert.ToString(dt.Rows[0]["OfficeExpenseCode"]);
                        officeExpense.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        officeExpense.Amount = Convert.ToDecimal(Convert.ToString(dt.Rows[0]["Amount"]));
                        officeExpense.AmountStatus = Convert.ToString(dt.Rows[0]["AmountStatus"]);
                        officeExpense.Reference = Convert.ToString(dt.Rows[0]["Reference"]);
                        officeExpense.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        officeExpense.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        officeExpense.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        officeExpense.Description = description;
                        officeExpense.Amount = amount;
                        officeExpense.Reference = reference;

                        officeExpense.UpdatedDate = DateTime.Now;
                        officeExpense.UpdatedBy = this.UserInfo;
                        officeExpense.UpdatedFrom = this.StationInfo;

                        if (officeExpensesBLL.Update(officeExpense))
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
                        OfficeExpenses officeExpense = new OfficeExpenses();
                        officeExpense.OfficeExpenseCode = this.ModelCode;
                        officeExpense.Description = description;
                        officeExpense.Amount = amount;
                        officeExpense.AmountStatus = "Expense";
                        officeExpense.Reference = reference;
                        officeExpense.CreatedDate = DateTime.Now;
                        officeExpense.CreatedBy = this.UserInfo;
                        officeExpense.CreatedFrom = this.StationInfo;

                        if (officeExpensesBLL.Save(officeExpense))
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

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = false;
            SaveAndUpdate();
        }
    }
}