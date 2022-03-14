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
    public partial class Service : System.Web.UI.Page
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
                    Response.Redirect("~/Account/ServiceList.aspx");
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
                ServiceBLL serviceBLL = new ServiceBLL();
                DataTable dt = serviceBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ServiceId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["ServiceCode"]);
                        txtTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                        txtAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
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
                ModelCode = CodePrefix.Service + "-" + lib.GetSixDigitNumber(1);
                ServiceBLL serviceBLL = new ServiceBLL();
                DataTable dt = serviceBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["ServiceCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Service + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtAmount.Text = string.Empty;

            txtTitle.Focus();
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
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    Alert(AlertType.Warning, "Enter title.");
                    txtTitle.Focus();
                }
                else if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    Alert(AlertType.Warning, "Enter amount.");
                    txtAmount.Focus();
                }
                else
                {
                    string title = Convert.ToString(txtTitle.Text);
                    string description = Convert.ToString(txtDescription.Text);
                    decimal amount = Convert.ToDecimal(txtAmount.Text);

                    ServiceBLL serviceBLL = new ServiceBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = serviceBLL.GetById(this.ModelId);
                        Services service = new Services();
                        service.ServiceId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ServiceId"]));
                        service.ServiceCode = Convert.ToString(dt.Rows[0]["ServiceCode"]);
                        service.Title = Convert.ToString(dt.Rows[0]["Title"]);
                        service.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        service.Amount = Convert.ToDecimal(Convert.ToString(dt.Rows[0]["Amount"]));
                        service.AmountStatus = Convert.ToString(dt.Rows[0]["AmountStatus"]);
                        service.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        service.CreatedDate = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        service.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        service.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        service.Title = title.Trim();
                        service.Description = description;
                        service.Amount = amount;

                        service.UpdatedDate = DateTime.Now;
                        service.UpdatedBy = this.UserInfo;
                        service.UpdatedFrom = this.StationInfo;

                        if (serviceBLL.Update(service))
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
                        Services service = new Services();
                        service.ServiceCode = this.ModelCode;
                        service.Title = title;
                        service.Description = description;
                        service.Amount = amount;
                        service.IsActive = true;
                        service.CreatedDate = DateTime.Now;
                        service.CreatedBy = this.UserInfo;
                        service.CreatedFrom = this.StationInfo;

                        if (serviceBLL.Save(service))
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