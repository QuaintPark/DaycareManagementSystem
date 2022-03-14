using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class ServiceDAL
    {
        public bool Save(Services service)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("serviceCode", service.ServiceCode);
                db.AddParameters("Title", service.Title);
                db.AddParameters("Description", service.Description);
                db.AddParameters("Amount", service.Amount);
                db.AddParameters("AmountStatus", service.AmountStatus);
                db.AddParameters("IsActive", service.IsActive);
                db.AddParameters("CreatedDate", ((service.CreatedDate == null) ? service.CreatedDate : service.CreatedDate.Value));
                db.AddParameters("CreatedBy", service.CreatedBy);
                db.AddParameters("CreatedFrom", service.CreatedFrom);
                db.AddParameters("UpdatedDate", ((service.UpdatedDate == null) ? service.UpdatedDate : service.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", service.UpdatedBy);
                db.AddParameters("UpdatedFrom", service.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_Service", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Service", false);
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
                db.AddParameters("ServiceId", id);
                DataTable dt = db.ExecuteDataTable("Get_Service_By_Id", true);
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

        public bool Update(Services service)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ServiceId", service.ServiceId);
                db.AddParameters("serviceCode", service.ServiceCode);
                db.AddParameters("Title", service.Title);
                db.AddParameters("Description", service.Description);
                db.AddParameters("Amount", service.Amount);
                db.AddParameters("AmountStatus", service.AmountStatus);
                db.AddParameters("IsActive", service.IsActive);
                db.AddParameters("CreatedDate", ((service.CreatedDate == null) ? service.CreatedDate : service.CreatedDate.Value));
                db.AddParameters("CreatedBy", service.CreatedBy);
                db.AddParameters("CreatedFrom", service.CreatedFrom);
                db.AddParameters("UpdatedDate", ((service.UpdatedDate == null) ? service.UpdatedDate : service.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", service.UpdatedBy);
                db.AddParameters("UpdatedFrom", service.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_Service", true);

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

        public bool Delete(Services service)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ServiceId", service.ServiceId);
                int affectedRows = db.ExecuteNonQuery("Delete_Service", true);

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