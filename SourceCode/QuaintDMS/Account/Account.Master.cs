using QuaintPark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintDMS.Account
{
    public partial class Account : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QuaintSessionManager session = new QuaintSessionManager();
            if (!session.HasSession)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                SetUserInfoAndStationInfoInSession();
            }
        }

        private void SetUserInfoAndStationInfoInSession()
        {
            QuaintSessionManager session = new QuaintSessionManager();
            QuaintLibraryManager lib = new QuaintLibraryManager();
            session.ActiveStationInformation = lib.IpAddress
                + ", " + lib.MacAddress
                + ", " + lib.MachineName
                + ", " + lib.ProcessorId
                + ", " + lib.OsInfo
                + ", " + lib.BrowserInfo
                + ", " + lib.CountryCodeAlpha2
                + ", " + lib.CountryName
                + ", " + lib.Latitude
                + ", " + lib.Longitude;

            //Dictionary<string, string> terminal = lib.GetTerminal();
            //session.ActiveStationInformation = terminal["IpAddress"]
            //    + ", " + terminal["MacAddress"]
            //    + ", " + terminal["MachineName"]
            //    + ", " + terminal["ProcessorId"]
            //    + ", " + terminal["OsInfo"]
            //    + ", " + terminal["BrowserInfo"]
            //    + ", " + terminal["CountryCodeAlpha2"]
            //    + ", " + terminal["CountryName"]
            //    + ", " + terminal["Latitude"]
            //    + ", " + terminal["Longitude"];

            session.ActiveUserInformation = session.ActiveUserRoleId
                + ", " + session.ActiveUserRoleName
                + ", " + session.ActiveUserId
                + ", " + session.ActiveUserName;
        }

        private void GetTitle()
        {
            if (Request.Url.AbsolutePath.ToString().ToLower() != "/account/dashboard.aspx")
            {
                defaultTitle.Text = defaultTitle.Text.ToString() + " | ";
            }
        }
    }
}