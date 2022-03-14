using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class StaffSalaryRecordDAL
    {
        public bool Save(StaffSalaryRecords staffSalaryRecord)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("StaffSalaryRecordCode", staffSalaryRecord.StaffSalaryRecordCode);
                db.AddParameters("Salary", staffSalaryRecord.Salary);
                db.AddParameters("PreviousDue", staffSalaryRecord.PreviousDue);
                db.AddParameters("Total", staffSalaryRecord.Total);
                db.AddParameters("PaidAmount", staffSalaryRecord.PaidAmount);
                db.AddParameters("Due", staffSalaryRecord.Due);
                db.AddParameters("Status", staffSalaryRecord.Status);
                db.AddParameters("CreatedDate", staffSalaryRecord.CreatedDate);
                db.AddParameters("CreatedBy", staffSalaryRecord.CreatedBy);
                db.AddParameters("CreatedFrom", staffSalaryRecord.CreatedFrom);
                db.AddParameters("UpdatedDate", staffSalaryRecord.UpdatedDate);
                db.AddParameters("UpdatedBy", staffSalaryRecord.UpdatedBy);
                db.AddParameters("UpdatedFrom", staffSalaryRecord.UpdatedFrom);
                db.AddParameters("StaffId", staffSalaryRecord.StaffId);
                int affectedRows = db.ExecuteNonQuery("Insert_StaffSalaryRecords", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_StaffSalaryRecords", false);
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
                db.AddParameters("StaffSalaryRecordId", id);
                DataTable dt = db.ExecuteDataTable("Get_StaffSalaryRecords_By_Id", true);
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

        public bool Update(StaffSalaryRecords staffSalaryRecord)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("StaffSalaryRecordId", staffSalaryRecord.StaffSalaryRecordId);
                db.AddParameters("StaffSalaryRecordCode", staffSalaryRecord.StaffSalaryRecordCode);
                db.AddParameters("Salary", staffSalaryRecord.Salary);
                db.AddParameters("PreviousDue", staffSalaryRecord.PreviousDue);
                db.AddParameters("Total", staffSalaryRecord.Total);
                db.AddParameters("PaidAmount", staffSalaryRecord.PaidAmount);
                db.AddParameters("Due", staffSalaryRecord.Due);
                db.AddParameters("Status", staffSalaryRecord.Status);
                db.AddParameters("CreatedDate", staffSalaryRecord.CreatedDate);
                db.AddParameters("CreatedBy", staffSalaryRecord.CreatedBy);
                db.AddParameters("CreatedFrom", staffSalaryRecord.CreatedFrom);
                db.AddParameters("UpdatedDate", staffSalaryRecord.UpdatedDate);
                db.AddParameters("UpdatedBy", staffSalaryRecord.UpdatedBy);
                db.AddParameters("UpdatedFrom", staffSalaryRecord.UpdatedFrom);
                db.AddParameters("StaffId", staffSalaryRecord.StaffId);
                int affectedRows = db.ExecuteNonQuery("Update_Programs", true);

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

        public bool Delete(StaffSalaryRecords staffSalaryRecord)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("StaffSalaryRecordId", staffSalaryRecord.StaffSalaryRecordId);
                int affectedRows = db.ExecuteNonQuery("Delete_StaffSalaryRecords", true);

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