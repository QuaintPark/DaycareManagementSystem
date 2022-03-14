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
    public partial class StaffList : System.Web.UI.Page
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
                StaffBLL staffBLL = new StaffBLL();
                DataTable dt = staffBLL.GetAll();
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
                    StaffBLL staffBLL = new StaffBLL();
                    DataTable dt = staffBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
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

                            staff.UpdatedDate = DateTime.Now;
                            staff.UpdatedBy = UserInfo;
                            staff.UpdatedFrom = StationInfo;

                            if (staff.IsActive)
                            {
                                staff.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                staff.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (staffBLL.Update(staff))
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
                    StaffBLL staffBLL = new StaffBLL();
                    Staffs staff = new Staffs();
                    staff.StaffId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (staff.StaffId > 0)
                    {
                        if (staffBLL.Delete(staff))
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