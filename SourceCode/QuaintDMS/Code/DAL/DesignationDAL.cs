using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class DesignationDAL
    {
        public bool Save(Designations designation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DesignationCode", designation.DesignationCode);
                db.AddParameters("Name", designation.Name);
                db.AddParameters("Description", designation.Description);
                db.AddParameters("IsActive", designation.IsActive);
                db.AddParameters("CreatedDate", ((designation.CreatedDate == null) ? designation.CreatedDate : designation.CreatedDate.Value));
                db.AddParameters("CreatedBy", designation.CreatedBy);
                db.AddParameters("CreatedFrom", designation.CreatedFrom);
                db.AddParameters("UpdatedDate", ((designation.UpdatedDate == null) ? designation.UpdatedDate : designation.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", designation.UpdatedBy);
                db.AddParameters("UpdatedFrom", designation.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_Designation", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Designation", false);
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
                db.AddParameters("DesignationId", id);
                DataTable dt = db.ExecuteDataTable("Get_Designation_By_Id", true);
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

        public bool Update(Designations designation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DesignationId", designation.DesignationId);
                db.AddParameters("DesignationCode", designation.DesignationCode);
                db.AddParameters("Name", designation.Name);
                db.AddParameters("Description", designation.Description);
                db.AddParameters("IsActive", designation.IsActive);
                db.AddParameters("CreatedDate", ((designation.CreatedDate == null) ? designation.CreatedDate : designation.CreatedDate.Value));
                db.AddParameters("CreatedBy", designation.CreatedBy);
                db.AddParameters("CreatedFrom", designation.CreatedFrom);
                db.AddParameters("UpdatedDate", ((designation.UpdatedDate == null) ? designation.UpdatedDate : designation.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", designation.UpdatedBy);
                db.AddParameters("UpdatedFrom", designation.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_Designation", true);

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

        public bool Delete(Designations designation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DesignationId", designation.DesignationId);
                int affectedRows = db.ExecuteNonQuery("Delete_Designation", true);

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