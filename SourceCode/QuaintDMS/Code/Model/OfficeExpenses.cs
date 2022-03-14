﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintDMS.Code.Model
{
    public class OfficeExpenses
    {
        public int OfficeExpenseId { get; set; }
        public string OfficeExpenseCode { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string AmountStatus { get; set; }
        public string Reference { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
    }
}