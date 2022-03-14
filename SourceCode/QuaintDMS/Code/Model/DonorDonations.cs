using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintDMS.Code.Model
{
    public class DonorDonations
    {
        public int DonorDonationId { get; set; }
        public string DonorDonationCode { get; set; }
        public decimal DonationAmount { get; set; }
        public string AmountStatus { get; set; }
        public DateTime DonationDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int DonorId { get; set; }
    }
}