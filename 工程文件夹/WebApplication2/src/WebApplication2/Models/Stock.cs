using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Stock
    {
        public string ProductNo { get; set; }
        public int StockNum { get; set; }

        public virtual Product ProductNoNavigation { get; set; }
    }
}
