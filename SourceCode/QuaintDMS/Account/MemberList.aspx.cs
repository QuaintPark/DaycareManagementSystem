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
    public partial class MemberList : System.Web.UI.Page
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
                MemberBLL memberBLL = new MemberBLL();
                DataTable dt = memberBLL.GetAll();
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
                    MemberBLL memberBLL = new MemberBLL();
                    DataTable dt = memberBLL.GetById(Convert.ToInt32(QuaintSecurityManager.Decrypt(id)));
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string actionStatus = "Updated";
                            Members member = new Members();
                            member.MemberId = Convert.ToInt32(Convert.ToString(dt.Rows[0]["MemberId"]));
                            member.MemberCode = Convert.ToString(dt.Rows[0]["MemberCode"]);
                            member.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                            member.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                            member.DateOfBirth = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["DateOfBirth"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["DateOfBirth"]));
                            member.Email = Convert.ToString(dt.Rows[0]["Email"]);
                            member.ContactNumber = Convert.ToString(dt.Rows[0]["ContactNumber"]);
                            member.AddressLine1 = Convert.ToString(dt.Rows[0]["AddressLine1"]);
                            member.AddressLine2 = Convert.ToString(dt.Rows[0]["AddressLine2"]);
                            member.City = Convert.ToString(dt.Rows[0]["City"]);
                            member.ZipCode = ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ZipCode"]))) ? (int?)null : Convert.ToInt32(Convert.ToString(dt.Rows[0]["ZipCode"])));
                            member.Country = Convert.ToString(dt.Rows[0]["Country"]);
                            member.NationalIdNumber = Convert.ToString(dt.Rows[0]["NationalIdNumber"]);
                            member.PassportNumber = Convert.ToString(dt.Rows[0]["PassportNumber"]);
                            member.DrivingLicenseNumber = Convert.ToString(dt.Rows[0]["DrivingLicenseNumber"]);
                            member.ProfilePhoto = Convert.ToString(dt.Rows[0]["ProfilePhoto"]);
                            member.CurrentStatus = Convert.ToString(dt.Rows[0]["CurrentStatus"]);
                            member.Password = QuaintSecurityManager.Encrypt(Convert.ToString(dt.Rows[0]["Password"]));
                            member.PasswordStamp = Convert.ToString(dt.Rows[0]["PasswordStamp"]);
                            member.SecurityQuestion = Convert.ToString(dt.Rows[0]["SecurityQuestion"]);
                            member.SecurityAnswer = Convert.ToString(dt.Rows[0]["SecurityAnswer"]);
                            member.IsVerified = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsVerified"]));
                            member.IsActive = Convert.ToBoolean(Convert.ToString(dt.Rows[0]["IsActive"]));
                            member.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[0]["CreatedDate"]));
                            member.CreatedBy = Convert.ToString(dt.Rows[0]["CreatedBy"]);
                            member.CreatedFrom = Convert.ToString(dt.Rows[0]["CreatedFrom"]);

                            member.UpdatedDate = DateTime.Now;
                            member.UpdatedBy = UserInfo;
                            member.UpdatedFrom = StationInfo;

                            if (member.IsActive)
                            {
                                member.IsActive = false;
                                actionStatus = "Deactivated";
                            }
                            else
                            {
                                member.IsActive = true;
                                actionStatus = "Activated";
                            }

                            if (memberBLL.Update(member))
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
                    MemberBLL memberBLL = new MemberBLL();
                    Members member = new Members();
                    member.MemberId = Convert.ToInt32(QuaintSecurityManager.Decrypt(id));
                    if (member.MemberId > 0)
                    {
                        if (memberBLL.Delete(member))
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