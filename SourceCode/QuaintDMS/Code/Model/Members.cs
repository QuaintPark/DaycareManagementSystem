using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintDMS.Code.Model
{
    public class Members
    {
        public int MemberId { get; set; }
        public string MemberCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int? ZipCode { get; set; }
        public string Country { get; set; }
        public string NationalIdNumber { get; set; }
        public string PassportNumber { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string ProfilePhoto { get; set; }
        public string CurrentStatus { get; set; }
        public string Password { get; set; }
        public string PasswordStamp { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
    }
}