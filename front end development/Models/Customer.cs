using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string CustomerSex { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerPassword { get; set; }
        public decimal? CustomerTel { get; set; }
        public string Qq { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
