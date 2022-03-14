using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class UserBLL
    {
        public bool Save(Users user)
        {
            try
            {
                UserDAL userDAL = new UserDAL();

                if (IsUserNameExist(user))
                {
                    throw new Exception("Username already exist.");
                }
                else
                {
                    return userDAL.Save(user);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsUserNameExist(Users user)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["UserName"]).ToString() == user.UserName);
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
                UserDAL userDAL = new UserDAL();
                return userDAL.GetAll();
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
                UserDAL userDAL = new UserDAL();
                return userDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Users user)
        {
            try
            {
                UserDAL userDAL = new UserDAL();
                return userDAL.Update(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Users user)
        {
            try
            {
                UserDAL userDAL = new UserDAL();
                return userDAL.Delete(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}