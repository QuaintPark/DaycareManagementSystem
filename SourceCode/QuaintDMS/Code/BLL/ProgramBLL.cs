using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class ProgramBLL
    {

        public bool Save(Programs program)
        {
            try
            {
                ProgramDAL programDAL = new ProgramDAL();

                if (IsTitleExist(program))
                {
                    throw new Exception("Title already exist.");
                }
                else
                {
                    return programDAL.Save(program);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsTitleExist(Programs program)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Title"]).ToString() == program.Title);
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
                ProgramDAL programDAL = new ProgramDAL();
                return programDAL.GetAll();
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

        public int GetProgramId(string programCode)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["ProgramCode"]).ToString() == programCode);
                DataTable dt = rows.Any() ? rows.CopyToDataTable() : dtList.Clone();

                if (dt != null)
                    if (dt.Rows.Count > 0)
                        return Convert.ToInt32(Convert.ToString(dt.Rows[0]["ProgramId"]));
                    else
                        return 0;
                else
                    return 0;
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
                ProgramDAL programDAL = new ProgramDAL();
                return programDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Programs program)
        {
            try
            {
                ProgramDAL programDAL = new ProgramDAL();
                return programDAL.Update(program);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Programs program)
        {
            try
            {
                ProgramDAL programDAL = new ProgramDAL();
                return programDAL.Delete(program);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}