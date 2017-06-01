using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderContains = new HashSet<OrderContains>();
        }

        public int CustomerOrderId { get; set; }
        public string CustomerOrderNo { get; set; }
        public string CustomerUserName { get; set; }

        public virtual ICollection<OrderContains> OrderContains { get; set; }
        public virtual Customer CustomerUserNameNavigation { get; set; }
    }
}
