using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class OfficeExpensesBLL
    {
        public bool Save(OfficeExpenses officeExpense)
        {
            try
            {
                OfficeExpenseDAL officeExpenseDAL = new OfficeExpenseDAL();
                return officeExpenseDAL.Save(officeExpense);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                OfficeExpenseDAL officeExpenseDAL = new OfficeExpenseDAL();
                return officeExpenseDAL.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetById(int id)
        {
            try
            {
                OfficeExpenseDAL officeExpenseDAL = new OfficeExpenseDAL();
                return officeExpenseDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(OfficeExpenses officeExpense)
        {
            try
            {
                OfficeExpenseDAL officeExpenseDAL = new OfficeExpenseDAL();
                return officeExpenseDAL.Update(officeExpense);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(OfficeExpenses officeExpense)
        {
            try
            {
                OfficeExpenseDAL officeExpenseDAL = new OfficeExpenseDAL();
                return officeExpenseDAL.Delete(officeExpense);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}