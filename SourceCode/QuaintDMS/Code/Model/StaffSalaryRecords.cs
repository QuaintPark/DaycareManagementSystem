using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintDMS.Code.Model
{
    public class StaffSalaryRecords
    {
        public int StaffSalaryRecordId { get; set; }
        public string StaffSalaryRecordCode { get; set; }
        public decimal Salary { get; set; }
        public decimal PreviousDue { get; set; }
        public decimal Total { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Due { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int StaffId { get; set; }
    }
}