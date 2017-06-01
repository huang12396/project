using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffLgId { get; set; }
        public string StaffPassword { get; set; }
        public string StaffSex { get; set; }
        public string Position { get; set; }
        public DateTime? Birthday { get; set; }
        public string StaffAddr { get; set; }
        public decimal? Tel { get; set; }
    }
}
