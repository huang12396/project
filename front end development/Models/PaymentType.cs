using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payment = new HashSet<Payment>();
        }

        public int ObjId { get; set; }
        public string TypeName { get; set; }
        public string Url { get; set; }
        public string MethodName { get; set; }
        public string Img { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
