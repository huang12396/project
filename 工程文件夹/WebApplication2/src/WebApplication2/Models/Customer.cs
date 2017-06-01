using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cart = new HashSet<Cart>();
            CustomerOrder = new HashSet<CustomerOrder>();
        }

        public int CustomerId { get; set; }
        public string CustomerSex { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerAddr { get; set; }
        public decimal? CustomerTel { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }
}
