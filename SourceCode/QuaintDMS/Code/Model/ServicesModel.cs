using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintDMS.Code.Model
{
    [Serializable]
    public class ServicesModel
    {
        public int ServiceId { get; set; }
        public string ServiceCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
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