using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class ProgramDAL
    {
        public bool Save(Programs program)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ProgramCode", program.ProgramCode);
                db.AddParameters("Title", program.Title);
                db.AddParameters("Description", program.Description);
                db.AddParameters("AgeRange", program.AgeRange);
                db.AddParameters("Period", program.Period);
                db.AddParameters("TotalAmount", program.TotalAmount);
                db.AddParameters("AmountStatus", program.AmountStatus);
                db.AddParameters("IsActive", program.IsActive);
                db.AddParameters("CreatedDate", ((program.CreatedDate == null) ? program.CreatedDate : program.CreatedDate.Value));
                db.AddParameters("CreatedBy", program.CreatedBy);
                db.AddParameters("CreatedFrom", program.CreatedFrom);
                db.AddParameters("UpdatedDate", ((program.UpdatedDate == null) ? program.UpdatedDate : program.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", program.UpdatedBy);
                db.AddParameters("UpdatedFrom", program.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_Program", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Program", false);
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
                db.AddParameters("ProgramId", id);
                DataTable dt = db.ExecuteDataTable("Get_Program_By_Id", true);
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

        public bool Update(Programs program)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ProgramId", program.ProgramId);
                db.AddParameters("ProgramCode", program.ProgramCode);
                db.AddParameters("Title", program.Title);
                db.AddParameters("Description", program.Description);
                db.AddParameters("AgeRange", program.AgeRange);
                db.AddParameters("Period", program.Period);
                db.AddParameters("TotalAmount", program.TotalAmount);
                db.AddParameters("AmountStatus", program.AmountStatus);
                db.AddParameters("IsActive", program.IsActive);
                db.AddParameters("CreatedDate", ((program.CreatedDate == null) ? program.CreatedDate : program.CreatedDate.Value));
                db.AddParameters("CreatedBy", program.CreatedBy);
                db.AddParameters("CreatedFrom", program.CreatedFrom);
                db.AddParameters("UpdatedDate", ((program.UpdatedDate == null) ? program.UpdatedDate : program.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", program.UpdatedBy);
                db.AddParameters("UpdatedFrom", program.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_Program", true);

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

        public bool Delete(Programs program)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ProgramId", program.ProgramId);
                int affectedRows = db.ExecuteNonQuery("Delete_Program", true);

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