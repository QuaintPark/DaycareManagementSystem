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
    public partial class ChildList : System.Web.UI.Page
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
                ChildBLL childBLL = new ChildBLL();
                DataTable dt = childBLL.GetAll();
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
                    ChildBLL childBLL = new ChildBLL();
                    DataTable dt = childBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            Childs child = new Childs();
                            child.ChildId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ChildId"]));
                            child.ChildCode = Convert.ToString(dt.Rows[0]["ChildCode"]);
                            child.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                            child.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                            child.DateOfBirth = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfBirth"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["DateOfBirth"]));
                            child.AddressLine1 = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                            child.AddressLine2 = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                            child.City = Convert.ToString(dt.Rows[0]["City"]);
                            child.ZipCode = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ZipCode"]))) ? (int?)null : Convert.ToInt32(Convert.ToString(dt.Rows[0]["ZipCode"])));
                            child.Country = Convert.ToString(dt.Rows[0]["Country"]);
                            child.ProfilePhoto = Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                            child.FatherName = Convert.ToString(dt.Rows[0]["FatherName"]);
                            child.FatherProfession = Convert.ToString(dt.Rows[0]["FatherProfession"]);
                            child.FatherContactNumber = Convert.ToString(dt.Rows[0]["FatherContactNumber"]);
                            child.MotherName = Convert.ToString(dt.Rows[0]["MotherName"]);
                            child.MotherProfession = Convert.ToString(dt.Rows[0]["MotherProfession"]);
                            child.MotherContactNumber = Convert.ToString(dt.Rows[0]["MotherContactNumber"]);
                            child.LocalGuardianName = Convert.ToString(dt.Rows[0]["LocalGuardianName"]);
                            child.LocalGuardianProfession = Convert.ToString(dt.Rows[0]["LocalGuardianProfession"]);
                            child.LocalGuardianContactNumber = Convert.ToString(dt.Rows[0]["LocalGuardianContactNumber"]);
                            child.LocalGuardianAddressLine1 = Convert.ToString(dt.Rows[0]["LocalGuardianAddressLine1"]);
                            child.LocalGuardianAddressLine2 = Convert.ToString(dt.Rows[0]["LocalGuardianAddressLine2"]);
                            child.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            child.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            child.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            child.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);
                            child.MemberId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["MemberId"]));
                            child.ProgramId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["ProgramId"]));

                            child.UpdatedDate = DateTime.Now;
                            child.UpdatedBy = UserInfo;
                            child.UpdatedFrom = StationInfo;

                            if (child.IsActive)
                            {
                                child.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                child.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (childBLL.Update(child))
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
                    ChildBLL childBLL = new ChildBLL();
                    Childs child = new Childs();
                    child.ChildId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (child.ChildId > 0)
                    {
                        if (childBLL.Delete(child))
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