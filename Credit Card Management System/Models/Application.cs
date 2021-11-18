using System;
using System.Collections.Generic;

#nullable disable

namespace Credit_Card_Management_System.Models
{
    public partial class Application
    {
        public Application()
        {
            CourierLogs = new HashSet<CourierLog>();
        }

        public decimal ApplicationId { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FatherLastName { get; set; }
        public string DateOfBirth { get; set; }
        public int? MaritalStatus { get; set; }
        public int? Citizenship { get; set; }
        public string Pancard { get; set; }
        public int? Profession { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public decimal? AnnualIncome { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public string CorporateEmailId { get; set; }
        public string Area { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public bool? IsTermsAndCondition { get; set; }
        public string CardName { get; set; }
        public int? CardStatus { get; set; }
        public DateTime? StatusUpdatedDate { get; set; }
        public bool? IsShipped { get; set; }
        public string CourierName { get; set; }
        public string TrackingNumber { get; set; }

        public virtual StandardValue CitizenshipNavigation { get; set; }
        public virtual StandardValue MaritalStatusNavigation { get; set; }
        public virtual StandardValue ProfessionNavigation { get; set; }
        public virtual ICollection<CourierLog> CourierLogs { get; set; }
    }
}
