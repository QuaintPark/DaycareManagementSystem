using QuaintDMS.Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintDMS.Pages
{
    public partial class Staffs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDesignation();
                LoadStaff();
            }
        }

        private void LoadDesignation()
        {
            try
            {
                DesignationBLL designationBLL = new DesignationBLL();
                DataTable dt = designationBLL.GetAll();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrDesignation.DataSource = dt;
                        rptrDesignation.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void LoadStaff()
        {
            try
            {
                StaffBLL staffBLL = new StaffBLL();
                DataTable dt = staffBLL.GetAllActive();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrStaff.DataSource = dt;
                        rptrStaff.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}