using QuaintDMS.Code.Global;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.BLL;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuaintDMS
{
    public partial class Login : System.Web.UI.Page
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
        private List<UsersModel> UserList
        {
            set { ViewState["UserList"] = value; }
            get
            {
                try
                {
                    if ((List<UsersModel>)ViewState["UserList"] == null)
                    {
                        return null;
                    }
                    else
                    {
                        return (List<UsersModel>)ViewState["UserList"];
                    }
                }
                catch
                {
                    return null;
                }
            }
        }



        // Action Method(s)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AccountLogout();
                LoadUser();

                if (Request.QueryString["Ref"] != null)
                {
                    if (Convert.ToString(Request.QueryString["Ref"]).ToLower() == "logout")
                    {
                        AccountLogout();
                    }
                }
            }
        }

        private void LoadUser()
        {
            try
            {
                UserBLL userBLL = new UserBLL();
                DataTable dt = userBLL.GetAll();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        List<UsersModel> usrList = new List<UsersModel>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            UsersModel usersModel = new UsersModel();
                            usersModel.UserId = Convert.ToInt32(Convert.ToString(dt.Rows[i]["UserId"]));
                            usersModel.UserCode = Convert.ToString(dt.Rows[i]["UserCode"]);
                            usersModel.FullName = Convert.ToString(dt.Rows[i]["FullName"]);
                            usersModel.Email = Convert.ToString(dt.Rows[i]["Email"]);
                            usersModel.UserName = Convert.ToString(dt.Rows[i]["UserName"]);
                            usersModel.Password = Convert.ToString(dt.Rows[i]["Password"]);
                            usersModel.PasswordStamp = Convert.ToString(dt.Rows[i]["PasswordStamp"]);
                            usersModel.CreatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["CreatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[i]["CreatedDate"]));
                            usersModel.CreatedBy = Convert.ToString(dt.Rows[i]["CreatedBy"]);
                            usersModel.CreatedFrom = Convert.ToString(dt.Rows[i]["CreatedFrom"]);
                            usersModel.UpdatedDate = (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["UpdatedDate"]))) ? (DateTime?)null : Convert.ToDateTime(Convert.ToString(dt.Rows[i]["UpdatedDate"]));
                            usersModel.UpdatedBy = Convert.ToString(dt.Rows[i]["UpdatedBy"]);
                            usersModel.UpdatedFrom = Convert.ToString(dt.Rows[i]["UpdatedFrom"]);
                            usersModel.UserType = Convert.ToString(dt.Rows[i]["UserType"]);
                            usrList.Add(usersModel);
                        }
                        this.UserList = usrList.ToList();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void AccountLogout()
        {
            QuaintSessionManager session = new QuaintSessionManager();
            session.RemoveAll();
            session.ClearAll();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            Session.Abandon();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    Alert(AlertType.Warning, "Enter username.");
                    txtUsername.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    Alert(AlertType.Warning, "Enter password.");
                    txtPassword.Focus();
                }
                else
                {
                    Users user = new Users();
                    user.UserName = Convert.ToString(txtUsername.Text);
                    user.Password = Convert.ToString(txtPassword.Text);

                    if (IsUsernameExist(user))
                    {
                        if (IsPasswordExist(user))
                        {
                            UsersModel usrModel = AccountLogin(user);
                            QuaintSessionManager session = new QuaintSessionManager();
                            session.ActiveUserName = usrModel.UserName;
                            Response.Redirect("~/Account/Dashboard.aspx");
                        }
                        else
                        {
                            Alert(AlertType.Error, "Username and password does not match.");
                        }
                    }
                    else
                    {
                        Alert(AlertType.Error, "User is not exist.");
                    }
                }
            }
            catch (Exception)
            {
                Alert(AlertType.Error, "Failed to login.");
            }
        }

        private bool IsUsernameExist(Users user)
        {
            try
            {
                bool flag = false;
                UsersModel usrModel = new UsersModel();

                foreach (UsersModel usr in this.UserList)
                {
                    if (usr.UserName == user.UserName)
                    {
                        usrModel = usr;
                        flag = true;
                        break;
                    }
                }
                
                return flag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsPasswordExist(Users user)
        {
            try
            {
                bool flag = false;
                UsersModel usrModel = new UsersModel();

                foreach (UsersModel usr in this.UserList)
                {
                    if (usr.UserName == user.UserName && usr.Password == user.Password)
                    {
                        usrModel = usr;
                        flag = true;
                        break;
                    }
                }
                
                return flag;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private UsersModel AccountLogin(Users user)
        {
            try
            {
                UsersModel usrModel = new UsersModel();

                foreach (UsersModel usr in this.UserList)
                {
                    if (usr.UserName == user.UserName && usr.Password == user.Password)
                    {
                        usrModel = usr;
                        break;
                    }
                }

                if (usrModel != null)
                    return usrModel;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}