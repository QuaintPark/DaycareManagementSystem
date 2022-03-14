using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class ChildBLL
    {
        public bool Save(Childs child)
        {
            try
            {
                ChildDAL childDAL = new ChildDAL();

                if (IsChildExist(child))
                {
                    throw new Exception("Child already exist.");
                }
                else
                {
                    return childDAL.Save(child);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsChildExist(Childs child)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["FirstName"]).ToString() == child.FirstName
                    && ((string)x["LastName"]).ToString() == child.LastName
                    && (Convert.ToInt32(x["MemberId"])) == child.MemberId);
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
                ChildDAL childDAL = new ChildDAL();
                return childDAL.GetAll();
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
                ChildDAL childDAL = new ChildDAL();
                return childDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Childs child)
        {
            try
            {
                ChildDAL childDAL = new ChildDAL();
                return childDAL.Update(child);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Childs child)
        {
            try
            {
                ChildDAL childDAL = new ChildDAL();
                return childDAL.Delete(child);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}