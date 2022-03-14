using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintPark;
using System.Data;

namespace QuaintDMS.Code.DAL
{
    public class ProgramWiseServiceDAL
    {
        public bool SaveAll(List<ProgramWiseServices> programWiseServiceList)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = true;

                foreach (ProgramWiseServices programWiseServices in programWiseServiceList)
                {
                    db.ClearParameters();
                    db.AddParameters("ProgramId", programWiseServices.ProgramId);
                    db.AddParameters("ServiceId", programWiseServices.ServiceId);
                    db.AddParameters("CreatedDate", ((programWiseServices.CreatedDate == null) ? programWiseServices.CreatedDate : programWiseServices.CreatedDate.Value));
                    db.AddParameters("CreatedBy", programWiseServices.CreatedBy);
                    db.AddParameters("CreatedFrom", programWiseServices.CreatedFrom);
                    db.AddParameters("UpdatedDate", ((programWiseServices.UpdatedDate == null) ? programWiseServices.UpdatedDate : programWiseServices.UpdatedDate.Value));
                    db.AddParameters("UpdatedBy", programWiseServices.UpdatedBy);
                    db.AddParameters("UpdatedFrom", programWiseServices.UpdatedFrom);
                    int affectedRows = db.ExecuteNonQuery("Insert_ProgramWiseService", true);

                    if (affectedRows < 1)
                        flag = false;
                }

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

        public DataTable GetByProgramId(int programId)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                db.AddParameters("ProgramId", programId);
                DataTable dt = db.ExecuteDataTable("Get_ProgramWiseServices_By_ProgramId", true);
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

        public bool DeleteByProgramId(int programId)
        {
            QuaintDatabaseManager db = new QuaintDatabaseManager(true);

            try
            {
                bool flag = false;
                db.AddParameters("ProgramId", programId);
                int affectedRows = db.ExecuteNonQuery("Delete_ProgramWiseServices_By_ProgramId", true);

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