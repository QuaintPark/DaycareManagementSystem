using QuaintDMS.Code.Model;
using QuaintPark;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QuaintDMS.Code.DAL
{
    public class DonorDonationDAL
    {
        public bool Save(DonorDonations donorDonation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DonorDonationCode", donorDonation.DonorDonationCode);
                db.AddParameters("DonationAmount", donorDonation.DonationAmount);
                db.AddParameters("AmountStatus", donorDonation.AmountStatus);
                db.AddParameters("DonationDate", donorDonation.DonationDate);
                db.AddParameters("CreatedDate", donorDonation.CreatedDate);
                db.AddParameters("CreatedBy", donorDonation.CreatedBy);
                db.AddParameters("CreatedFrom", donorDonation.CreatedFrom);
                db.AddParameters("UpdatedDate", donorDonation.UpdatedDate);
                db.AddParameters("UpdatedBy", donorDonation.UpdatedBy);
                db.AddParameters("UpdatedFrom", donorDonation.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Insert_DonorDonations", true);

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
                DataTable dt = db.ExecuteDataTable("Get_All_DonorDonations", false);
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
                db.AddParameters("DonorDonationId", id);
                DataTable dt = db.ExecuteDataTable("Get_DonorDonations_By_Id", true);
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

        public bool Update(DonorDonations donorDonation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DonorDonationId", donorDonation.DonorDonationId);
                db.AddParameters("DonorDonationCode", donorDonation.DonorDonationCode);
                db.AddParameters("DonationAmount", donorDonation.DonationAmount);
                db.AddParameters("AmountStatus", donorDonation.AmountStatus);
                db.AddParameters("DonationDate", donorDonation.DonationDate);
                db.AddParameters("CreatedDate", donorDonation.CreatedDate);
                db.AddParameters("CreatedBy", donorDonation.CreatedBy);
                db.AddParameters("CreatedFrom", donorDonation.CreatedFrom);
                db.AddParameters("UpdatedDate", donorDonation.UpdatedDate);
                db.AddParameters("UpdatedBy", donorDonation.UpdatedBy);
                db.AddParameters("UpdatedFrom", donorDonation.UpdatedFrom);
                int affectedRows = db.ExecuteNonQuery("Update_DonorDonations", true);

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

        public bool Delete(DonorDonations donorDonation)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("DonorDonationId", donorDonation.DonorDonationId);
                int affectedRows = db.ExecuteNonQuery("Delete_DonorDonations", true);

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