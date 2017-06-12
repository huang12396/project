using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Orders
    {
        public int ObjId { get; set; }
        public string OrderId { get; set; }
        public string ProductNo { get; set; }
        public int? PaymentNo { get; set; }
        public string OrderAddress { get; set; }
        public string Phone { get; set; }
        public double? Amt { get; set; }
        public string OrderState { get; set; }
        public int? CustomerUserName { get; set; }

        public virtual Customer CustomerUserNameNavigation { get; set; }
        public virtual Payment PaymentNoNavigation { get; set; }
    }
}
