using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintDMS.Code.Model
{
    public class Childs
    {
        public int ChildId { get; set; }
        public string ChildCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? ZipCode { get; set; }
        public string Country { get; set; }
        public string ProfilePhoto { get; set; }
        public string FatherName { get; set; }
        public string FatherProfession { get; set; }
        public string FatherContactNumber { get; set; }
        public string MotherName { get; set; }
        public string MotherProfession { get; set; }
        public string MotherContactNumber { get; set; }
        public string LocalGuardianName { get; set; }
        public string LocalGuardianProfession { get; set; }
        public string LocalGuardianContactNumber { get; set; }
        public string LocalGuardianAddressLine1 { get; set; }
        public string LocalGuardianAddressLine2 { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int MemberId { get; set; }
        public int ProgramId { get; set; }
    }
}