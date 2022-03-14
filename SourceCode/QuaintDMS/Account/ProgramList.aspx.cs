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
    public partial class ProgramList : System.Web.UI.Page
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



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuaintSessionManager session = new QuaintSessionManager();
                UserInfo = Convert.ToString(session.ActiveUserInformation);
                StationInfo = Convert.ToString(session.ActiveStationInformation);

                LoadList();
            }
        }

        private void LoadList()
        {
            try
            {
                ProgramBLL programBLL = new ProgramBLL();
                DataTable dt = programBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrList.DataSource = dt;
                        rptrList.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void btnActiveOrDeactive_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id = Convert.ToString(e.CommandArgument);
                if (!string.IsNullOrEmpty(id))
                {
                    ProgramBLL programBLL = new ProgramBLL();
                    DataTable dt = programBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            Programs program = new Programs();
                            program.ProgramId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ProgramId"]));
                            program.ProgramCode = Convert.ToString(dt.Rows[0]["ProgramCode"]);
                            program.Title = Convert.ToString(dt.Rows[0]["Title"]);
                            program.Description = Convert.ToString(dt.Rows[0]["Description"]);
                            program.AgeRange = Convert.ToString(dt.Rows[0]["AgeRange"]);
                            program.Period = Convert.ToString(dt.Rows[0]["Period"]);
                            program.TotalAmount = Convert.ToDecimal(Convert.ToString(dt.Rows[0]["TotalAmount"]));
                            program.AmountStatus = Convert.ToString(dt.Rows[0]["AmountStatus"]);
                            program.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            program.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            program.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            program.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                            program.UpdatedDate = DateTime.Now;
                            program.UpdatedBy = UserInfo;
                            program.UpdatedFrom = StationInfo;

                            if (program.IsActive)
                            {
                                program.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                program.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (programBLL.Update(program))
                            {
                                Alert(AlertType.Success, actionStatus + " successfully.");
                                LoadList();
                            }
                            else
                            {
                                Alert(AlertType.Error, "Failed to update.");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to process.");
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id = Convert.ToString(e.CommandArgument);
                if (!string.IsNullOrEmpty(id))
                {
                    ProgramBLL programBLL = new ProgramBLL();
                    Programs program = new Programs();
                    program.ProgramId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (program.ProgramId > 0)
                    {
                        if (programBLL.Delete(program))
                        {
                            Alert(AlertType.Success, "Deleted successfully.");
                            LoadList();
                        }
                        else
                        {
                            Alert(AlertType.Error, "Failed to delete.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to delete.");
            }
        }
    }
}