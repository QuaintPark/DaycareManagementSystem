using QuaintDMS.Code.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuaintDMS.Account
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardInfo();
            }
        }

        private void LoadDashboardInfo()
        {
            try
            {
                //Total Staff
                StaffBLL staffBLL = new StaffBLL();
                DataTable dtStaff = staffBLL.GetAll();
                lblTotalStaff.Text = Convert.ToString(Convert.ToInt32(dtStaff.Rows.Count));

                //Total Child
                ChildBLL childBLL = new ChildBLL();
                DataTable dtChild = childBLL.GetAll();
                lblTotalChild.Text = Convert.ToString(Convert.ToInt32(dtChild.Rows.Count));

                //Total Member
                MemberBLL memberBLL = new MemberBLL();
                DataTable dtMember = memberBLL.GetAll();
                lblTotalMember.Text = Convert.ToString(Convert.ToInt32(dtMember.Rows.Count));

                //Total Program
                ProgramBLL programBLL = new ProgramBLL();
                DataTable dtProgram = programBLL.GetAll();
                lblTotalProgram.Text = Convert.ToString(Convert.ToInt32(dtProgram.Rows.Count));

                //Total Income
                //ChildBLL childBLL = new ChildBLL();
                //DataTable dtChild = childBLL.GetAll();
                //lblTotalIncome.Text = Convert.ToString(Convert.ToInt32(dtChild.Rows.Count));

                //Total Expense
                decimal officeExpense = 0;
                OfficeExpensesBLL officeExpensesBLL = new OfficeExpensesBLL();
                DataTable dtOfficeExpense = officeExpensesBLL.GetAll();
                if (dtOfficeExpense != null)
                {
                    if (dtOfficeExpense.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtOfficeExpense.Rows.Count; i++)
                        {
                            officeExpense += Convert.ToDecimal(Convert.ToString(dtOfficeExpense.Rows[i]["Amount"]));
                        }
                    }
                }
                lblTotalExpense.Text = Convert.ToString(officeExpense);
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}