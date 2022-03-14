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
    public partial class Program : System.Web.UI.Page
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
                    Response.Redirect("~/Account/ProgramList.aspx");
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
        private List<ServicesModel> ServiceList
        {
            set { ViewState["ServiceList"] = value; }
            get
            {
                try
                {
                    if ((List<ServicesModel>)ViewState["ServiceList"] == null)
                    {
                        return null;
                    }
                    else
                    {
                        return (List<ServicesModel>)ViewState["ServiceList"];
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public decimal TotalAmount
        {
            set { ViewState["TotalAmount"] = value; }
            get
            {
                try
                {
                    return Convert.ToDecimal(Convert.ToString(ViewState["TotalAmount"]));
                }
                catch
                {
                    return 0;
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
                LoadService();


                if (Request.QueryString["Id"] != null)
                {
                    this.ModelId = Convert.ToInt32(QuaintSecurityManager.DecryptUrl(Convert.ToString(Request.QueryString["Id"])));
                    Edit(this.ModelId);
                    lblTitleStatus.Text = "Update";
                    btnSave.Text = "Update";
                    btnSaveAndContinue.Text = "Update & Continue";
                    btnSaveAndContinue.Visible = false;
                    LoadServiceTable(this.ModelId);
                }
                else
                {
                    GenerateCode();
                    LoadDefaultServiceTable();
                }
            }
        }

        private void LoadServiceTable(int programId)
        {
            ProgramWiseServiceBLL programWiseServiceBLL = new ProgramWiseServiceBLL();
            DataTable dt = programWiseServiceBLL.GetByProgramId(programId);
            gvList.DataSource = dt;
            gvList.DataBind();
        }

        private void LoadDefaultServiceTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Serial");
            dt.Columns.Add("TitleWithAmountAndCode");
            dt.Columns.Add("ServiceId");
            gvList.DataSource = dt;
            gvList.DataBind();
        }

        private void LoadService()
        {
            try
            {
                ServiceBLL serviceBLL = new ServiceBLL();
                DataTable dt = serviceBLL.GetAllActive();
                ddlService.DataSource = dt;
                ddlService.DataTextField = "TitleWithAmountAndCode";
                ddlService.DataValueField = "ServiceId";
                ddlService.DataBind();

                ddlService.Items.Insert(0, "--- Please Select ---");

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        List<ServicesModel> svcList = new List<ServicesModel>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ServicesModel service = new ServicesModel();
                            service.ServiceId = Convert.ToInt32(Convert.ToString(dt.Rows[i]["ServiceId"]));
                            service.ServiceCode = Convert.ToString(dt.Rows[i]["ServiceCode"]);
                            service.Title = Convert.ToString(dt.Rows[i]["Title"]);
                            service.Description = Convert.ToString(dt.Rows[i]["Description"]);
                            service.Amount = Convert.ToDecimal(Convert.ToString(dt.Rows[i]["Amount"]));
                            service.AmountStatus = Convert.ToString(dt.Rows[i]["AmountStatus"]);
                            service.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[i]["IsActive"]));
                            service.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[i]["CreatedDate"]));
                            service.CreatedBy = Convert.ToString(dt.Rows[i]["CreatedBy"]);
                            service.CreatedFrom = Convert.ToString(dt.Rows[i]["CreatedFrom"]);
                            service.UpdatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["UpdatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[i]["UpdatedDate"]));
                            service.UpdatedBy = Convert.ToString(dt.Rows[i]["UpdatedBy"]);
                            service.UpdatedFrom = Convert.ToString(dt.Rows[i]["UpdatedFrom"]);
                            svcList.Add(service);
                        }
                        this.ServiceList = svcList.ToList();
                    }
                }
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
                ProgramBLL programBLL = new ProgramBLL();
                DataTable dt = programBLL.GetById(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.ModelId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ProgramId"]));
                        this.ModelCode = Convert.ToString(dt.Rows[0]["ProgramCode"]);
                        txtTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                        txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                        txtAgeRange.Text = Convert.ToString(dt.Rows[0]["AgeRange"]);
                        txtPeriod.Text = Convert.ToString(dt.Rows[0]["Period"]);
                        this.TotalAmount = Convert.ToDecimal(Convert.ToString(dt.Rows[0]["TotalAmount"]));
                        txtTotalAmount.Text = Convert.ToString(dt.Rows[0]["TotalAmount"]);
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
                ModelCode = CodePrefix.Program + "-" + lib.GetSixDigitNumber(1);
                ProgramBLL programBLL = new ProgramBLL();
                DataTable dt = programBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string[] lastCode = dt.Rows[dt.Rows.Count - 1]["ProgramCode"].ToString().Split('-');
                        int lastCodeNumber = Convert.ToInt32(lastCode[1]);
                        ModelCode = CodePrefix.Program + "-" + lib.GetSixDigitNumber(lastCodeNumber + 1);
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
            txtAgeRange.Text = string.Empty;
            txtPeriod.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            LoadDefaultServiceTable();

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
                else if (string.IsNullOrEmpty(txtTotalAmount.Text))
                {
                    Alert(AlertType.Warning, "Enter total amount.");
                    txtTotalAmount.Focus();
                }
                else
                {
                    string title = Convert.ToString(txtTitle.Text);
                    string description = Convert.ToString(txtDescription.Text);
                    string ageRange = Convert.ToString(txtAgeRange.Text);
                    string period = Convert.ToString(txtPeriod.Text);
                    //decimal totalAmount = Convert.ToDecimal(Convert.ToString(txtTotalAmount.Text));
                    decimal totalAmount = this.TotalAmount;

                    ProgramBLL programBLL = new ProgramBLL();
                    if (this.ModelId > 0)
                    {
                        DataTable dt = programBLL.GetById(this.ModelId);
                        Programs program = new Programs();
                        program.ProgramId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ProgramId"]));
                        program.ProgramCode = Convert.ToString(dt.Rows[0]["ProgramCode"]);
                        program.Title = Convert.ToString(dt.Rows[0]["Title"]);
                        program.Description = Convert.ToString(dt.Rows[0]["Description"]);
                        program.AgeRange = Convert.ToString(dt.Rows[0]["AgeRange"]);
                        program.Period = Convert.ToString(dt.Rows[0]["Period"]);
                        program.TotalAmount = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TotalAmount"]))) ? ((decimal)0.00) : Convert.ToDecimal(Convert.ToString(dt.Rows[0]["TotalAmount"])));
                        program.AmountStatus = Convert.ToString(dt.Rows[0]["AmountStatus"]);
                        program.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                        program.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                        program.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                        program.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                        program.Title = title.Trim();
                        program.Description = description;
                        program.AgeRange = ageRange;
                        program.Period = period;
                        program.TotalAmount = totalAmount;

                        program.UpdatedDate = DateTime.Now;
                        program.UpdatedBy = this.UserInfo;
                        program.UpdatedFrom = this.StationInfo;

                        if (programBLL.Update(program))
                        {
                            int programId = programBLL.GetProgramId(program.ProgramCode);
                            if (SaveAndUpdateProgramWiseServices(programId))
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
                            Alert(AlertType.Error, "Failed to update.");
                        }
                    }
                    else
                    {
                        Programs program = new Programs();
                        program.ProgramCode = this.ModelCode;
                        program.Title = title.Trim();
                        program.Description = description;
                        program.AgeRange = ageRange;
                        program.Period = period;
                        program.TotalAmount = totalAmount;
                        program.IsActive = true;
                        program.CreatedDate = DateTime.Now;
                        program.CreatedBy = this.UserInfo;
                        program.CreatedFrom = this.StationInfo;

                        if (programBLL.Save(program))
                        {
                            int programId = programBLL.GetProgramId(program.ProgramCode);
                            if (SaveAndUpdateProgramWiseServices(programId))
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

        private bool SaveAndUpdateProgramWiseServices(int programId)
        {
            try
            {
                bool flag = false;

                List<ProgramWiseServices> programWiseServiceList = new List<ProgramWiseServices>();
                if (gvList.Rows.Count > 0)
                {
                    foreach (GridViewRow item in gvList.Rows)
                    {
                        ProgramWiseServices programWiseService = new ProgramWiseServices();
                        programWiseService.ProgramId = programId;
                        programWiseService.ServiceId = Convert.ToInt32(gvList.Rows[item.RowIndex].Cells[3].Text);
                        programWiseService.CreatedDate = DateTime.Now;
                        programWiseService.CreatedBy = this.UserInfo;
                        programWiseService.CreatedFrom = this.StationInfo;
                        programWiseService.UpdatedDate = DateTime.Now;
                        programWiseService.UpdatedBy = this.UserInfo;
                        programWiseService.UpdatedFrom = this.StationInfo;
                        programWiseServiceList.Add(programWiseService);
                    }
                }

                if (programWiseServiceList != null)
                {
                    if (programWiseServiceList.Count > 0)
                    {
                        ProgramWiseServiceBLL programWiseServiceBLL = new ProgramWiseServiceBLL();
                        programWiseServiceBLL.DeleteByProgramId(programId);
                        flag = programWiseServiceBLL.SaveAll(programWiseServiceList);
                    }
                }

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            this.MultiEntryDisallow = false;
            SaveAndUpdate();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Serial");
                dt.Columns.Add("TitleWithAmountAndCode");
                dt.Columns.Add("ServiceId");
                int serial = 1;

                if (gvList.Rows.Count > 0)
                {
                    foreach (GridViewRow item in gvList.Rows)
                    {
                        dt.Rows.Add(
                                serial
                                , gvList.Rows[item.RowIndex].Cells[1].Text
                                , gvList.Rows[item.RowIndex].Cells[3].Text
                                );
                        serial += 1;
                    }

                    bool isExist = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ddlService.SelectedValue) == Convert.ToInt32(Convert.ToString(dt.Rows[i]["ServiceId"])))
                        {
                            isExist = true;
                            Alert(AlertType.Warning, "Service already added.");
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        dt.Rows.Add(serial, ddlService.SelectedItem.Text, ddlService.SelectedValue);
                        CalculateTotalAmountToProgram(Convert.ToInt32(ddlService.SelectedValue), "sum");
                    }
                }
                else
                {
                    dt.Rows.Add(serial, ddlService.SelectedItem.Text, ddlService.SelectedValue);
                    CalculateTotalAmountToProgram(Convert.ToInt32(ddlService.SelectedValue), "sum");
                }

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        gvList.DataSource = dt;
                        gvList.DataBind();

                        ddlService.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to add");
            }
        }

        private void CalculateTotalAmountToProgram(int serviceId, string operation)
        {
            ServicesModel service = new ServicesModel();
            //ServicesModel service = ServiceList.SingleOrDefault(x => x.ServiceId == serviceId);
            foreach (ServicesModel svc in ServiceList)
            {
                if (svc.ServiceId == serviceId)
                {
                    service = svc;
                    break;
                }
            }

            if (service != null)
            {
                if (operation == "sum")
                {
                    this.TotalAmount += service.Amount;
                    txtTotalAmount.Text = Convert.ToString(this.TotalAmount);
                }
                else if (operation == "sub")
                {
                    this.TotalAmount -= service.Amount;
                    txtTotalAmount.Text = Convert.ToString(this.TotalAmount);
                }
            }
        }

        protected void btnRemove_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                int serialNo = Convert.ToInt32(commandArgs[0]);
                int serviceId = Convert.ToInt32(commandArgs[1]);
                DataTable dt = new DataTable();
                dt.Columns.Add("Serial");
                dt.Columns.Add("TitleWithAmountAndCode");
                dt.Columns.Add("ServiceId");
                int serial = 1;

                if (gvList.Rows.Count > 0)
                {
                    foreach (GridViewRow item in gvList.Rows)
                    {
                        if (Convert.ToInt32(gvList.Rows[item.RowIndex].Cells[0].Text) == serialNo
                            && Convert.ToInt32(gvList.Rows[item.RowIndex].Cells[3].Text) == serviceId)
                        {
                            int svcId = Convert.ToInt32(gvList.Rows[item.RowIndex].Cells[3].Text);
                            CalculateTotalAmountToProgram(svcId, "sub");
                        }
                        else
                        {
                            dt.Rows.Add(
                                serial
                                , gvList.Rows[item.RowIndex].Cells[1].Text
                                , gvList.Rows[item.RowIndex].Cells[3].Text
                                );
                            serial += 1;
                        }
                    }
                }

                gvList.DataSource = dt;
                gvList.DataBind();

                ddlService.SelectedIndex = 0;
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to remove");
            }
        }
    }
}