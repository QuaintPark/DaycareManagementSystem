using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class MemberBLL
    {
        public bool Save(Members member)
        {
            try
            {
                MemberDAL memberDAL = new MemberDAL();

                if (IsEmailExist(member))
                {
                    throw new Exception("Email already exist.");
                }
                else
                {
                    return memberDAL.Save(member);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsEmailExist(Members member)
        {
            try
            {
                DataTable dtList = GetAll();
                var rows = dtList.AsEnumerable().Where(x => ((string)x["Email"]).ToString() == member.Email);
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
                MemberDAL memberDAL = new MemberDAL();
                return memberDAL.GetAll();
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
                MemberDAL memberDAL = new MemberDAL();
                return memberDAL.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Members member)
        {
            try
            {
                MemberDAL memberDAL = new MemberDAL();
                return memberDAL.Update(member);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Members member)
        {
            try
            {
                MemberDAL memberDAL = new MemberDAL();
                return memberDAL.Delete(member);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}