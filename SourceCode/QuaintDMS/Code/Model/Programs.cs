using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintDMS.Code.Model
{
    public class Programs
    {
        public int ProgramId { get; set; }
        public string ProgramCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AgeRange { get; set; }
        public string Period { get; set; }
        public decimal TotalAmount { get; set; }
        public string AmountStatus { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
    }
}