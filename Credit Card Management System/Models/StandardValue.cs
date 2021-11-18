using System;
using System.Collections.Generic;

#nullable disable

namespace Credit_Card_Management_System.Models
{
    public partial class StandardValue
    {
        public StandardValue()
        {
            ApplicationCitizenshipNavigations = new HashSet<Application>();
            ApplicationMaritalStatusNavigations = new HashSet<Application>();
            ApplicationProfessionNavigations = new HashSet<Application>();
            CourierLogs = new HashSet<CourierLog>();
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public int? GroupId { get; set; }

        public virtual ICollection<Application> ApplicationCitizenshipNavigations { get; set; }
        public virtual ICollection<Application> ApplicationMaritalStatusNavigations { get; set; }
        public virtual ICollection<Application> ApplicationProfessionNavigations { get; set; }
        public virtual ICollection<CourierLog> CourierLogs { get; set; }
    }
}
