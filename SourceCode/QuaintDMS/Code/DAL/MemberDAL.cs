using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using System.Data;
using QuaintPark;

namespace QuaintDMS.Code.DAL
{
    public class MemberDAL
    {
        public bool Save(Members member)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("MemberCode", member.MemberCode);
                db.AddParameters("FirstName", member.FirstName);
                db.AddParameters("LastName", member.LastName);
                db.AddParameters("DateOfBirth", ((member.DateOfBirth == null) ? member.DateOfBirth : member.DateOfBirth.Value));
                db.AddParameters("Email", member.Email);
                db.AddParameters("ContactNumber", member.ContactNumber);
                db.AddParameters("AddressLine1", member.AddressLine1);
                db.AddParameters("AddressLine2", member.AddressLine2);
                db.AddParameters("City", member.City);
                db.AddParameters("ZipCode", ((member.ZipCode == null) ? (int?)null : member.ZipCode));
                db.AddParameters("Country", member.Country);
                db.AddParameters("NationalIdNumber", member.NationalIdNumber);
                db.AddParameters("PassportNumber", member.PassportNumber);
                db.AddParameters("DrivingLicenseNumber", member.DrivingLicenseNumber);
                db.AddParameters("ProfilePhoto", member.ProfilePhoto);
                db.AddParameters("CurrentStatus", member.CurrentStatus);
                db.AddParameters("Password", member.Password);
                db.AddParameters("PasswordStamp", member.PasswordStamp);
                db.AddParameters("SecurityQuestion", member.SecurityQuestion);
                db.AddParameters("SecurityAnswer", member.SecurityAnswer);
                db.AddParameters("IsVerified", member.IsVerified);
                db.AddParameters("IsActive", member.IsActive);
                db.AddParameters("CreatedDate", ((member.CreatedDate == null) ? member.CreatedDate : member.CreatedDate.Value));
                db.AddParameters("CreatedBy", member.CreatedBy);
                db.AddParameters("CreatedFrom", member.CreatedFrom);
                db.AddParameters("UpdatedDate", ((member.UpdatedDate == null) ? member.UpdatedDate : member.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", member.UpdatedBy);
                db.AddParameters("UpdatedFrom", member.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_Member", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Member", false);
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
                db.AddParameters("MemberId", id);
                DataTable dt = db.ExecuteDataTable("Get_Member_By_Id", true);
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

        public bool Update(Members member)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("MemberId", member.MemberId);
                db.AddParameters("MemberCode", member.MemberCode);
                db.AddParameters("FirstName", member.FirstName);
                db.AddParameters("LastName", member.LastName);
                db.AddParameters("DateOfBirth", ((member.DateOfBirth == null) ? member.DateOfBirth : member.DateOfBirth.Value));
                db.AddParameters("Email", member.Email);
                db.AddParameters("ContactNumber", member.ContactNumber);
                db.AddParameters("AddressLine1", member.AddressLine1);
                db.AddParameters("AddressLine2", member.AddressLine2);
                db.AddParameters("City", member.City);
                db.AddParameters("ZipCode", ((member.ZipCode == null) ? (int?)null : member.ZipCode));
                db.AddParameters("Country", member.Country);
                db.AddParameters("NationalIdNumber", member.NationalIdNumber);
                db.AddParameters("PassportNumber", member.PassportNumber);
                db.AddParameters("DrivingLicenseNumber", member.DrivingLicenseNumber);
                db.AddParameters("ProfilePhoto", member.ProfilePhoto);
                db.AddParameters("CurrentStatus", member.CurrentStatus);
                db.AddParameters("Password", member.Password);
                db.AddParameters("PasswordStamp", member.PasswordStamp);
                db.AddParameters("SecurityQuestion", member.SecurityQuestion);
                db.AddParameters("SecurityAnswer", member.SecurityAnswer);
                db.AddParameters("IsVerified", member.IsVerified);
                db.AddParameters("IsActive", member.IsActive);
                db.AddParameters("CreatedDate", ((member.CreatedDate == null) ? member.CreatedDate : member.CreatedDate.Value));
                db.AddParameters("CreatedBy", member.CreatedBy);
                db.AddParameters("CreatedFrom", member.CreatedFrom);
                db.AddParameters("UpdatedDate", ((member.UpdatedDate == null) ? member.UpdatedDate : member.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", member.UpdatedBy);
                db.AddParameters("UpdatedFrom", member.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_Member", true);

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

        public bool Delete(Members member)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("MemberId", member.MemberId);
                int affectedRows = db.ExecuteNonQuery("Delete_Member", true);

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