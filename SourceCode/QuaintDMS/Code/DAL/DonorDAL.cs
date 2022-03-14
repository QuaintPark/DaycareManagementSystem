using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class DonorDAL
    {
        public bool Save(Donors donor)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DonorCode", donor.DonorCode);
                db.AddParameters("FirstName", donor.FirstName);
                db.AddParameters("LastName", donor.LastName);
                db.AddParameters("DateOfBirth", donor.DateOfBirth);                
                db.AddParameters("Email", donor.Email);                
                db.AddParameters("ContactNumber", donor.ContactNumber);
                db.AddParameters("AddressLine1", donor.AddressLine1);
                db.AddParameters("AddressLine2", donor.AddressLine2);
                db.AddParameters("City", donor.City);
                db.AddParameters("ZipCode", donor.ZipCode);
                db.AddParameters("Country", donor.Country);
                db.AddParameters("NationalIdNumber", donor.NationalIdNumber);
                db.AddParameters("PassportNumber", donor.PassportNumber);
                db.AddParameters("DrivingLicenseNumber", donor.DrivingLicenseNumber);
                db.AddParameters("ProfilePhoto", donor.ProfilePhoto);
                db.AddParameters("CurrentStatus", donor.CurrentStatus);
                db.AddParameters("Password", donor.Password);
                db.AddParameters("PasswordStamp", donor.PasswordStamp);
                db.AddParameters("IsVerified", donor.IsVerified);
                db.AddParameters("IsDelete", donor.IsDelete);
                db.AddParameters("CreatedDate", donor.CreatedDate);
                db.AddParameters("CreatedBy", donor.CreatedBy);
                db.AddParameters("CreatedFrom", donor.CreatedFrom);
                db.AddParameters("UpdatedDate", donor.UpdatedDate);
                db.AddParameters("UpdatedBy", donor.UpdatedBy);
                db.AddParameters("UpdatedFrom", donor.UpdatedFrom);
                db.AddParameters("DesignationId", donor.DesignationId);
                int affectedRows = db.ExecuteNonQuery("Insert_Donors", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Donors", false);
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
                db.AddParameters("DonorId", id);
                DataTable dt = db.ExecuteDataTable("Get_Donors_By_Id", true);
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

        public bool Update(Donors donor)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DonorId", donor.DonorId);
                db.AddParameters("DonorCode", donor.DonorCode);
                db.AddParameters("FirstName", donor.FirstName);
                db.AddParameters("LastName", donor.LastName);
                db.AddParameters("DateOfBirth", donor.DateOfBirth);
                db.AddParameters("Email", donor.Email);
                db.AddParameters("ContactNumber", donor.ContactNumber);
                db.AddParameters("AddressLine1", donor.AddressLine1);
                db.AddParameters("AddressLine2", donor.AddressLine2);
                db.AddParameters("City", donor.City);
                db.AddParameters("ZipCode", donor.ZipCode);
                db.AddParameters("Country", donor.Country);
                db.AddParameters("NationalIdNumber", donor.NationalIdNumber);
                db.AddParameters("PassportNumber", donor.PassportNumber);
                db.AddParameters("DrivingLicenseNumber", donor.DrivingLicenseNumber);
                db.AddParameters("ProfilePhoto", donor.ProfilePhoto);
                db.AddParameters("CurrentStatus", donor.CurrentStatus);
                db.AddParameters("Password", donor.Password);
                db.AddParameters("PasswordStamp", donor.PasswordStamp);
                db.AddParameters("IsVerified", donor.IsVerified);
                db.AddParameters("IsDelete", donor.IsDelete);
                db.AddParameters("CreatedDate", donor.CreatedDate);
                db.AddParameters("CreatedBy", donor.CreatedBy);
                db.AddParameters("CreatedFrom", donor.CreatedFrom);
                db.AddParameters("UpdatedDate", donor.UpdatedDate);
                db.AddParameters("UpdatedBy", donor.UpdatedBy);
                db.AddParameters("UpdatedFrom", donor.UpdatedFrom);
                db.AddParameters("DesignationId", donor.DesignationId);
                int affectedRows = db.ExecuteNonQuery("Update_Donors", true);

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

        public bool Delete(Donors donor)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DonorId", donor.DonorId);
                int affectedRows = db.ExecuteNonQuery("Delete_Donors", true);

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