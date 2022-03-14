using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class StaffBLL
    {
        public bool Save(Staffs staff)
        {
            try
            {
                StaffDAL staffDAL = new StaffDAL();

                if (IsEmailExist(staff))
                {
                    throw new Exception("Email already exist.");
                }
                else
                {
                    return staffDAL.Save(staff);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsEmailExist(Staffs staff)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Email"]).ToString() == staff.Email);
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
                StaffDAL staffDAL = new StaffDAL();
                return staffDAL.GetAll();
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
                StaffDAL staffDAL = new StaffDAL();
                return staffDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Staffs staff)
        {
            try
            {
                StaffDAL staffDAL = new StaffDAL();
                return staffDAL.Update(staff);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Staffs staff)
        {
            try
            {
                StaffDAL staffDAL = new StaffDAL();
                return staffDAL.Delete(staff);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}