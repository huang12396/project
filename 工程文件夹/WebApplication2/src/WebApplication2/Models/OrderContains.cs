using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class OrderContains
    {
        public int OrderContainsId { get; set; }
        public string CustomerOrderNo { get; set; }
        public string ProductNo { get; set; }
        public int ProductNum { get; set; }

        public virtual CustomerOrder CustomerOrderNoNavigation { get; set; }
        public virtual Product ProductNoNavigation { get; set; }
    }
}
