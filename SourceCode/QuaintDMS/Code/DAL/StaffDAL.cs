using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class StaffDAL
    {
        public bool Save(Staffs staff)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("StaffCode", staff.StaffCode);
                db.AddParameters("FirstName", staff.FirstName);
                db.AddParameters("LastName", staff.LastName);
                db.AddParameters("DateOfBirth", ((staff.DateOfBirth == null) ? staff.DateOfBirth : staff.DateOfBirth.Value));
                db.AddParameters("Email", staff.Email);
                db.AddParameters("ContactNumber", staff.ContactNumber);
                db.AddParameters("AddressLine1", staff.AddressLine1);
                db.AddParameters("AddressLine2", staff.AddressLine2);
                db.AddParameters("City", staff.City);
                db.AddParameters("ZipCode", ((staff.ZipCode == null) ? (int?)null : staff.ZipCode));
                db.AddParameters("Country", staff.Country);
                db.AddParameters("NationalIdNumber", staff.NationalIdNumber);
                db.AddParameters("PassportNumber", staff.PassportNumber);
                db.AddParameters("DrivingLicenseNumber", staff.DrivingLicenseNumber);
                db.AddParameters("ProfilePhoto", staff.ProfilePhoto);
                db.AddParameters("JoiningDate", ((staff.JoiningDate == null) ? staff.JoiningDate : staff.JoiningDate.Value));
                db.AddParameters("Salary", staff.Salary);
                db.AddParameters("AmountStatus", staff.AmountStatus);
                db.AddParameters("CurrentStatus", staff.CurrentStatus);
                db.AddParameters("Password", staff.Password);
                db.AddParameters("PasswordStamp", staff.PasswordStamp);
                db.AddParameters("SecurityQuestion", staff.SecurityQuestion);
                db.AddParameters("SecurityAnswer", staff.SecurityAnswer);
                db.AddParameters("IsVerified", staff.IsVerified);
                db.AddParameters("IsActive", staff.IsActive);
                db.AddParameters("CreatedDate", ((staff.CreatedDate == null) ? staff.CreatedDate : staff.CreatedDate.Value));
                db.AddParameters("CreatedBy", staff.CreatedBy);
                db.AddParameters("CreatedFrom", staff.CreatedFrom);
                db.AddParameters("UpdatedDate", ((staff.UpdatedDate == null) ? staff.UpdatedDate : staff.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", staff.UpdatedBy);
                db.AddParameters("UpdatedFrom", staff.UpdatedFrom);
                db.AddParameters("DesignationId", staff.DesignationId);
                int affectedRows = db.ExecuteNonQuery("Insert_Staff", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Staff", false);
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
                db.AddParameters("StaffId", id);
                DataTable dt = db.ExecuteDataTable("Get_Staff_By_Id", true);
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

        public bool Update(Staffs staff)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("StaffId", staff.StaffId);
                db.AddParameters("StaffCode", staff.StaffCode);
                db.AddParameters("FirstName", staff.FirstName);
                db.AddParameters("LastName", staff.LastName);
                db.AddParameters("DateOfBirth", ((staff.DateOfBirth == null) ? staff.DateOfBirth : staff.DateOfBirth.Value));
                db.AddParameters("Email", staff.Email);
                db.AddParameters("ContactNumber", staff.ContactNumber);
                db.AddParameters("AddressLine1", staff.AddressLine1);
                db.AddParameters("AddressLine2", staff.AddressLine2);
                db.AddParameters("City", staff.City);
                db.AddParameters("ZipCode", ((staff.ZipCode == null) ? (int?)null : staff.ZipCode));
                db.AddParameters("Country", staff.Country);
                db.AddParameters("NationalIdNumber", staff.NationalIdNumber);
                db.AddParameters("PassportNumber", staff.PassportNumber);
                db.AddParameters("DrivingLicenseNumber", staff.DrivingLicenseNumber);
                db.AddParameters("ProfilePhoto", staff.ProfilePhoto);
                db.AddParameters("JoiningDate", ((staff.JoiningDate == null) ? staff.JoiningDate : staff.JoiningDate.Value));
                db.AddParameters("Salary", staff.Salary);
                db.AddParameters("AmountStatus", staff.AmountStatus);
                db.AddParameters("CurrentStatus", staff.CurrentStatus);
                db.AddParameters("Password", staff.Password);
                db.AddParameters("PasswordStamp", staff.PasswordStamp);
                db.AddParameters("SecurityQuestion", staff.SecurityQuestion);
                db.AddParameters("SecurityAnswer", staff.SecurityAnswer);
                db.AddParameters("IsVerified", staff.IsVerified);
                db.AddParameters("IsActive", staff.IsActive);
                db.AddParameters("CreatedDate", ((staff.CreatedDate == null) ? staff.CreatedDate : staff.CreatedDate.Value));
                db.AddParameters("CreatedBy", staff.CreatedBy);
                db.AddParameters("CreatedFrom", staff.CreatedFrom);
                db.AddParameters("UpdatedDate", ((staff.UpdatedDate == null) ? staff.UpdatedDate : staff.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", staff.UpdatedBy);
                db.AddParameters("UpdatedFrom", staff.UpdatedFrom);
                db.AddParameters("DesignationId", staff.DesignationId);
                int affectedRows = db.ExecuteNonQuery("Update_Staff", true);

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

        public bool Delete(Staffs staff)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("StaffId", staff.StaffId);
                int affectedRows = db.ExecuteNonQuery("Delete_Staff", true);

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