using System;
using System.Collections.Generic;

#nullable disable

namespace Credit_Card_Management_System.Models
{
    public partial class CourierLog
    {
        public int LogId { get; set; }
        public decimal ApplicationId { get; set; }
        public DateTime? Updatedate { get; set; }
        public int? StatusId { get; set; }

        public virtual Application Application { get; set; }
        public virtual StandardValue Status { get; set; }
    }
}
