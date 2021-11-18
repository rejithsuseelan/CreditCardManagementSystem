using Credit_Card_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Credit_Card_Management_System.Repository
{
    public interface IApplicationRepository
    {
        Task UpdateApplicationStatus(decimal applicationId, int? statusId);

        Task<decimal> AddApplication(Application application);

        Task<List<Application>> GetApplications();

        Task UpdateApplication(Application post);

        Task UpdateConsignmentStatus(ConsignamentInput input);

        Task<decimal> CourierLog(CourierLog Input);

        ApplicationOutput GetApplicationById(decimal id);
    }

    public partial class UpdateApplicationInput
    {
        public int? CardStatus { get; set; }
        public decimal ApplicationId { get; set; }

    }

    public partial class ConsignamentInput
    {
        public decimal ApplicationId { get; set; }
        public string CourierName { get; set; }
        public string TrackingNumber { get; set; }
        public int? CardStatus { get; set; }

    }

    public partial class ApplicationOutput
    {
        public decimal ApplicationId { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string ApplicantName { get; set; }
        public string FatherName { get; set; }
        public string DateOfBirth { get; set; }
        public string Pancard { get; set; }
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

        public string MaritalStatus { get; set; }
        public string Citizenship { get; set; }
        public string Profession { get; set; }

        public List<CourierLogs> CourierLogs { get; set; }

    }


    public partial class CourierLogs
    {
        public DateTime? Updatedate { get; set; }
        public string Status { get; set; }
    }

}
