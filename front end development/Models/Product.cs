using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
            Pdetail = new HashSet<Pdetail>();
            Ppics = new HashSet<Ppics>();
        }

        public int ProductId { get; set; }
        public string ProductNo { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Pdetail> Pdetail { get; set; }
        public virtual ICollection<Ppics> Ppics { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
