using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuaintDMS.Code.Model;
using QuaintDMS.Code.DAL;
using System.Data;

namespace QuaintDMS.Code.BLL
{
    public class ProgramWiseServiceBLL
    {
        public bool SaveAll(List<ProgramWiseServices> programWiseServiceList)
        {
            try
            {
                ProgramWiseServiceDAL programWiseServiceDAL = new ProgramWiseServiceDAL();
                return programWiseServiceDAL.SaveAll(programWiseServiceList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetByProgramId(int programId)
        {
            try
            {
                ProgramWiseServiceDAL programWiseServiceDAL = new ProgramWiseServiceDAL();
                return programWiseServiceDAL.GetByProgramId(programId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteByProgramId(int programId)
        {
            try
            {
                ProgramWiseServiceDAL programWiseServiceDAL = new ProgramWiseServiceDAL();
                return programWiseServiceDAL.DeleteByProgramId(programId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}