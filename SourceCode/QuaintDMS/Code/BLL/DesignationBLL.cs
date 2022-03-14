using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class DesignationBLL
    {
        public bool Save(Designations designation)
        {
            try
            {
                DesignationDAL designationDAL = new DesignationDAL();

                if (IsNameExist(designation))
                {
                    throw new Exception("Name already exist.");
                }
                else
                {
                    return designationDAL.Save(designation);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private bool IsNameExist(Designations designation)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Name"]).ToString() == designation.Name);
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
                DesignationDAL designationDAL = new DesignationDAL();
                return designationDAL.GetAll();
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
                DesignationDAL designationDAL = new DesignationDAL();
                return designationDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Designations designation)
        {
            try
            {
                DesignationDAL designationDAL = new DesignationDAL();
                return designationDAL.Update(designation);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Designations designation)
        {
            try
            {
                DesignationDAL designationDAL = new DesignationDAL();
                return designationDAL.Delete(designation);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}