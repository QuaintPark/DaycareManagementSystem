using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class ChildDAL
    {
        public bool Save(Childs child)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ChildCode", child.ChildCode);
                db.AddParameters("FirstName", child.FirstName);
                db.AddParameters("LastName", child.LastName);
                db.AddParameters("DateOfBirth", ((child.DateOfBirth == null) ? child.DateOfBirth : child.DateOfBirth.Value));
                db.AddParameters("AddressLine1", child.AddressLine1);
                db.AddParameters("AddressLine2", child.AddressLine2);
                db.AddParameters("City", child.City);
                db.AddParameters("ZipCode", ((child.ZipCode == null) ? (int?)null : child.ZipCode));
                db.AddParameters("Country", child.Country);
                db.AddParameters("ProfilePhoto", child.ProfilePhoto);
                db.AddParameters("FatherName", child.FatherName);
                db.AddParameters("FatherProfession", child.FatherProfession);
                db.AddParameters("FatherContactNumber", child.FatherContactNumber);
                db.AddParameters("MotherName", child.MotherName);
                db.AddParameters("MotherProfession", child.MotherProfession);
                db.AddParameters("MotherContactNumber", child.MotherContactNumber);
                db.AddParameters("LocalGuardianName", child.LocalGuardianName);
                db.AddParameters("LocalGuardianProfession", child.LocalGuardianProfession);
                db.AddParameters("LocalGuardianContactNumber", child.LocalGuardianContactNumber);
                db.AddParameters("LocalGuardianAddressLine1", child.LocalGuardianAddressLine1);
                db.AddParameters("LocalGuardianAddressLine2", child.LocalGuardianAddressLine2);
                db.AddParameters("IsActive", child.IsActive);
                db.AddParameters("CreatedDate", ((child.CreatedDate == null) ? child.CreatedDate : child.CreatedDate.Value));
                db.AddParameters("CreatedBy", child.CreatedBy);
                db.AddParameters("CreatedFrom", child.CreatedFrom);
                db.AddParameters("UpdatedDate", ((child.UpdatedDate == null) ? child.UpdatedDate : child.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", child.UpdatedBy);
                db.AddParameters("UpdatedFrom", child.UpdatedFrom);
                db.AddParameters("MemberId", child.MemberId);
                db.AddParameters("ProgramId", child.ProgramId);
                int affectedRows = db.ExecuteNonQuery("Insert_Child", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_Child", false);
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
                db.AddParameters("ChildId", id);
                DataTable dt = db.ExecuteDataTable("Get_Child_By_Id", true);
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

        public bool Update(Childs child)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ChildId", child.ChildId);
                db.AddParameters("ChildCode", child.ChildCode);
                db.AddParameters("FirstName", child.FirstName);
                db.AddParameters("LastName", child.LastName);
                db.AddParameters("DateOfBirth", ((child.DateOfBirth == null) ? child.DateOfBirth : child.DateOfBirth.Value));
                db.AddParameters("AddressLine1", child.AddressLine1);
                db.AddParameters("AddressLine2", child.AddressLine2);
                db.AddParameters("City", child.City);
                db.AddParameters("ZipCode", ((child.ZipCode == null) ? (int?)null : child.ZipCode));
                db.AddParameters("Country", child.Country);
                db.AddParameters("ProfilePhoto", child.ProfilePhoto);
                db.AddParameters("FatherName", child.FatherName);
                db.AddParameters("FatherProfession", child.FatherProfession);
                db.AddParameters("FatherContactNumber", child.FatherContactNumber);
                db.AddParameters("MotherName", child.MotherName);
                db.AddParameters("MotherProfession", child.MotherProfession);
                db.AddParameters("MotherContactNumber", child.MotherContactNumber);
                db.AddParameters("LocalGuardianName", child.LocalGuardianName);
                db.AddParameters("LocalGuardianProfession", child.LocalGuardianProfession);
                db.AddParameters("LocalGuardianContactNumber", child.LocalGuardianContactNumber);
                db.AddParameters("LocalGuardianAddressLine1", child.LocalGuardianAddressLine1);
                db.AddParameters("LocalGuardianAddressLine2", child.LocalGuardianAddressLine2);
                db.AddParameters("IsActive", child.IsActive);
                db.AddParameters("CreatedDate", ((child.CreatedDate == null) ? child.CreatedDate : child.CreatedDate.Value));
                db.AddParameters("CreatedBy", child.CreatedBy);
                db.AddParameters("CreatedFrom", child.CreatedFrom);
                db.AddParameters("UpdatedDate", ((child.UpdatedDate == null) ? child.UpdatedDate : child.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", child.UpdatedBy);
                db.AddParameters("UpdatedFrom", child.UpdatedFrom);
                db.AddParameters("MemberId", child.MemberId);
                db.AddParameters("ProgramId", child.ProgramId);
                int affectedRows = db.ExecuteNonQuery("Update_Child", true);

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

        public bool Delete(Childs child)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ChildId", child.ChildId);
                int affectedRows = db.ExecuteNonQuery("Delete_Child", true);

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