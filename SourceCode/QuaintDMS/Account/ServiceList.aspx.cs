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
    public partial class ServiceList : System.Web.UI.Page
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
                ServiceBLL serviceBLL = new ServiceBLL();
                DataTable dt = serviceBLL.GetAll();
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
                    ServiceBLL serviceBLL = new ServiceBLL();
                    DataTable dt = serviceBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            Services service = new Services();
                            service.ServiceId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ServiceId"]));
                            service.ServiceCode = Convert.ToString(dt.Rows[0]["ServiceCode"]);
                            service.Title = Convert.ToString(dt.Rows[0]["Title"]);
                            service.Description = Convert.ToString(dt.Rows[0]["Description"]);
                            service.Amount = Convert.ToDecimal(Convert.ToString(dt.Rows[0]["Amount"]));
                            service.AmountStatus = Convert.ToString(dt.Rows[0]["AmountStatus"]);
                            service.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            service.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            service.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            service.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                            service.UpdatedDate = DateTime.Now;
                            service.UpdatedBy = UserInfo;
                            service.UpdatedFrom = StationInfo;

                            if (service.IsActive)
                            {
                                service.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                service.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (serviceBLL.Update(service))
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
                    ServiceBLL serviceBLL = new ServiceBLL();
                    Services service = new Services();
                    service.ServiceId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (service.ServiceId > 0)
                    {
                        if (serviceBLL.Delete(service))
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