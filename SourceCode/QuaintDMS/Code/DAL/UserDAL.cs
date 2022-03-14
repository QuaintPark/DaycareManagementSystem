using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class UserDAL
    {
        public bool Save(Users user)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("UserCode", user.UserCode);
                db.AddParameters("FullName", user.FullName);
                db.AddParameters("Email", user.Email);
                db.AddParameters("Password", user.Password);
                db.AddParameters("PasswordStamp", user.PasswordStamp);
                db.AddParameters("CreatedDate", ((user.CreatedDate == null) ? user.CreatedDate : user.CreatedDate.Value));
                db.AddParameters("CreatedBy", user.CreatedBy);
                db.AddParameters("CreatedFrom", user.CreatedFrom);
                db.AddParameters("UpdatedDate", ((user.UpdatedDate == null) ? user.UpdatedDate : user.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", user.UpdatedBy);
                db.AddParameters("UpdatedFrom", user.UpdatedFrom);
                db.AddParameters("UserType", user.UserType);
                int affectedRows = db.ExecuteNonQuery("Insert_User", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_User", false);
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
                db.AddParameters("UserId", id);
                DataTable dt = db.ExecuteDataTable("Get_User_By_Id", true);
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

        public bool Update(Users user)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("UserId", user.UserId);
                db.AddParameters("UserCode", user.UserCode);
                db.AddParameters("FullName", user.FullName);
                db.AddParameters("Email", user.Email);
                db.AddParameters("Password", user.Password);
                db.AddParameters("PasswordStamp", user.PasswordStamp);
                db.AddParameters("CreatedDate", ((user.CreatedDate == null) ? user.CreatedDate : user.CreatedDate.Value));
                db.AddParameters("CreatedBy", user.CreatedBy);
                db.AddParameters("CreatedFrom", user.CreatedFrom);
                db.AddParameters("UpdatedDate", ((user.UpdatedDate == null) ? user.UpdatedDate : user.UpdatedDate.Value));
                db.AddParameters("UpdatedBy", user.UpdatedBy);
                db.AddParameters("UpdatedFrom", user.UpdatedFrom);
                db.AddParameters("UserType", user.UserType);
                int affectedRows = db.ExecuteNonQuery("Update_User", true);

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

        public bool Delete(Users user)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("UserId", user.UserId);
                int affectedRows = db.ExecuteNonQuery("Delete_User", true);

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