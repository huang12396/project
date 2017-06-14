using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Orders>();
        }

        public int ObjId { get; set; }
        public double? Amount { get; set; }
        public int? ThePaymentType { get; set; }
        public DateTime? TransTime { get; set; }
        public string TransNo { get; set; }
        public int PaymentState { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual PaymentType ThePaymentTypeNavigation { get; set; }
    }
}
