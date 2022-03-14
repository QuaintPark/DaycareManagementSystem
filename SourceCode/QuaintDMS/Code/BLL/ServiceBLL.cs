using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class ServiceBLL
    {
        public bool Save(Services service)
        {
            try
            {
                ServiceDAL serviceDAL = new ServiceDAL();

                if (IsTitleExist(service))
                {
                    throw new Exception("Title already exist.");
                }
                else
                {
                    return serviceDAL.Save(service);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsTitleExist(Services service)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Title"]).ToString() == service.Title);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return true;
                    else
                        return false;
                else
                    return false;
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
                ServiceDAL serviceDAL = new ServiceDAL();
                return serviceDAL.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAllActive()
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((bool)x["IsActive"]) == true);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return dt;
                    else
                        return null;
                else
                    return null;
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
                ServiceDAL serviceDAL = new ServiceDAL();
                return serviceDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Services service)
        {
            try
            {
                ServiceDAL serviceDAL = new ServiceDAL();
                return serviceDAL.Update(service);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Services service)
        {
            try
            {
                ServiceDAL serviceDAL = new ServiceDAL();
                return serviceDAL.Delete(service);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}