using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using System.Data;
using QuaintPark;

namespace QuaintDMS.Code.DAL
{
    public class OfficeExpenseDAL
    {
        public bool Save(OfficeExpenses officeExpense)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("OfficeExpenseCode", officeExpense.OfficeExpenseCode);
                db.AddParameters("Description", officeExpense.Description);
                db.AddParameters("Amount", officeExpense.Amount);
                db.AddParameters("AmountStatus", officeExpense.AmountStatus);
                db.AddParameters("Reference", officeExpense.Reference);
                db.AddParameters("CreatedDate", ((officeExpense.CreatedDate == null) ? officeExpense.CreatedDate : officeExpense.CreatedDate.Value));
                db.AddParameters("CreatedBy", officeExpense.CreatedBy);
                db.AddParameters("CreatedFrom", officeExpense.CreatedFrom);
                db.AddParameters("UpdatedDate", ((officeExpense.UpdatedDate == null) ? officeExpense.UpdatedDate : officeExpense.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", officeExpense.UpdatedBy);
                db.AddParameters("UpdatedFrom", officeExpense.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_OfficeExpense", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public DataTable GetAll()
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                DataTable dt = db.ExecuteDataTable("Get_All_OfficeExpense", false);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public DataTable GetById(int id)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                db.AddParameters("OfficeExpenseId", id);
                DataTable dt = db.ExecuteDataTable("Get_OfficeExpense_By_Id", true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public bool Update(OfficeExpenses officeExpense)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("OfficeExpenseId", officeExpense.OfficeExpenseId);
                db.AddParameters("OfficeExpenseCode", officeExpense.OfficeExpenseCode);
                db.AddParameters("Description", officeExpense.Description);
                db.AddParameters("Amount", officeExpense.Amount);
                db.AddParameters("AmountStatus", officeExpense.AmountStatus);
                db.AddParameters("Reference", officeExpense.Reference);
                db.AddParameters("CreatedDate", ((officeExpense.CreatedDate == null) ? officeExpense.CreatedDate : officeExpense.CreatedDate.Value));
                db.AddParameters("CreatedBy", officeExpense.CreatedBy);
                db.AddParameters("CreatedFrom", officeExpense.CreatedFrom);
                db.AddParameters("UpdatedDate", ((officeExpense.UpdatedDate == null) ? officeExpense.UpdatedDate : officeExpense.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", officeExpense.UpdatedBy);
                db.AddParameters("UpdatedFrom", officeExpense.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_OfficeExpense", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public bool Delete(OfficeExpenses  officeExpense)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("OfficeExpenseId", officeExpense.OfficeExpenseId);
                int affectedRows = db.ExecuteNonQuery("Delete_OfficeExpense", true);

                if (affectedRows > 0)
                    flag = true;

                return flag;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }
    }
}