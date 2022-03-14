using QuaintDMS.Code.BLL;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintDMS.Pages
{
    public partial class Programs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProgram();
            }
        }

        private void LoadProgram()
        {
            try
            {
                ProgramBLL programBLL = new ProgramBLL();
                DataTable dt = programBLL.GetAllActive();
                
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        rptrProgram.DataSource = dt;
                        rptrProgram.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        protected void rptrProgram_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    int programId = Convert.ToInt32(QuaintSecurityManager.Decrypt(Convert.ToString((e.Item.FindControl("hfProgramId") as HiddenField).Value)));
                    Repeater rptrService = e.Item.FindControl("rptrService") as Repeater;
                    ProgramWiseServiceBLL programWiseServiceBLL = new ProgramWiseServiceBLL();
                    DataTable dt = programWiseServiceBLL.GetByProgramId(programId);

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            rptrService.DataSource = dt;
                            rptrService.DataBind();
                        }
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